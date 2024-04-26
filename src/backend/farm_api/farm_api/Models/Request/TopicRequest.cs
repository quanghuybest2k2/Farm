using Core.DTO;

namespace farm_api.Models.Request
{
    public class TopicRequest
    {
        public string TopicName { get; set; }//controller code board
        public DeviceRequestToESP Payload { get; set; }
    }
}
