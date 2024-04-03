using Core.DTO;
using Core.Queries;
using DAL.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Environment = Core.Entities.Environment;

namespace DAL.Repositories.Interface
{
    public interface IEnvironmentRepository : IGenericRepository<Environment>
    {
        Task<IEnumerable<Environment>> GetAllAsync(EnvironmentQueryDTO environmentQueryDTO, CancellationToken cancellationToken = default);
        Task<IEnumerable<TemperatureHumidityStats>> GetAverageTemperatureAndHumidityByLocationAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<EnvironmentStatistics>> GetDailyStatisticsAsync(DateTime ?startDate, DateTime? endDate,CancellationToken cancellationToken=default);
    }
}
