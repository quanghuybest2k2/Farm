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
    /// <summary>
    /// Represents the repository for Farm entities, providing specialized data access functionalities 
    /// beyond the generic repository.
    /// </summary>
    public class FarmRepositorty : GenericRepository<Farm>, IFarmRepositorty
    {
        /// <summary>
        /// Initializes a new instance of the FarmRepository using the specified DbContext.
        /// </summary>
        /// <param name="context">The database context to be used by the repository.</param>
        public FarmRepositorty(FarmContext context) : base(context) { }

        /// <summary>
        /// Asynchronously retrieves all farms that meet the criteria specified in the provided DTO.
        /// </summary>
        /// <param name="farmQueryDTO">The data transfer object containing the query filters.</param>
        /// <param name="cancellationToken">A token for monitoring cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of farms.</returns>
        public async Task<IEnumerable<Farm>> GetAllAsync(FarmQueryDTO farmQueryDTO, CancellationToken cancellationToken = default)
        {
            return await Filter(farmQueryDTO).ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Filters farms based on the specified query parameters.
        /// </summary>
        /// <param name="farmQueryDTO">The DTO containing the filtering criteria.</param>
        /// <returns>An IQueryable of Farm that matches the criteria.</returns>
        private IQueryable<Farm> Filter(FarmQueryDTO farmQueryDTO)
        {
            IQueryable<Farm> query = _context.Set<Farm>().Include(x => x.Devices);

            if (!string.IsNullOrEmpty(farmQueryDTO.Name))
            {
                query = query.Where(x => x.Name.Contains(farmQueryDTO.Name));
            }
            query = query.Select(f => SortByDeviceOrderInFarm(f));
            return query;
        }

        /// <summary>
        /// Sorts the devices within each farm based on their order.
        /// </summary>
        /// <param name="farm">The farm entity to sort devices within.</param>
        /// <returns>A Farm object with devices sorted.</returns>
        private static Farm SortByDeviceOrderInFarm(Farm farm)
        {
            return new Farm()
            {
                Id = farm.Id,
                Name = farm.Name,
                SensorLocation = farm.SensorLocation,
                ControllerCode = farm.ControllerCode,
                DeviceStatusCode = farm.DeviceStatusCode,
                Latitude= farm.Latitude,
                Longitude= farm.Longitude,
                Devices = farm.Devices.OrderBy(d => d.Order).ToList(),
                UpdateAt = farm.UpdateAt,
                CreateAt = farm.CreateAt,
            };
        }

        public async Task<Farm> GetByIdDetailAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Farm>().Include(x => x.Devices).Where(x => x.Id == Id).FirstOrDefaultAsync();
        }
    }
}