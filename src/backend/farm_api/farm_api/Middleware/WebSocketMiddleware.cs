using Core.Common;
using Core.Constant;
using DAL.Repositories.Interface;
using DAL.Repositories.UnitOfWork;
using farm_api.Models;
using farm_api.Models.Request;
using farm_api.Services.Implementation;
using farm_api.Services.Interface;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.WebSockets;
using System.Text;
using static Core.Enums.MessageSocket;

namespace farm_api.Middleware
{
    public class WebSocketMiddleware
    {
        private readonly RequestDelegate _next;
        private SocketMangement _manager;
        private SocketResultManagement _socketResultManagement { get; set; }   
       

        public WebSocketMiddleware(RequestDelegate next, SocketMangement manager, SocketResultManagement socketResultManagement)
        {
            _next = next;
            _manager = manager;
            _socketResultManagement = socketResultManagement;

        }

        public async Task InvokeAsync(HttpContext context, IDeviceRepository devices, IUnitOfWork unitOfWork)
        {
            if (context.WebSockets.IsWebSocketRequest )
            {
                WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();//listen client to accept

                // Listen for receive
                await Receive(webSocket, async (result, buffer) =>
                {
                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        string jsonString = Encoding.UTF8.GetString(buffer, 0, result.Count);
                        try
                        {
                            // Parse the JSON to a dynamic object to read the messageType
                            // Phân tích cú pháp chuỗi JSON nhận được
                            var message = JsonConvert.DeserializeObject<WebSocketMessage<object>>(jsonString);
                            var messageType = message.MessageType;
                            var deviceId= message.DeviceId;

                            // Xử lý dựa trên loại tin nhắn
                            switch (messageType)
                            {
                                case MessageType.DeviceInfo:
                                    var deviceInfo = JsonConvert.DeserializeObject<DeviceInfo>(Convert.ToString(message.Data));
                                    _manager.AddSocket(deviceId, webSocket);
                                    // Xử lý thông tin thiết bị tại đây
                                    break;

                                case MessageType.WeatherData:
                                    var weatherData = JsonConvert.DeserializeObject<WeatherData>(Convert.ToString(message.Data));
                                    _socketResultManagement.AddSocketResultOrUpdate(deviceId, weatherData);
                                    // Xử lý dữ liệu thời tiết tại đây
                                    break;

                                default:
                                    Console.WriteLine($"Unknown message type: {messageType}");
                                    break;
                            }

                        }
                        catch (JsonException ex)
                        {
                            // Handle if JSON is invalid
                            Console.WriteLine("Invalid JSON received: " + ex.Message);
                        }
                    }
                });


                // Keep the middleware pipeline going
                await _next(context);
            }
            else
            {
                // Pass it on down the middleware chain if it's not a WebSocket request
                await _next(context);
            }
        }

        private async Task Receive(WebSocket webSocket, Action<WebSocketReceiveResult, byte[]> handleMessage)
        {
            var buffer = new byte[1024 * 4];

            while (webSocket.State == WebSocketState.Open)
            {
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                handleMessage(result, buffer);
            }
        }
    }

}
