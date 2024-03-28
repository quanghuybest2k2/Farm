namespace farm_api.Models.Request
{
    public class DeviceInfoRequest
    {
        public DeviceInfoRequest() { }
        public string Id { get; set; } 
        public string DeviceName { get; set; } 
        public string Type { get; set; } 
        public bool Status { get; set; } 
    }
}
