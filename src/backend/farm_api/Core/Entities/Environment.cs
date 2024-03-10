using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Environment : BaseEntity,IModifier
    {
        public Environment() 
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public  int Temperature { get; set; }
        public int AirQuality { get; set; }
        public string SensorLocation { get; set; }
        public int Brightness { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
