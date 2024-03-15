using farm_api.Models.Common;

namespace farm_api.Models
{
    public class CameraDTO:BaseDTO
    {
        public string Name { get; set; }
        public string IPAddress { get; set; }
        public int Port { get; set; }
        public string Location { get; set; }
    }
}
