using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Queries
{
    public class DeviceQueryDTO
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool? Status { get; set; }
    }
}
