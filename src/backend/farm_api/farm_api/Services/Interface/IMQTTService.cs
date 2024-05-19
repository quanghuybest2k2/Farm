using Core.DTO;
using MQTTnet.Client;

namespace farm_api.Services.Interface
{
    public interface IMQTTService
    {
        bool IsConnected { get; }
        Task ConnectAsync();
        Task DisconnectAsync();
        Task SubscribeAsync(string topic);
        Task UnsubscribeAsync(string topic);
        Task PublishAsync(string topic, DeviceRequestToESP payload);
        void HandleReceivedMessage(MqttApplicationMessageReceivedEventArgs e);
        Task InitializeAsync();
        Task PublishAsync(string topic, object payload);
    }
}
