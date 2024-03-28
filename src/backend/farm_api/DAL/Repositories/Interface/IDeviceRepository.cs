using Core.Entities;
using Core.Queries;
using DAL.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interface
{
    public interface IDeviceRepository:IGenericRepository<Device>
    {
        Task<IEnumerable<Device>> GetAllAsync(DeviceQueryDTO deviceQueryDTO, CancellationToken cancellationToken = default);
        Task<Device> GetByIdAsync(string id,CancellationToken cancellationToken=default);
    }
}
