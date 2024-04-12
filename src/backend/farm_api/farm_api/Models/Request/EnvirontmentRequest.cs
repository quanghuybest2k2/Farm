using Core.Entities;

namespace farm_api.Models.Request
{
    public class EnvirontmentRequest
    {
        public float Temperature { get; set; }//nhiệt độ
        public string SensorLocation { get; set; } // Khu vực 
        public int Humidity { get; set; }// độ ẩm
        public int Brightness { get; set; }// cường đô ánh sáng
    }
}
