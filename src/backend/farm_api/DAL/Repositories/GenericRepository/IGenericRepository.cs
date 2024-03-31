using Core.Common;
using Core.Constract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(object id, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task Delete(object Id);
        void Update(T environment);
        void Insert(T environment);
    }
}
