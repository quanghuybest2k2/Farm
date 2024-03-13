using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common;

namespace Core.Entities
{
    public class Statistics : BaseEntity,IModifier
    {
        public Statistics() : base() { }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
