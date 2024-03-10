using Core.Constract;
using farm_api.Filter.Environment;
using farm_api.Models;

namespace farm_api.Services.Interface
{
    public interface IEnvironmentService
    {
        Task<EnvironmentDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<EnvironmentDTO> AddEnvironmentAsync(EnvironmentDTO environment, CancellationToken cancellationToken = default);
        Task DeleteEnvironmentAsync(Guid id);
        Task UpdateEnvironmentAsync(EnvironmentDTO environment,CancellationToken cancellationToken=default);



    }
}
