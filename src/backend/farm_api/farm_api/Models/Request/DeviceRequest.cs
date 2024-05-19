using Core.Entities;
using Microsoft.Identity.Client;

namespace farm_api.Models.Request
{
    public class DeviceRequest
    {
        public string Name { get; set; }
        public string Type { get; set; }// loại thiết bị
        public bool Status { get; set; }// trạng thái thiết bị
        public uint Order { get; set; }// thứ tự xác định thiết bị để điều khiển
        public Guid FarmId { get; set; }
        public override string ToString()
        {
            return $"/n{Name} {Type} {Status}";
        }
    }
}
