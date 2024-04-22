using Core.Entities;

namespace farm_api.Models.Request
{
    public class FarmRequest
    {
        public string Name { get; set; }// tên của trang trại
        public string SensorLocation { get; set; }// cái này để lấy thông tin môi trường 
        public decimal Latitude { get; set; }// kinh độ
        public decimal Longitude { get; set; }// vĩ độ
        public string ControllerCode { get; set; }// mã để gửi thông điệp điều khiển thiết bị theo từng farm
        public string DeviceStatusCode { get; set; }// mã để biết làm realtime trạng thái thiết bị 
    }
}
