using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class DeviceSchedule : BaseEntity, IModifier
    {
        public Device Device { get; set; }
        public Guid DeviceId { get; set; }  
        public bool StatusDevice {  get; set; }// để bật tắt thiết bị =>(example) chọn thiết bị để lập lịch để biết thiết bị bật hay tắt
        public Schedule Schedule { get; set; }
        public Guid ScheduleId { get; set; }    
        public DateTime? CreateAt { get ; set ; }
        public DateTime? UpdateAt { get; set; }
    }
}
