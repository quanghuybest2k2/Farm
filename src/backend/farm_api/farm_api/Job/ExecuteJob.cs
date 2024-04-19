using farm_api.Services.Interface;
using MQTTnet.Packets;
using Quartz;

namespace farm_api.Job
{
    public class ExecuteJob : IJob
    {
        public readonly IMQTTService _mqttPushService;
        public readonly ILogger<ExecuteJob> _logger;

        public ExecuteJob(IMQTTService mqttPushService, ILogger<ExecuteJob> logger)
        {
            _mqttPushService = mqttPushService;
            _logger = logger;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            await Console.Out.WriteLineAsync("excute task 1");
            var dataMap = context.JobDetail.JobDataMap;

            int type = dataMap.GetInt("Type");
            string area = dataMap.GetString("Area");// controller code
            int device = dataMap.GetInt("Device");// device order
            string areaSensor = dataMap.GetString("AreaSensor");
            int valueStart = dataMap.GetInt("StartValue");
            int valueEnd = dataMap.GetInt("EndValue");
            _logger.LogInformation($"information is sent  to MQTT : =>" +
            $" type : {type} : area : {area} : device : {device} : areaSensor : {areaSensor} : StartValue : {valueStart} : EndValue : {valueEnd}");
            var payload = new
            {
                Type = type,
                Area = area,
                Device = device,
                ValueStart = valueStart,
                ValueEnd = valueStart,
                AreaSensor = areaSensor

            };
            await Console.Out.WriteLineAsync("");
            string topic = $"control/{payload.AreaSensor}";
            if (!_mqttPushService.IsConnected)
            {
                await _mqttPushService.ConnectAsync();
            }
            await _mqttPushService.PublishAsync(topic, payload);
            _logger.LogInformation("MQTT message sent successfully.");
        }
    }
}
