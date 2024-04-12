using Microsoft.AspNetCore.Mvc;

namespace farm_api.Filter.Farm
{
    public class DeviceControlQuery
    {
        public Guid FarmId { get; set; }
        public Guid DeviceId { get; set; }
        public bool Action { get; set; }
    }
}
