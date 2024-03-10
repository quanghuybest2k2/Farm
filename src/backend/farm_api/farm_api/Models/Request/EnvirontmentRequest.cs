namespace farm_api.Models.Request
{
    public class EnvirontmentRequest
    {
        public int Temperature { get; set; }
        public int AirQuality { get; set; }
        public string SensorLocation { get; set; }
        public int Brightness { get; set; }
    }
}
