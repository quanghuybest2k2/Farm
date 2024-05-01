using Core.Entities;
using farm_api.Models.Common;

namespace farm_api.Models
{
    public class DeviceDTO:BaseDTO
    {
        public string Name { get; set; }
        public string Type { get; set; }// loại thiết bị
        public bool Status { get; set; }// trạng thái thiết bị
        public uint Order { get; set; }// thứ tự xác định thiết bị để điều khiển
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string ControllerCode { get; set; }// cái để cho thiết bị biết mã để điều khiển cần phải mapper
        public Guid FarmId { get; set; }
        public ICollection<DeviceScheduleDTO> DeviceSchedules { get; set; }
    }
}
