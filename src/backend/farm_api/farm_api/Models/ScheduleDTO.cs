using Core.DTO;
using Core.Entities;
using farm_api.Models.Common;
using System.Text.Json.Serialization;

namespace farm_api.Models
{
    public class ScheduleDTO:BaseDTO
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public int StartValue { get; set; }
        public int EndValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string FarmName { get; set; }
        // Khóa ngoại và mối quan hệ với Farm
        public Guid FarmId { get; set; }
        public ICollection<DeviceInfoSchedule> DeviceSchedules { get; set; }// nhiều thiết bị
    }
}
