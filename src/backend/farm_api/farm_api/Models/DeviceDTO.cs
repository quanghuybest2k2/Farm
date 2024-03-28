using farm_api.Models.Common;

namespace farm_api.Models
{
    public class DeviceDTO
    {
        public string Id {  get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }
        public bool ConnectionStatus { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
