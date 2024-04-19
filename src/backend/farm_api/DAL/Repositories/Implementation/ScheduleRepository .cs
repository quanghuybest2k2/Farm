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
        private IQueryable<Schedule> Filter(ScheduleQueryDTO scheduleQueryDTO)
        {
            IQueryable<Schedule> query = _context.Set<Schedule>();
            #region Condition Filter
            if (scheduleQueryDTO.Type > 0)
            {
                query = query.Where(x => x.Type == scheduleQueryDTO.Type);
            }
            if (scheduleQueryDTO.Device >= 0)
            {
                query = query.Where(x => x.Device == scheduleQueryDTO.Device);
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
                query = query.Where(x => x.AreaSensor == scheduleQueryDTO.AreaSensor);
            }
            if (!string.IsNullOrEmpty(scheduleQueryDTO.Area))
            {
                query = query.Where(x => x.Area == scheduleQueryDTO.Area);
            }
            #endregion
            return query;
        }
    }
}
