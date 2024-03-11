using DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using DAL.Context;
using Environment = Core.Entities.Environment;
using Microsoft.EntityFrameworkCore;
using DAL.Repositories.GenericRepository;
using Core.Queries;

namespace DAL.Repositories.Implementation
{
    public class EnvironmentRepository : GenericRepository<Environment>, IEnvironmentRepository
    {
        public EnvironmentRepository(FarmContext context) : base(context) { }

        public async Task<IEnumerable<Environment>> GetAllAsync(EnvironmentQueryDTO environmentQueryDTO, CancellationToken cancellationToken = default)
        {
            return await Filter(environmentQueryDTO).ToListAsync(cancellationToken);
        }
        private IQueryable<Environment> Filter(EnvironmentQueryDTO environmentQueryDTO)
        {
            IQueryable<Environment> query = _context.Set<Environment>();
            if (!string.IsNullOrEmpty(environmentQueryDTO.SensorLocation))
            {
                query = query.Where(x => x.SensorLocation.Contains(environmentQueryDTO.SensorLocation));
            }
            if (!(environmentQueryDTO.Brightness is null) && (environmentQueryDTO.Brightness > 0))
            {
                query = query.Where(x => x.Brightness == environmentQueryDTO.Brightness);
            }
            if (!(environmentQueryDTO.AirQuality is null) && environmentQueryDTO.AirQuality > 0)
            {
                query = query.Where(x => x.AirQuality == environmentQueryDTO.AirQuality);
            }
            if (!(environmentQueryDTO.Temperature is null) && environmentQueryDTO.Temperature > 0)
            {
                query = query.Where(x => x.Temperature == environmentQueryDTO.Temperature);
            }
            return query;

        }
    }
}
