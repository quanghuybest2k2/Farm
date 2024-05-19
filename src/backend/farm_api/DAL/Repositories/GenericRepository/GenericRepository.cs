using Core.Common;
using Core.Constract;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.GenericRepository
{
    public abstract class GenericRepository<T>: IGenericRepository<T> where T : BaseEntity
    {
        protected readonly FarmContext _context;
        protected GenericRepository(FarmContext context)
        {
            _context = context;
        }
        public async Task Delete(object Id)
        {
            _context.Remove(await GetByIdAsync(Id));
        }

        public async Task DeleteAsync(object ob)
        {
            _context.Remove(ob);
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().ToListAsync();  
        }

        public async Task<T> GetByIdAsync(object id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Insert(T environment)
        {
            _context.Add(environment);
        }
        public void Update(T environment)
        {
            _context.Update(environment);

        }
    }
}
