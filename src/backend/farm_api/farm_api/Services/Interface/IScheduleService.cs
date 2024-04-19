using Core.Constract;
using Core.Entities;
using farm_api.Filter.Farm;
using farm_api.Filter.Schedule;
using farm_api.Models;
using farm_api.Models.Request;
using farm_api.Responses;

namespace farm_api.Services.Interface
{
    public interface IScheduleService
    {
        Task CreateScheduleAsync(ScheduleRequest scheduleRequest, CancellationToken cancellationToken = default);
        Task UpdateScheduleAsync(Guid id, ScheduleRequest scheduleRequest, CancellationToken cancellationToken = default);
        Task DeleteScheduleAsync(Guid id, CancellationToken cancellationToken = default);
        Task<ScheduleDTO> GetScheduleByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<PagedFarmResponse<ScheduleDTO>> GetAllAsync(ScheduleQuery scheduleQuery, IPagingParams pagingParams, CancellationToken cancellationToken = default);

    }
}
