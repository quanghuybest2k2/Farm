using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Queries
{
    public class CameraQueryDTO
    {
        public string Name { get; set; }
        public string IPAddress { get; set; }
        public int Port { get; set; }
        public string Location { get; set; }
    }
}
