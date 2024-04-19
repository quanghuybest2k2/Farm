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
        public string Area { get; set; }
        public string AreaSensor { get; set; }
        public int Device {  get; set; }
        public int StartValue { get; set; }
        public int EndValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

    }
}
