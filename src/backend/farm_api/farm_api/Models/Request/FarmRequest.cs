using Core.Entities;

namespace farm_api.Models.Request
{
    public class FarmRequest
    {
        public string Name { get; set; }// tên của trang trại
        public string SensorLocation { get; set; }// cái này để lấy thông tin môi trường 
        public string ControllerCode { get; set; }// mã để gửi thông điệp điều khiển thiết bị theo từng farm
    }
}
