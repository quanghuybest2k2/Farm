using farm_api.Models.Common;

namespace farm_api.Models
{
    public class ScheduleDTO:BaseDTO
    {
        public int Type { get; set; }
        public string Area { get; set; }
        public string AreaSensor { get; set; }
        public int Device { get; set; }
        public int StartValue { get; set; }
        public int EndValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
