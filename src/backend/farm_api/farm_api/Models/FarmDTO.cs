using Core.Entities;
using farm_api.Models.Common;

namespace farm_api.Models
{
    public class FarmDTO:BaseDTO
    {
        public string Name { get; set; }// tên của trang trại
        public string SensorLocation { get; set; }// cái này để lấy thông tin môi trường 
        public string ControllerCode { get; set; }// mã để gửi thông điệp điều khiển thiết bị theo từng farm
        public ICollection<DeviceDTO> Devices { get; set; }
        public int Active { get { return Devices.Where(x => x.Status==true).Count(); } }
        public int Off { get { return Devices.Where(x => x.Status == false).Count(); } }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

    }
}
