using Core.Constract;
using Core.DTO;
using farm_api.Filter.Environment;
using farm_api.Models;
using farm_api.Models.Request;
using farm_api.Responses;

namespace farm_api.Services.Interface
{
    public interface IEnvironmentService
    {
        Task<IEnumerable<EnvironmentAverageData>> GetAverageEnvironmentValues(
        string sensorLocation,
        DateTime startDate,
        DateTime endDate,
        CancellationToken cancellationToken = default);
        Task<EnvironmentDTO> GetEnvironmentBySensorLocatonRecentDays(string sensorLocation, CancellationToken cancellationToken = default);
        Task<EnvironmentDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task AddEnvironmentAsync(EnvirontmentRequest environment, CancellationToken cancellationToken = default);
        Task DeleteEnvironmentAsync(Guid id);
        Task UpdateEnvironmentAsync(Guid Id,EnvirontmentRequest environment,CancellationToken cancellationToken=default);
        Task<PagedFarmResponse<EnvironmentDTO>> GetAllAsync(EnvironmentQuery environmentQuery,IPagingParams pagingParams, CancellationToken cancellationToken = default);
        Task<IEnumerable<TemperatureHumidityStats>> GetAverageTemperatureAndHumidityByLocationAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<EnvironmentDTO>> GetEnvironmentsByLocationAndCreationDay(string sensorLocation, DateTime targetDate, CancellationToken cancellationToken = default);
    }
}