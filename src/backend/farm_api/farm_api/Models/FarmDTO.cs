using Core.Entities;
using farm_api.Models.Common;

namespace farm_api.Models
{
    public class FarmDTO:BaseDTO
    {
        public string Name { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public ICollection<DeviceDTO> Devices { get; set; }
        public int Active { get { return Devices.Where(x => x.Status==true).Count(); } }
        public int Off { get { return Devices.Where(x => x.Status == false).Count(); } }

    }
}
