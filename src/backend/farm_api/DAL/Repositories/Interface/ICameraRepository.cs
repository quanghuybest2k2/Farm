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
    public interface ICameraRepository:IGenericRepository<Camera>
    {
        Task<IEnumerable<Camera>> GetAllAsync(CameraQueryDTO cameraQueryDTO, CancellationToken cancellationToken = default);

    }
}
