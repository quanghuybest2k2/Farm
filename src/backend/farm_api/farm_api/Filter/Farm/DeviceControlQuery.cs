using Microsoft.AspNetCore.Mvc;

namespace farm_api.Filter.Farm
{
    public class DeviceControlQuery
    {
        public string FarmId { get; set; }
        public string DeviceId { get; set; }
        public bool Action { get; set; }
    }
}
