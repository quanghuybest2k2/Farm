using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class DeviceController
{
    private ClientWebSocket webSocket;

    public DeviceController()
    {
        webSocket = new ClientWebSocket();
    }

    public async Task ConnectAsync(string url)
    {
        await webSocket.ConnectAsync(new Uri(url), CancellationToken.None);
        Console.WriteLine("Kết nối thành công!");
        await ReceiveMessages();
    }

    public async Task DisconnectAsync()
    {
        if (webSocket.State == WebSocketState.Open)
        {
            await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
            Console.WriteLine("Kết nối đóng.");
        }
    }

    private async Task ReceiveMessages()
    {
        var buffer = new byte[1024 * 4];

        while (webSocket.State == WebSocketState.Open)
        {
            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            if (result.MessageType == WebSocketMessageType.Text)
            {
                var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                Console.WriteLine("Tin nhắn từ server: " + message);
                ExecuteCommand(message);
            }
            else if (result.MessageType == WebSocketMessageType.Close)
            {
                await DisconnectAsync();
            }
        }
    }

    private void ExecuteCommand(string command)
    {
        var parts = command.Split(':');
        if (parts.Length == 2)
        {
            var deviceName = parts[0];
            var action = parts[1];

            Console.WriteLine($"Thực hiện: {deviceName} -> {action}");
            // Thực hiện hành động dựa trên command ở đây
        }
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        var deviceController = new DeviceController();
        await deviceController.ConnectAsync("wss://localhost:7171/ws");

        Console.WriteLine("Nhấn Enter để ngắt kết nối...");
        Console.ReadLine();

        await deviceController.DisconnectAsync();
    }
}
