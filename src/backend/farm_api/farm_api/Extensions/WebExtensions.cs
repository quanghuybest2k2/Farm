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
using farm_api.Middleware;

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
            builder.Services.AddSignalR();
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
            builder.Services.AddScoped<ICameraRepository, CameraRepository>();
            builder.Services.AddScoped<ICameraService, CameraService>();
            builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
            builder.Services.AddScoped<IDeviceService, DeviceService>();
            builder.Services.AddScoped<ISeeder, Seeder>();
            builder.Services.AddSingleton<SocketMangement>();
            builder.Services.AddSingleton<SocketResultManagement>();

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
            //async Task ProcessSensorData(WebSocket webSocket)
            //{
            //    var buffer = new byte[100];
            //    WebSocketReceiveResult result;

            //    do
            //    {
            //        result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            //        if (result.MessageType == WebSocketMessageType.Text)
            //        {
            //            string sensorData = Encoding.UTF8.GetString(buffer, 0, result.Count);
            //            Console.WriteLine($"Received data: {sensorData}");

            //            // TODO: Process received data from sensor C
            //        }

            //        // Echo the received data back to the sender
            //        if (result.MessageType == WebSocketMessageType.Close)
            //        {
            //            await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
            //        }

            //    } while (!result.CloseStatus.HasValue);
            //}
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
            app.UseWebSockets();
            app.UseMiddleware<WebSocketMiddleware>();
            //app.Use(async (context, next) =>
            //{
            //    if (context.Request.Path == "/ws")
            //    {
            //        if (context.WebSockets.IsWebSocketRequest)
            //        {
            //            WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
            //            await ProcessSensorData(webSocket);
            //        }
            //        else
            //        {
            //            context.Response.StatusCode = 400;
            //        }
            //    }
            //    else
            //    {
            //        await next();
            //    }
            //});
            return app;
        }


    }
}
