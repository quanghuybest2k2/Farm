using Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Device : IModifier
    {
        public Device()
        {
            Id=Guid.NewGuid().ToString();
        }
        [Key]
        public string Id {  get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }
        public bool ConnectionStatus { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public Farm Farm { get; set; }
        public Guid FarmId { get; set; }    
    }
}
