using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Farm : BaseEntity, IModifier
    {
        public string Name { get; set; }// tên của trang trại
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string SensorLocation { get; set; }// cái này để lấy thông tin môi trường 
        public string ControllerCode {  get; set; }// mã để gửi thông điệp điều khiển thiết bị theo từng farm
        public ICollection<Environment> Environments { get; set; }
        public ICollection<Device> Devices { get; set; }
    }
}
