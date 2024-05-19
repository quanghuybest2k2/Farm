using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Queries
{
    public class ScheduleQueryDTO
    {
        public int Type { get; set; }
        public string Area { get; set; }
        public string AreaSensor { get; set; }
        public int Device { get; set; }
        public bool Status { get; set; }
        public int StartValue { get; set; }
        public int EndValue { get; set; }
        public bool? IsActive { get; set; }
    }
}
