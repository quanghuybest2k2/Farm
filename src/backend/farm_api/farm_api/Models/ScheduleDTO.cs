using Core.Entities;
using farm_api.Models.Common;

namespace farm_api.Models
{
    public class ScheduleDTO:BaseDTO
    {
        public int Type { get; set; }
        public bool Status { get; set; }
        public int StartValue { get; set; }
        public int EndValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        // Khóa ngoại và mối quan hệ với Farm
        public Guid FarmId { get; set; }
        public FarmDTO Farm { get; set; }

        // Khóa ngoại và mối quan hệ với Device
        public Guid DeviceId { get; set; }
        public DeviceDTO Device { get; set; }
    }
}
