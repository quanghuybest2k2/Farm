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
            return query;
        }
    }
}
