using Core.Constant;
using Core.DTO;
using farm_api.Hub;
using farm_api.Models.Request;
using farm_api.Services.Interface;
using Microsoft.AspNetCore.SignalR;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Packets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
/// <summary>
/// 
/// </summary>
public class MQTTService : IMQTTService
{
    private readonly IMqttClient _client;
    private MqttClientOptions _options;
    private readonly IHubContext<FarmHub> _hubContext;
    private bool _isConnected;

    public bool IsConnected { get { return _isConnected; } }

    /// <summary>
    /// 
    /// </summary>
    [Obsolete]
    public MQTTService(IHubContext<FarmHub> hubContext)
    {
        _hubContext = hubContext;
        var factory = new MqttFactory();
        _client = factory.CreateMqttClient();

        _options = new MqttClientOptionsBuilder()
            .WithClientId(Guid.NewGuid().ToString())
             .WithTcpServer(Ulities.HostServerMQTTHiveMQ, Ulities.PortServerMQTTHiveMQ) // Đổi "your_mqtt_broker_address" thành địa chỉ của máy chủ MQTT của bạn
             .WithCredentials(Ulities.AccountMQTTHiveMQ, Ulities.PasswordMQTTHiveMQ) // Thay thế bằng thông tin đăng nhập nếu máy chủ yêu cầu
             .WithTls() // Thêm dòng này để sử dụng kết nối qua TLS/SSL
             .Build() as MqttClientOptions; ;

        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // Thiết lập các event handlers
        _client.ConnectedAsync += async e =>
        {
            _isConnected = true;
            var topicFilter = new MqttTopicFilter { Topic = "esp8266/ledControl", QualityOfServiceLevel = MQTTnet.Protocol.MqttQualityOfServiceLevel.AtMostOnce };
            await _client.SubscribeAsync(topicFilter);
            var topicDeviceStatus = new MqttTopicFilter { Topic = "esp8266/ledStatus", QualityOfServiceLevel = MQTTnet.Protocol.MqttQualityOfServiceLevel.AtMostOnce };
            await _client.SubscribeAsync(topicDeviceStatus);
            var topicSensorStatus = new MqttTopicFilter { Topic = "sensor/data", QualityOfServiceLevel = MQTTnet.Protocol.MqttQualityOfServiceLevel.AtMostOnce };
            await _client.SubscribeAsync(topicSensorStatus);
            Console.WriteLine("Đã kết nối tới MQTT broker.");
        };

        _client.DisconnectedAsync += async e =>
        {
            _isConnected = false;
            Console.WriteLine("Đã ngắt kết nối với MQTT broker.");
        };

        _client.ApplicationMessageReceivedAsync += async e =>
        {
            string messagePayload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
            switch (e.ApplicationMessage.Topic)
            {
                case "esp8266/ledStatus":
                    await _hubContext.Clients.All.SendAsync("StatusLed", messagePayload);
                    break;
                case "sensor/data":
                    await _hubContext.Clients.All.SendAsync("sensorKV1", messagePayload);
                    break;
                default:
                    break;
            }
            Console.WriteLine($"Nhận được thông điệp: {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)} trên chủ đề: {e.ApplicationMessage.Topic}");
            Console.WriteLine($"Nhận được thông điệp: {messagePayload} trên chủ đề: {e.ApplicationMessage.Topic}");
            await _hubContext.Clients.All.SendAsync("ReceiveData", messagePayload);
            // Deserialize JSON vào đối tượng C# của bạn
            var deviceStatus = JsonConvert.DeserializeObject<StatusDeviceByFarm>(messagePayload);
            // Sử dụng thông tin trong đối tượng
            Console.WriteLine($"Tên thiết bị: {deviceStatus.Name}");
            Console.WriteLine("Trạng thái của LED:");     
        };
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task ConnectAsync()
    {
        try
        {
            await _client.ConnectAsync(_options);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Connection failed: {ex.Message}");
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task DisconnectAsync()
    {
        await _client.DisconnectAsync();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="topic"></param>
    /// <returns></returns>
    public async Task SubscribeAsync(string topic)
    {
        var topicFilter = new MqttTopicFilter { Topic = topic, QualityOfServiceLevel = MQTTnet.Protocol.MqttQualityOfServiceLevel.AtMostOnce };
        await _client.SubscribeAsync(topicFilter);
        Console.WriteLine($"Đã đăng ký chủ đề {topic}");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="topic"></param>
    /// <returns></returns>
    public async Task UnsubscribeAsync(string topic)
    {
        await _client.UnsubscribeAsync(topic);
        Console.WriteLine($"Unsubscribed from {topic}");
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="topic"></param>
    /// <param name="payload"></param>
    /// <returns></returns>
    public async Task PublishAsync(string topic, DeviceRequestToESP payload)
    {
        string messagePayload = Ulities.SerializeDeviceData(payload);
        var message = new MqttApplicationMessageBuilder()
            .WithTopic(topic)
            .WithPayload(messagePayload)
            .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.ExactlyOnce)
            .Build();

        await _client.PublishAsync(message);
        Console.WriteLine($"Published message to {topic}");
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="e"></param>
    public void HandleReceivedMessage(MqttApplicationMessageReceivedEventArgs e)
    {
        Console.WriteLine($"Received message: {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)} on topic: {e.ApplicationMessage.Topic}");
    }
    public async Task InitializeAsync()
    {
        try
        {
            await _client.ConnectAsync(_options);
            // Đăng ký các topics ở đây nếu cần
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Connection failed: {ex.Message}");
            // Xử lý lỗi nếu cần
        }
    }
}