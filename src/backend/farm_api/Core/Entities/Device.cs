using Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Device :BaseEntity, IModifier
    {
        public string Name { get; set; }
        public string Type { get; set; }// loại thiết bị
        public bool Status { get; set; }// trạng thái thiết bị
        public uint Order { get; set; }// thứ tự xác định thiết bị để điều khiển
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public Farm Farm { get; set; }
        public Guid FarmId { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}
