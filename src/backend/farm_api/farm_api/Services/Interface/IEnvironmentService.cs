using Core.Constract;
using farm_api.Filter.Environment;
using farm_api.Models;
using farm_api.Models.Request;

namespace farm_api.Services.Interface
{
    public interface IEnvironmentService
    {
        Task<EnvironmentDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task AddEnvironmentAsync(EnvirontmentRequest environment, CancellationToken cancellationToken = default);
        Task DeleteEnvironmentAsync(Guid id);
        Task UpdateEnvironmentAsync(Guid Id,EnvirontmentRequest environment,CancellationToken cancellationToken=default);



    }
}
