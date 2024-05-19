using Core.Constract;
using farm_api.Filter.Device;
using farm_api.Models.Request;
using farm_api.Models;
using farm_api.Responses;
using Core.Queries;
using farm_api.Filter.Camera;
using Core.Entities;

namespace farm_api.Services.Interface
{
    public interface ICameraService
    {
        Task<CameraDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task AddCameraAsync(CameraRequest cameraRequest, CancellationToken cancellationToken = default);
        Task DeleteCameraAsync(Guid id);
        Task UpdateCameraAsync(Guid Id, CameraRequest cameraRequest, CancellationToken cancellationToken = default);
        Task<PagedFarmResponse<CameraDTO>> GetAllAsync(CameraQuery cameraQuery, IPagingParams pagingParams, CancellationToken cancellationToken = default);
        Task<CameraDTO> GetByLocationAsync(string location, CancellationToken cancellationToken = default);
    }
}
