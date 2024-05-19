using Core.DTO;
using Core.Entities;

namespace farm_api.Models.Request
{
    public class ScheduleRequest
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public int StartValue { get; set; }
        public int EndValue { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool IsActive { get; set; }  
        // Khóa ngoại và mối quan hệ với Farm
        public Guid FarmId { get; set; }
        public IEnumerable<DeviceCMD> Devices { get; set; }
    }
}
