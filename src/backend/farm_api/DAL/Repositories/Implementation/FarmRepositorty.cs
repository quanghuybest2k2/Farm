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
    public class FarmRepositorty : GenericRepository<Farm>, IFarmRepositorty
    {
        public FarmRepositorty(FarmContext context) : base(context) { }

        public async Task<IEnumerable<Farm>> GetAllAsync(FarmQueryDTO farmQueryDTO, CancellationToken cancellationToken = default)
        {
            return await Filter(farmQueryDTO).ToListAsync(cancellationToken);
        }
        private IQueryable<Farm> Filter(FarmQueryDTO farmQueryDTO)
        {
            IQueryable<Farm> query = _context.Set<Farm>().Include(x=>x.Devices);
            if (!string.IsNullOrEmpty(farmQueryDTO.Name))
            {
                query = query.Where(x => x.Name.Contains(farmQueryDTO.Name));
            }
            return query;
        }
    }
}
