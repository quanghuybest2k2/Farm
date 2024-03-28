using Microsoft.Identity.Client;

namespace farm_api.Models.Request
{
    public class DeviceRequest
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }
        public override string ToString()
        {
            return $"/n{Name} {Type} {Status}";
        }
    }
}
