using Core.Common;
using Core.Entities;
using DAL.Repositories.UnitOfWork;
using farm_api.Models;
using farm_api.Models.Request;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;

namespace farm_api.Services.Implementation
{
    public class SocketMangement
    {
        private ConcurrentDictionary<string, WebSocket> _sockets = new ConcurrentDictionary<string, WebSocket>();
        public string AddSocket(string connectionId, WebSocket socket)
        {
            _sockets.TryAdd(connectionId, socket);
            Console.WriteLine("WebSocket added: " + connectionId);
            return connectionId;
        }

        public async Task RemoveSocket(string connectionId)
        {
            if (_sockets.TryRemove(connectionId, out WebSocket socket))
            {
                await socket.CloseAsync(closeStatus: WebSocketCloseStatus.NormalClosure,
                                        statusDescription: "Closed by the WebSocketConnectionManager",
                                        cancellationToken: CancellationToken.None);
                Console.WriteLine("WebSocket removed: " + connectionId);
            }
        }

        public WebSocket GetSocketById(string id)
        {
            _sockets.TryGetValue(id, out WebSocket socket);
            return socket;
        }

        public ICollection<WebSocket> GetAll()
        {
            return _sockets.Values;
        }
        
        public async Task SendMessageAsync(string connectionId, string message)
        {
            if (!_sockets.TryGetValue(connectionId, out WebSocket socket))
                throw new KeyNotFoundException("Connection ID not found");

            if (socket.State != WebSocketState.Open)
                throw new InvalidOperationException("WebSocket is not connected");

            var buffer = Encoding.UTF8.GetBytes(message);
            var segment = new ArraySegment<byte>(buffer);
            await socket.SendAsync(segment, WebSocketMessageType.Text, true, CancellationToken.None);
        }
        public async Task SendMessageAsync(string connectionId, WebSocketMessage<DeviceDTO> deviceRequest)
        {
            if (!_sockets.TryGetValue(connectionId, out WebSocket socket))
                throw new KeyNotFoundException("Connection ID not found");

            if (socket.State != WebSocketState.Open)
                throw new InvalidOperationException("WebSocket is not connected");

            // Chuyển đối tượng deviceRequest thành chuỗi JSON
            string json = JsonConvert.SerializeObject(deviceRequest);

            var buffer = Encoding.UTF8.GetBytes(json);
            var segment = new ArraySegment<byte>(buffer);
            await socket.SendAsync(segment, WebSocketMessageType.Text, true, CancellationToken.None);
        }

        public async Task SendMessageToAllAsync(string message)
        {
            foreach (var pair in _sockets)
            {
                if (pair.Value.State == WebSocketState.Open)
                    await SendMessageAsync(pair.Key, message);
            }
        }
        public async Task<WeatherData> ReceiveAsync(WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            var receivedMessage = new StringBuilder();

            WebSocketReceiveResult result = null;

            do
            {
                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                if (result.MessageType == WebSocketMessageType.Text)
                {
                    var segment = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    receivedMessage.Append(segment);
                }
                else if (result.MessageType == WebSocketMessageType.Close)
                {
                    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                }
            }
            while (!result.EndOfMessage);

            if (receivedMessage.Length > 0)
            {
                // Chuyển đổi chuỗi JSON nhận được thành đối tượng WeatherData
                return JsonConvert.DeserializeObject<WeatherData>(receivedMessage.ToString());
            }

            return null; // Hoặc trả về một instance WeatherData rỗng/không có giá trị tùy thuộc vào logic ứng dụng của bạn
        }
        public async Task<WeatherData> SendAndReceiveAsync(string connectionId, string action)
        {
            if (!_sockets.TryGetValue(connectionId, out WebSocket socket))
                throw new KeyNotFoundException("Connection ID not found");

            if (socket.State != WebSocketState.Open)
                throw new InvalidOperationException("WebSocket is not connected");

            // Gửi thông điệp
            var requestBuffer = Encoding.UTF8.GetBytes(action);
            await socket.SendAsync(new ArraySegment<byte>(requestBuffer), WebSocketMessageType.Text, true, CancellationToken.None);

            // Nhận và xử lý phản hồi
            var buffer = new byte[1024 * 4];
            var receivedMessage = new StringBuilder();
            WebSocketReceiveResult result;
            do
            {
                result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                if (result.MessageType == WebSocketMessageType.Text)
                {
                    var segment = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    receivedMessage.Append(segment);
                }
                else if (result.MessageType == WebSocketMessageType.Close)
                {
                    await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Client initiated close", CancellationToken.None);
                    return null; // hoặc xử lý phù hợp
                }
            } while (!result.EndOfMessage);

            // Giả định phản hồi là một JSON có thể chuyển đổi thành WeatherData
            try
            {
                var weatherData = JsonConvert.DeserializeObject<WeatherData>(receivedMessage.ToString());
                return weatherData;
            }
            catch (JsonException ex)
            {
                Console.WriteLine("Invalid JSON received: " + ex.Message);
                return null;
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
