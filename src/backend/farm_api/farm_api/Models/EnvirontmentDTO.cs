using farm_api.Models.Common;

namespace farm_api.Models
{
    public class EnvironmentDTO:BaseDTO
    {
        public int Temperature { get; set; }
        public int AirQuality { get; set; }
        public string SensorLocation { get; set; }
        public int Brightness { get; set; }
        public int Humidity { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
