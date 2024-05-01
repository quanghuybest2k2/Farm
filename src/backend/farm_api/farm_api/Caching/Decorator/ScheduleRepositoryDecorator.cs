using Core.DTO;
using Core.Entities;
using Core.Queries;
using DAL.Repositories.Interface;
using farm_api.Caching.Interface;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace farm_api.Caching.Decorator
{
    public class ScheduleRepositoryDecorator : IScheduleRepository
    {
        private readonly IScheduleRepository _innerRepository;
        private readonly ICache _cache;
        private readonly TimeSpan _cacheDuration = TimeSpan.FromMinutes(5);

        public ScheduleRepositoryDecorator(IScheduleRepository innerRepository, ICache cache)
        {
            _innerRepository = innerRepository;
            _cache = cache;
        }

        public async Task<IEnumerable<Schedule>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _innerRepository.GetAllAsync(cancellationToken);
        }

        public async Task<IEnumerable<Schedule>> GetAllAsync(ScheduleQueryDTO scheduleQueryDTO, CancellationToken cancellationToken = default)
        {
            // Implement caching based on the query parameters if feasible
            var cacheKey = $"Schedules-{scheduleQueryDTO.GetHashCode()}";
            if (_cache.TryGetValue(cacheKey, out IEnumerable<Schedule> cachedResult))
            {
                return cachedResult;
            }

            var result = await _innerRepository.GetAllAsync(scheduleQueryDTO, cancellationToken);
            _cache.Set(cacheKey, result, _cacheDuration);
            return result;
        }

        public async Task<Schedule> GetByIdDetailAsync(Guid Id, CancellationToken cancellationToken = default)
        {
            var cacheKey = $"ScheduleDetail-{Id}";
            if (_cache.TryGetValue(cacheKey, out Schedule cachedSchedule))
            {
                return cachedSchedule;
            }

            Schedule schedule = await _innerRepository.GetByIdDetailAsync(Id, cancellationToken);
            if (schedule != null)
            {
                _cache.Set(cacheKey, schedule, _cacheDuration);
            }
            return schedule;
        }

        public async Task<Schedule> GetByIdAsync(object id, CancellationToken cancellationToken = default)
        {
            return await GetByIdDetailAsync((Guid)id, cancellationToken);
        }

        public async Task<IEnumerable<DeviceJob>> GetDevices(Guid ScheduleId, CancellationToken cancellationToken = default)
        {
            var cacheKey = $"Devices-{ScheduleId}";
            if (_cache.TryGetValue(cacheKey, out IEnumerable<DeviceJob> cachedDevices))
            {
                return cachedDevices;
            }

            var devices = await _innerRepository.GetDevices(ScheduleId, cancellationToken);
            _cache.Set(cacheKey, devices, _cacheDuration);
            return devices;
        }

        // Implement other methods from IGenericRepository
        public async Task Delete(object id)
        {
            await _innerRepository.Delete(id);
            _cache.Remove($"Schedule-{id}");
        }

        public async Task DeleteAsync(object ob)
        {
            await _innerRepository.DeleteAsync(ob);
        }

        public void Insert(Schedule schedule)
        {
            _innerRepository.Insert(schedule);
        }

        public void Update(Schedule schedule)
        {
            _innerRepository.Update(schedule);
            _cache.Set($"Schedule-{schedule.Id}", schedule, _cacheDuration);
        }
    }

}
