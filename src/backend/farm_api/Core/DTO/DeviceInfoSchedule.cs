using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class DeviceInfoSchedule
    {
        public Guid DeviceId { get; set; }
        public bool StatusDevice { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }// loại thiết bị    
        public uint Order { get; set; }// thứ tự xác định thiết bị để điều khiển
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public Guid FarmId { get; set; }
        public Guid ScheduleId { get; set; }     
    }
}
