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
using FluentValidation.AspNetCore;
using farm_api.Validation;

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
            builder.Services.AddSwaggerGen();
            builder.Services
                .AddDbContext<FarmContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("FarmDB")));
            builder.Services.AddCors(options
                                        => options.AddPolicy(Cors
                                        , policies =>
                                                policies.AllowAnyOrigin()
                                                .AllowAnyHeader()
                                                .AllowAnyMethod()));
            builder.Services.AddValidatorsFromAssemblyContaining<EnvironmentRequestValidator>();


           

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IEnvironmentRepository, EnvironmentRepository>();
            builder.Services.AddScoped<IEnvironmentService, EnvironmentService>();
            builder.Services.AddScoped<ISeeder, Seeder>();


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
            return app;
        }
        public static WebApplication ConfigurePieline(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors(Cors);
            app.MapControllers();
            return app;
        }
    }
}
