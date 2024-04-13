using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class DeviceRequestToESP
    {
        public Guid Id { get; set; }
        public bool Status { get; set; }// trạng thái thiết bị
        public uint Order { get; set; }// thứ tự xác định thiết bị để điều khiển
    }
}
