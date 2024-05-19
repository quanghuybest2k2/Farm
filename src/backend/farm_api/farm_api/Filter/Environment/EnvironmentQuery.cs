namespace farm_api.Filter.Environment
{
    public class EnvironmentQuery
    {
        public int?Temperature { get; set; }
        public int? AirQuality { get; set; }
        public string SensorLocation { get; set; }
        public int? Brightness { get; set; }
        public int? Humidity { get; set; }
    }
}
