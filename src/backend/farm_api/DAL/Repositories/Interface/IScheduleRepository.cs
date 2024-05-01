using Core.DTO;
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
    public interface IScheduleRepository:IGenericRepository<Schedule>
    {
        Task<IEnumerable<Schedule>> GetAllAsync(ScheduleQueryDTO scheduleQueryDTO, CancellationToken cancellationToken = default);
        Task<Schedule> GetByIdDetailAsync(Guid Id, CancellationToken cancellationToken = default);

        Task<IEnumerable<DeviceJob>> GetDevices(Guid ScheduleId, CancellationToken cancellationToken = default);
    }
}
