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
        Task<IEnumerable<Environment>> GetEnvironmentsByLocationAndCreationDay(string sensorLocation,DateTime targetDate,CancellationToken cancellationToken = default);
        Task<Environment> GetEnvironmentBySensorLocatonRecentDays(string sensorLocation, CancellationToken cancellationToken = default);
        Task<IEnumerable<EnvironmentAverageData>> GetAverageEnvironmentValues(
        string sensorLocation,
        DateTime startDate,
        DateTime endDate,
        CancellationToken cancellationToken = default);
    }
}
