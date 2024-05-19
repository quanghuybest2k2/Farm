using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class TemperatureHumidityStats
    {
        public string SensorLocation { get; set; }
        public double AverageTemperature { get; set; }
        public double AverageHumidity { get; set; }
        public double AverageAirQuality { get; set; }
        public double AverageBrightness { get; set; }
    }
}
