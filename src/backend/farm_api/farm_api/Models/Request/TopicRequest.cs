using Core.DTO;

namespace farm_api.Models.Request
{
    /// <summary>
    /// 
    /// </summary>
    public class TopicRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public string TopicName { get; set; }//controller code board
        /// <summary>
        /// 
        /// </summary>
        public DeviceRequestToESP Payload { get; set; }
    }
}
