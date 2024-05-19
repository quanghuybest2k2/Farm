using Core.DTO;
using Core.Entities;
using DAL.Context;
using DAL.Repositories.GenericRepository;
using DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Implementation
{
    public class DeviceScheduleRepository : GenericRepository<DeviceSchedule>, IDeviceScheduleRepository
    {
        public DeviceScheduleRepository(FarmContext context) : base(context)
        {
        }

    }
}
