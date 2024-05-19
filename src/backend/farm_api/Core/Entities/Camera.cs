using Core.Common;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Camera : BaseEntity, IModifier
    {
        public Camera() : base() { }
        public string Name { get; set; }
        public string IPAddress { get; set; }
        public int Port { get; set; }
        public string Location { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string StaticFileStream {  get; set; }
    }
}
