using Core.Entities;
using farm_api.Models.Common;

namespace farm_api.Models
{
    public class DeviceScheduleDTO:BaseDTO
    {
        public DeviceDTO Device { get; set; }
        public Guid DeviceId { get; set; }
        public bool StatusDevice { get; set; }
        public Guid ScheduleId { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
