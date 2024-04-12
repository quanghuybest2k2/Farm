using Core.Entities;
using farm_api.Models.Common;

namespace farm_api.Models
{
    public class EnvironmentDTO:BaseDTO
    {
        public float Temperature { get; set; }//nhiệt độ
        public string SensorLocation { get; set; } // Khu vực  cái này khóa để biết thông tin này thuộc nông trại nào
        public int Humidity { get; set; }// độ ẩm
        public int Brightness { get; set; }// cường đô ánh sáng
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
