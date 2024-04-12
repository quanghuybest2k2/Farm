namespace farm_api.Services.Interface
{
    public interface IMQTTService
    {
        Task PublishAsync(string topic, string payload);
    }
}
