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
    public interface IFarmRepositorty:IGenericRepository<Farm>
    {
        Task<IEnumerable<Farm>> GetAllAsync(FarmQueryDTO farmQueryDTO,CancellationToken cancellationToken = default);
        Task<Farm> GetByIdDetailAsync(Guid Id, CancellationToken cancellationToken = default);
    }
}
