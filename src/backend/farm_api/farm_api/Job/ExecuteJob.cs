using Core.DTO;
using Core.Entities;
using DAL.Repositories.Interface;
using farm_api.Services.Interface;
using MQTTnet.Packets;
using Newtonsoft.Json;
using Quartz;
using System.Collections;
using System.Text;

namespace farm_api.Job
{
    public class ExecuteJob : IJob
    {
        public readonly IMQTTService _mqttPushService;
        public readonly ILogger<ExecuteJob> _logger;
        private readonly IScheduleRepository _scheduleRepository;

        public ExecuteJob(IScheduleRepository scheduleRepository, IMQTTService mqttPushService, ILogger<ExecuteJob> logger)
        {
            _scheduleRepository = scheduleRepository;   
            _mqttPushService = mqttPushService;
            _logger = logger;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            await Console.Out.WriteLineAsync("excute task test");
            var dataMap = context.JobDetail.JobDataMap;
            int type = dataMap.GetInt("Type");
            var scheduleId = dataMap.GetGuid("ScheduleId");
            int valueStart = dataMap.GetInt("StartValue");
            int valueEnd = dataMap.GetInt("EndValue");
            var schedule= await _scheduleRepository.GetByIdDetailAsync(scheduleId);
            IEnumerable<DeviceSendMQTT> devices = GetDevices(schedule);
            _logger.LogInformation($"information is sent  to MQTT : =>" +
            $" type : {type} : area : {schedule.Farm.SensorLocation} : device : {null} : areaSensor : {schedule.Farm.SensorLocation} : StartValue : {valueStart} : EndValue : {valueEnd}");
            var payload = new
            {
                T = type, // Type
                A = schedule.Farm.SensorLocation, // Area and AreaSensor combined
                D = devices, // Device, consider compressing or simplifying
                VS = valueStart, // ValueStart
                VE = valueEnd, // ValueEnd
            };
            await SendDeviceGroups(devices,schedule,type,valueStart,valueEnd);
            string topic = $"schedule/{payload.A}";
            await Console.Out.WriteLineAsync($"topic da gui=>{topic}");
            _logger.LogInformation("MQTT message sent successfully.");
        }
        private IEnumerable<DeviceSendMQTT> GetDevices(Schedule schedule)
        {
            return schedule.DeviceSchedules.Select(item => new DeviceSendMQTT
            {
                Order = (byte)(item.Device.Order & 0x7F), // Đảm bảo Order không quá 127
                Status = item.StatusDevice
            });
        }
        private async Task SendDeviceGroups(IEnumerable<DeviceSendMQTT> devices, Schedule schedule, int type, int valueStart, int valueEnd)
        {
            // Đảm bảo kết nối MQTT
            if (!_mqttPushService.IsConnected)
            {
                await _mqttPushService.ConnectAsync();
            }

            // Tách danh sách thiết bị thành các nhóm nhỏ
            int batchSize = 2; // Số lượng thiết bị tối đa trong một nhóm
            var deviceGroups = devices.Select((device, index) => new { Device = device, Index = index })
                                      .GroupBy(x => x.Index / batchSize)
                                      .Select(g => g.Select(x => x.Device).ToList());

            // Gửi thông tin cho mỗi nhóm
            foreach (var group in deviceGroups)
            {
                // Tạo payload cho nhóm hiện tại
                var payload = new
                {
                    T = type,
                    A = schedule.Farm.SensorLocation,
                    D = group, // Gửi nhóm thiết bị hiện tại
                    VS = valueStart,
                    VE = valueEnd
                };

                string topic = $"schedule/{payload.A}";
                // Log thông tin gửi đi
                _logger.LogInformation($"Sending information to MQTT : => type : {type} : area : {schedule.Farm.SensorLocation} : devices : {group.Count} : StartValue : {valueStart} : EndValue : {valueEnd}");

                // Gửi payload
                await _mqttPushService.PublishAsync(topic, payload);
            }
        }
    }
}
