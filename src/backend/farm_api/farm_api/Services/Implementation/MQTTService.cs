using Core.Constant;
using Core.DTO;
using farm_api.Services.Interface;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Packets;
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

    /// <summary>
    /// 
    /// </summary>
    [Obsolete]
    public MQTTService()
    {
        var factory = new MqttFactory();
        _client = factory.CreateMqttClient();

        _options = new MqttClientOptionsBuilder()
            .WithClientId(Guid.NewGuid().ToString())
             .WithTcpServer(Ulities.HostServerMQTTHiveMQ,Ulities.PortServerMQTTHiveMQ) // Đổi "your_mqtt_broker_address" thành địa chỉ của máy chủ MQTT của bạn
             .WithCredentials(Ulities.AccountMQTTHiveMQ, Ulities.PasswordMQTTHiveMQ) // Thay thế bằng thông tin đăng nhập nếu máy chủ yêu cầu
             .WithTls() // Thêm dòng này để sử dụng kết nối qua TLS/SSL
             .Build() as MqttClientOptions; ;


        // Thiết lập các event handlers
        _client.ConnectedAsync += async e =>
        {
            var topicFilter = new MqttTopicFilter { Topic = "esp8266/ledControl", QualityOfServiceLevel = MQTTnet.Protocol.MqttQualityOfServiceLevel.AtMostOnce };
            await _client.SubscribeAsync(topicFilter);
            Console.WriteLine("Đã kết nối tới MQTT broker.");
        };

        _client.DisconnectedAsync += async e =>
        {
            Console.WriteLine("Đã ngắt kết nối với MQTT broker.");
        };

        _client.ApplicationMessageReceivedAsync += async e =>
        {
            Console.WriteLine($"Nhận được thông điệp: {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)} trên chủ đề: {e.ApplicationMessage.Topic}");
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
}