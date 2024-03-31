using Core.Constract;
using farm_api.Filter.Environment;
using farm_api.Models.Request;
using farm_api.Models;
using farm_api.Responses;
using farm_api.Filter.Device;

namespace farm_api.Services.Interface
{
    public interface IDeviceService
    {
        Task<DeviceDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<DeviceDTO> GetByIdAsync(string id, CancellationToken cancellationToken = default);

        Task AddDeviceAsync(DeviceRequest deviceRequest, CancellationToken cancellationToken = default);
        Task DeleteDeviceAsync(string id);
        Task UpdateDeviceAsync(string Id, DeviceRequest  deviceRequest, CancellationToken cancellationToken = default);
        Task<PagedFarmResponse<DeviceDTO>> GetAllAsync(DeviceQuery environmentQuery, IPagingParams pagingParams, CancellationToken cancellationToken = default);
    }
}
