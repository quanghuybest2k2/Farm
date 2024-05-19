using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace device_sensor.Model
{
    public class Device
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }
        public bool ConnectionStatus { get; set; }
        public DateTime? CreateAt { get; set; } // no need
        public DateTime? UpdateAt { get; set; }// no need
    }
}
