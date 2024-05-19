using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class StatusDeviceByFarm
    {
        public string Name {  get; set; }
        public IList<bool> Status { get; set; }
    }
}
