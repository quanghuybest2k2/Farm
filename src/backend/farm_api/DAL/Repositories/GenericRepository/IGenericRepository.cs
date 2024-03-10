using Core.Common;
using Core.Constract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.GenericRepository
{
    public interface IGenericRepository<T> where T : class,BaseEntity
    {
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task Delete(Guid Id, T environment);
        void Update(T environment);
        void Insert(T environment);
    }
}
