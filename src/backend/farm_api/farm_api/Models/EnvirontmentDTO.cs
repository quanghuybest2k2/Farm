namespace farm_api.Models
{
    public class EnvironmentDTO
    {
        public Guid Id { get; set; }
        public int Temperature { get; set; }
        public int AirQuality { get; set; }
        public string SensorLocation { get; set; }
        public int Brightness { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
