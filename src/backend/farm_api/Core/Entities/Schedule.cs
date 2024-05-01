using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Schedule : BaseEntity, IModifier
    {
        public int Type { get; set; }
        public int StartValue { get; set; }
        public int EndValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        // Khóa ngoại và mối quan hệ với Farm
        public Guid FarmId { get; set; }
        public Farm Farm { get; set; }    
        public ICollection<DeviceSchedule> DeviceSchedules { get; set; }// nhiều thiết bị

    }
}
