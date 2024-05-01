using DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using FluentValidation;
using DAL.Repositories.Interface;
using DAL.Repositories.UnitOfWork;
using farm_api.Services.Interface;
using farm_api.Services.Implementation;
using DAL.Repositories.Implementation;
using System.Data;
using DAL.Seeder;
using Microsoft.AspNetCore.SignalR;
using FluentValidation.AspNetCore;
using farm_api.Validation;
using System.Net.WebSockets;
using System.Text;
using Microsoft.OpenApi.Models;
using farm_api.Hub;
using Quartz;
using farm_api.Job;
using Quartz.Impl;
using Microsoft.Extensions.Options;
using farm_api.Caching.Implementation;
using farm_api.Caching.Interface;
using farm_api.Caching.Decorator;

namespace farm_api.Extensions
{
    public static class WebExtensions
    {
        private const string Cors = "Allow*";


        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddMemoryCache();
            builder.Services.AddSingleton<ICache, MemoryCacheAdapter>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                // Tạo đường dẫn đến file XML chứa các bình luận tài liệu
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            builder.Services.AddSignalR();
            builder.Services
                .AddDbContext<FarmContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("FarmDB")));
            builder.Services.AddCors(options
                                        => options.AddPolicy(Cors
                                        , policies =>
                                                policies
                                                .AllowAnyHeader()
                                                .SetIsOriginAllowed((host) => true)
                                                .AllowCredentials()
                                                .AllowAnyMethod()));
            builder.Services.AddValidatorsFromAssemblyContaining<EnvironmentRequestValidator>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IEnvironmentRepository, EnvironmentRepository>();
            builder.Services.AddScoped<IEnvironmentService, EnvironmentService>();
            builder.Services.AddScoped<ISeeder, Seeder>();
            builder.Services.AddScoped<ICameraRepository, CameraRepository>();
            builder.Services.AddScoped<ICameraService, CameraService>();
            builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
            builder.Services.AddScoped<IDeviceService, DeviceService>();
            builder.Services.AddScoped<IFarmRepositorty, FarmRepositorty>();
            builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
            builder.Services.AddScoped<IFarmService, FarmService>();
            builder.Services.AddScoped<ISeeder, Seeder>();
            builder.Services.AddScoped<ITopicService,TopicService>();
            builder.Services.AddSingleton<IMQTTService, MQTTService>();
            builder.Services.AddScoped<IDeviceScheduleRepository, DeviceScheduleRepository>();
            builder.Services.Decorate<IScheduleRepository, ScheduleRepositoryDecorator>();
            builder.Services.AddLogging();
            //-------------------------------------------------------------------------
            builder.Services.AddScoped<IScheduleService, ScheduleService>();
            builder.Services.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionJobFactory(options =>
                {
                    // Cấu hình thêm nếu cần
                    options.AllowDefaultConstructor = false; // Khuyến nghị chỉ dùng các constructor có tham số
                });
                q.UseSimpleTypeLoader();
                q.UseInMemoryStore();
                q.UseDefaultThreadPool(tp =>
                {
                    tp.MaxConcurrency = 10;
                });
            });

            // Đăng ký Quartz làm hosted service để tự động khởi tạo và quản lý lifecycle của IScheduler
            builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
            return builder;
        }
        public static IApplicationBuilder UseDataSeeder(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            try
            {
                scope.ServiceProvider
                    .GetRequiredService<ISeeder>()
                    .InitData();
            }
            catch (Exception ex)
            {

                scope.ServiceProvider
                    .GetRequiredService<ILogger<Program>>()
                    .LogError(ex, "could not insert data into database");
            }
            using var scopeMQTT = app.ApplicationServices.CreateScope();
            try
            {
                scope.ServiceProvider
                    .GetRequiredService<IMQTTService>()
                    .InitializeAsync();
            }
            catch (Exception ex)
            {

                scope.ServiceProvider
                    .GetRequiredService<ILogger<Program>>()
                    .LogError(ex, "could not init MQTT");
            }
            return app;
        }
        public static WebApplication ConfigurePieline(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
            //}
            app.MapHub<FarmHub>("/farmhub");
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseCors(Cors);
            app.MapControllers();
            app.UseWebSockets();
            return app;
        }
    }
}
