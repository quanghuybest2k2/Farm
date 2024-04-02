using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace device_sensor.Model.Response
{
    public class DeviceDTO
    {
        public DeviceDTO() { }  
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }
        public bool ConnectionStatus { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public Guid FarmId { get; set; }
        private static Func<bool, string> Convert = e => e ? "bật" : "tắt";
        public override string ToString()
        {
            return $"{Id} {Type} {Name} {Convert(Status)} ";
        }
    }
}
