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

namespace farm_api.Extensions
{
    public static class WebExtensions
    {
        private const string Cors = "Allow*";


        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
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
                                                policies.AllowAnyOrigin()
                                                .WithOrigins("http://localhost:3000")
                                                .AllowAnyHeader()
                                                .AllowAnyMethod()
                                                .AllowCredentials()));

            builder.Services.AddValidatorsFromAssemblyContaining<EnvironmentRequestValidator>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IEnvironmentRepository, EnvironmentRepository>();
            builder.Services.AddScoped<IEnvironmentService, EnvironmentService>();
            builder.Services.AddScoped<ISeeder, Seeder>();
            builder.Services.AddScoped<ICameraRepository, CameraRepository>();
            builder.Services.AddScoped<ICameraService, CameraService>();
            builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
            builder.Services.AddScoped<IDeviceService, DeviceService>();
            builder.Services.AddScoped<IFarmRepositorty, FarmRepositorty>();
            builder.Services.AddScoped<IFarmService, FarmService>();
            builder.Services.AddScoped<ISeeder, Seeder>();
            builder.Services.AddSingleton<IMQTTService, MQTTService>();
            // Cấu hình Quartz
            builder.Services.AddQuartz(q =>
            {
                // Sử dụng một job factory được tích hợp với Microsoft DI
                q.UseMicrosoftDependencyInjectionJobFactory();

                // Cấu hình job detail và trigger ở đây hoặc sử dụng IJob instance trực tiếp
            });

            // Đăng ký Quartz Hosted Service với một cài đặt để đợi các công việc hoàn thành khi ứng dụng đang đóng
            builder.Services.AddQuartzHostedService(options =>
            {
                options.WaitForJobsToComplete = true;
            });
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
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
            }
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
