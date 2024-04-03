using DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using DAL.Context;
using Environment = Core.Entities.Environment;
using Microsoft.EntityFrameworkCore;
using DAL.Repositories.GenericRepository;
using Core.Queries;
using Core.DTO;

namespace DAL.Repositories.Implementation
{
    public class EnvironmentRepository : GenericRepository<Environment>, IEnvironmentRepository
    {
        public EnvironmentRepository(FarmContext context) : base(context) { }

        public async Task<IEnumerable<Environment>> GetAllAsync(EnvironmentQueryDTO environmentQueryDTO, CancellationToken cancellationToken = default)
        {
            return await Filter(environmentQueryDTO).ToListAsync(cancellationToken);
        }
        private IQueryable<Environment> Filter(EnvironmentQueryDTO environmentQueryDTO)
        {
            IQueryable<Environment> query = _context.Set<Environment>();
            if (!string.IsNullOrEmpty(environmentQueryDTO.SensorLocation))
            {
                query = query.Where(x => x.SensorLocation.Contains(environmentQueryDTO.SensorLocation));
            }
            if (!(environmentQueryDTO.Brightness is null) && (environmentQueryDTO.Brightness > 0))
            {
                query = query.Where(x => x.Brightness == environmentQueryDTO.Brightness);
            }
            if (!(environmentQueryDTO.AirQuality is null) && environmentQueryDTO.AirQuality > 0)
            {
                query = query.Where(x => x.AirQuality == environmentQueryDTO.AirQuality);
            }
            if (!(environmentQueryDTO.Temperature is null) && environmentQueryDTO.Temperature > 0)
            {
                query = query.Where(x => x.Temperature == environmentQueryDTO.Temperature);
            }
            return query;

        }
        public async Task<IEnumerable<EnvironmentStatistics>> GetDailyStatisticsAsync(DateTime ?startDate, DateTime ?endDate,CancellationToken cancellationToken=default)
        {
            // Nếu không có ngày bắt đầu và kết thúc được chọn, sử dụng ngày hiện tại
            DateTime now = DateTime.Now.Date; // Lấy ngày hiện tại với thời gian 00:00:00
            startDate = startDate ?? now;
            endDate = endDate ?? now;

            var statistics = await _context.Environments
                .Where(e => e.CreateAt.HasValue && e.CreateAt.Value.Date >= startDate.Value && e.CreateAt.Value.Date <= endDate.Value)
                .GroupBy(e => e.CreateAt.Value.Date)
                .Select(group => new EnvironmentStatistics
                {
                    Date = group.Key,
                    AverageTemperature = group.Average(e => e.Temperature),
                    AverageHumidity = group.Average(e => e.Humidity),
                    AverageAirQuality = group.Average(e => e.AirQuality),
                    AverageBrightness = group.Average(e => e.Brightness)
                })
                .OrderBy(stat => stat.Date)
                .ToListAsync(cancellationToken);
            return statistics;
        }
        public async Task<IEnumerable<TemperatureHumidityStats>> GetAverageTemperatureAndHumidityByLocationAsync(CancellationToken cancellationToken = default)
        {
            var stats = await _context.Environments
                .GroupBy(e => e.SensorLocation)
                .Select(group => new TemperatureHumidityStats
                {
                    SensorLocation = group.Key,
                    AverageTemperature = group.Average(e => e.Temperature),
                    AverageHumidity = group.Average(e => e.Humidity),
                    AverageAirQuality = group.Average(e => e.AirQuality),
                    AverageBrightness = group.Average(e => e.Brightness)
                })
                .ToListAsync(cancellationToken);

            return stats;
        }
    }
}
