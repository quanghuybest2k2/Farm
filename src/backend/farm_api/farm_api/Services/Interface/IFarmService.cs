using Core.Constract;
using farm_api.Filter.Environment;
using farm_api.Models.Request;
using farm_api.Models;
using farm_api.Responses;
using farm_api.Filter.Farm;

namespace farm_api.Services.Interface
{
    public interface IFarmService
    {
        Task<FarmDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task AddFarmAsync(FarmRequest farmRequest, CancellationToken cancellationToken = default);
        Task DeleteFarmAsync(Guid id);
        Task UpdateFarmAsync(Guid Id, FarmRequest farmRequest, CancellationToken cancellationToken = default);
        Task<PagedFarmResponse<FarmDTO>> GetAllAsync(FarmQuery farmQuery, IPagingParams pagingParams, CancellationToken cancellationToken = default);
    }
}
