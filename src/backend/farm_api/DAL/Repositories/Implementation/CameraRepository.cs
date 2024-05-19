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
    public class CameraRepository:GenericRepository<Camera>, ICameraRepository
    {
        public CameraRepository(FarmContext farmContext):base(farmContext) { }

        public async Task<IEnumerable<Camera>> GetAllAsync(CameraQueryDTO cameraQueryDTO, CancellationToken cancellationToken = default)
        {
            return await Filter(cameraQueryDTO).ToListAsync(cancellationToken);
        }

        public async Task<Camera> GetByLocationAsync(string location, CancellationToken cancellationToken = default)
        {
            return await _context.Cameras.FirstOrDefaultAsync(x => x.Location == location,cancellationToken);
        }

        private IQueryable<Camera> Filter(CameraQueryDTO cameraQueryDTO)
        {
            IQueryable<Camera> query = _context.Set<Camera>();
            if (!string.IsNullOrEmpty(cameraQueryDTO.Name))
            {
                query = query.Where(x => x.Name.Contains(cameraQueryDTO.Name));
            }
            if (!string.IsNullOrEmpty(cameraQueryDTO.IPAddress))
            {
                query = query.Where(x => x.IPAddress.Contains(cameraQueryDTO.IPAddress));
            }
            if (cameraQueryDTO.Port >0)
            {
                query = query.Where(x => x.Port == cameraQueryDTO.Port);
            }
            return query;

        }
    }
}
