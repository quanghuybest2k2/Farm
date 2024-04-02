using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace device_sensor.Model.Response
{
    public class Device
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }
        public bool ConnectionStatus { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string  FarmId { get; set; }
        private static Func<bool, string> Convert = e => e ? "bật" : "tắt";
        public override string ToString()
        {
            return $"{Id} {Type} {Name} {Convert(Status)} ";
        }
    }
}
