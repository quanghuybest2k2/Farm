﻿using Core.DTO;
using Core.Entities;
using DAL.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interface
{
    public interface IDeviceScheduleRepository:IGenericRepository<DeviceSchedule>
    {
    }
}
