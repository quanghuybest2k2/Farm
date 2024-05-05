using Core.DTO;
using Core.Entities;
using Core.Queries;
using DAL.Context;
using DAL.Repositories.GenericRepository;
using DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Implementation
{
    public class ScheduleRepository : GenericRepository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(FarmContext context) : base(context) { }

        public async Task<IEnumerable<Schedule>> GetAllAsync(ScheduleQueryDTO scheduleQueryDTO, CancellationToken cancellationToken = default)
        {
            return await Filter(scheduleQueryDTO).ToListAsync(cancellationToken);
        }
        public async Task<Schedule> GetByIdDetailAsync(Guid Id,CancellationToken cancellationToken=default)
        {
            return await _context.Set<Schedule>().AsNoTracking().Include(x=>x.DeviceSchedules).ThenInclude(x=>x.Device).AsNoTracking().Include(x=>x.Farm).AsNoTracking().Where(x=>x.Id==Id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<DeviceJob>> GetDevices(Guid ScheduleId, CancellationToken cancellationToken = default)
        {
            var deviceSchedules =  await _context.Schedules.Where(x => x.Id == ScheduleId).FirstOrDefaultAsync(cancellationToken);
            if (deviceSchedules == null) { throw new KeyNotFoundException(); }
            return deviceSchedules.DeviceSchedules.Select(x=>new DeviceJob() { Order=x.Device.Order,Status=x.StatusDevice}).ToList();
        }

        private IQueryable<Schedule> Filter(ScheduleQueryDTO scheduleQueryDTO)
        {
            IQueryable<Schedule> query = _context.Set<Schedule>().Include(x=>x.DeviceSchedules).ThenInclude(x=>x.Device).Include(x=>x.Farm);
            #region Condition Filter
            if (scheduleQueryDTO.Type > 0)
            {
                query = query.Where(x => x.Type == scheduleQueryDTO.Type);
            }
           
            if (scheduleQueryDTO.StartValue > 0)
            {
                query = query.Where(x => x.StartValue == scheduleQueryDTO.StartValue);
            }
            if (scheduleQueryDTO.EndValue > 0)
            {
                query = query.Where(x => x.EndValue == scheduleQueryDTO.EndValue);
            }
            if (scheduleQueryDTO.EndValue > 0)
            {
                query = query.Where(x => x.EndValue == scheduleQueryDTO.EndValue);
            }
            if (!(scheduleQueryDTO.IsActive is null))
            {
                query = query.Where(x => x.IsActive == scheduleQueryDTO.IsActive);
            }
            if (!string.IsNullOrEmpty(scheduleQueryDTO.AreaSensor))
            {
                query = query.Where(x => x.Farm.SensorLocation == scheduleQueryDTO.AreaSensor);
            }
            if (!string.IsNullOrEmpty(scheduleQueryDTO.Area))
            {
                query = query.Where(x => x.Farm.SensorLocation == scheduleQueryDTO.Area);
            }
            #endregion
            return query;
        }
    }
}
