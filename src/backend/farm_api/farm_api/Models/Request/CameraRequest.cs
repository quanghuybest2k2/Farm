namespace farm_api.Models.Request
{
    public class CameraRequest
    {
        public string Name { get; set; }
        public string IPAddress { get; set; }
        public int Port { get; set; }
        public string Location { get; set; }
    }
}
