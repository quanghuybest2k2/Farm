using Core.Entities;
using Core.Queries;
using DAL.Context;
using DAL.Repositories.GenericRepository;
using DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Implementation
{
    public class DeviceRepository:GenericRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(FarmContext farmContext):base(farmContext) { }

        public  async Task<IEnumerable<Device>> GetAllAsync(DeviceQueryDTO deviceQueryDTO, CancellationToken cancellationToken = default)
        {
            return await Filter(deviceQueryDTO).ToListAsync(cancellationToken);
        }

        public async Task<Device> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Device>().FindAsync(id);
        }

        private IQueryable<Device> Filter(DeviceQueryDTO deviceQueryDTO)
        {
            IQueryable<Device> query = _context.Set<Device>();
            if (!string.IsNullOrEmpty(deviceQueryDTO.Name))
            {
                query = query.Where(x => x.Name.Contains(deviceQueryDTO.Name));
            }
            if (!string.IsNullOrEmpty(deviceQueryDTO.Type))
            {
                query = query.Where(x => x.Type.Contains(deviceQueryDTO.Type));
            }
            if (!(deviceQueryDTO.Status is null))
            {
                query = query.Where(x => x.Status==deviceQueryDTO.Status);
            }
            return query;

        }
    }
}
