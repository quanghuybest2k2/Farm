using farm_api.Services.Interface;
using MQTTnet.Client;
using MQTTnet;

namespace farm_api.Services.Implementation
{
    public class MQTTService : IMQTTService
    {
        private readonly IMqttClient _mqttClient;
        public MQTTService()
        {
            var factory = new MqttFactory();
            _mqttClient = factory.CreateMqttClient();

            var options = new MqttClientOptionsBuilder()
                .WithClientId("CSharpClient")
                .WithTcpServer("25b819a37cd6410aac50cb6c8093b3d2.s1.eu.hivemq.cloud", 8883) // Đổi "your_mqtt_broker_address" thành địa chỉ của máy chủ MQTT của bạn
                .WithCredentials("farm3", "Admin@12345") // Thay thế bằng thông tin đăng nhập nếu máy chủ yêu cầu
                .WithTls() // Thêm dòng này để sử dụng kết nối qua TLS/SSL
                .Build();

            _mqttClient.ConnectAsync(options).Wait();
        }
        public async Task PublishAsync(string topic, string payload)
        {
            if (!_mqttClient.IsConnected)
            {
                Console.WriteLine("MQTT client not connected, message not sent.");
                return;
            }

            var message = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(payload)
                .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)
                .Build();

            await _mqttClient.PublishAsync(message);
        }
    }
}
