using Core.Entities;

namespace farm_api.Models.Request
{
    public class ScheduleRequest
    {
        public int Type { get; set; }
        public bool Status { get; set; }
        public int StartValue { get; set; }
        public int EndValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }  
        // Khóa ngoại và mối quan hệ với Farm
        public Guid FarmId { get; set; }

        // Khóa ngoại và mối quan hệ với Device
        public Guid DeviceId { get; set; }
    }
}
