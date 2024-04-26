using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class DeviceTrans
    {
        public Guid Id {  get; set; }
        public uint Order {  get; set; }
        public Guid FarmId {  get; set; }
    }
}
