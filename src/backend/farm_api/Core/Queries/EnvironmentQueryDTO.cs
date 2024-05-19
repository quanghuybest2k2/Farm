using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Queries
{
    public class EnvironmentQueryDTO
    {
        public int? Temperature { get; set; }
        public int? AirQuality { get; set; }
        public string SensorLocation { get; set; }
        public int? Brightness { get; set; }
        public int? Humidity { get; set; }
    }
}
