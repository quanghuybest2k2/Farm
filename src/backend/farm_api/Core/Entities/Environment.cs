using Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Environment : BaseEntity,IModifier
    {
        public Environment() :base() { }    
        public  float Temperature { get; set; }//nhiệt độ
        public string SensorLocation { get; set; } // Khu vực 
        public Farm Farm { get; set; }
        public int Humidity { get; set; }// độ ẩm
        public int Brightness { get; set; }// cường đô ánh sáng
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
