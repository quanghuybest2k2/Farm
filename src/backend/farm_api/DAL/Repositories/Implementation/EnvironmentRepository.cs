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
            IQueryable<Environment> query = _context.Set<Environment>().Include(x => x.Farm);
            if (!string.IsNullOrEmpty(environmentQueryDTO.SensorLocation))
            {
                query = query.Where(x => x.SensorLocation.Contains(environmentQueryDTO.SensorLocation));
            }
            if (!(environmentQueryDTO.Brightness is null) && (environmentQueryDTO.Brightness > 0))
            {
                query = query.Where(x => x.Brightness == environmentQueryDTO.Brightness);
            }

            if (!(environmentQueryDTO.Temperature is null) && environmentQueryDTO.Temperature > 0)
            {
                query = query.Where(x => x.Temperature == environmentQueryDTO.Temperature);
            }
            return query;

        }
        public async Task<IEnumerable<TemperatureHumidityStats>> GetAverageTemperatureAndHumidityByLocationAsync(CancellationToken cancellationToken = default)
        {
            var stats = await _context.Environments.Include(x => x.Farm)
                .GroupBy(e => e.SensorLocation)
                .Select(group => new TemperatureHumidityStats
                {
                    SensorLocation = group.Key,
                    AverageTemperature = group.Average(e => e.Temperature),
                    AverageHumidity = group.Average(e => e.Humidity),
                    AverageBrightness = group.Average(e => e.Brightness)
                })
                .ToListAsync(cancellationToken);

            return stats;
        }

        public async Task<Environment> GetEnvironmentBySensorLocatonRecentDays(string sensorLocation, CancellationToken cancellationToken = default)
        {
            var recentEnvironment = await _context.Set<Environment>()
                                                    .Include(x => x.Farm)
                                                    .AsNoTracking()
                                                    .Where(e => e.SensorLocation == sensorLocation) // Lọc theo SensorLocation
                                                    .OrderByDescending(e => e.CreateAt) // Sắp xếp theo UpdateAt hoặc CreateAt nếu UpdateAt là null
                                                    .FirstOrDefaultAsync(cancellationToken); // Lấy bản ghi đầu tiên
            return recentEnvironment;
        }
        public async Task<IEnumerable<Environment>> GetEnvironmentsByLocationAndCreationDay(
        string sensorLocation,
        DateTime targetDate,
        CancellationToken cancellationToken = default)
        {
            var dateFrom = targetDate.Date; // Ngày bắt đầu (0h00)
            var dateTo = dateFrom.AddDays(1); // Ngày kết thúc (0h00 ngày hôm sau)

            // Truy vấn để lấy tất cả các bản ghi phù hợp chỉ dựa trên ngày tạo
            var environments = await _context.Set<Environment>()
                .AsNoTracking()
                .Where(e => e.SensorLocation == sensorLocation &&
                            e.CreateAt >= dateFrom && e.CreateAt < dateTo)
                .ToListAsync(cancellationToken);

            return environments;
        }
        public async Task<IEnumerable<EnvironmentAverageData>> GetAverageEnvironmentValues(
        string sensorLocation,
        DateTime startDate,
        DateTime endDate,
        CancellationToken cancellationToken = default)
        {
            var dateFrom = startDate.Date; // Ngày bắt đầu (0h00)
            var dateTo = endDate.Date.AddDays(1); // Ngày kết thúc (0h00 của ngày tiếp theo để bao gồm cả ngày cuối)

            // Truy vấn để lấy tất cả các bản ghi phù hợp trong khoảng thời gian này và tính toán giá trị trung bình theo từng ngày
            var dailyAverages = await _context.Set<Environment>()
                .AsNoTracking()
                .Where(e => e.SensorLocation == sensorLocation &&
                            e.CreateAt >= dateFrom && e.CreateAt < dateTo)
                .GroupBy(e => e.CreateAt.Value.Date) // Nhóm theo ngày tạo
                .Select(g => new EnvironmentAverageData
                {
                    Date = g.Key, // Lưu ngày
                    AverageTemperature = g.Average(x => x.Temperature),
                    AverageHumidity = g.Average(x => x.Humidity),
                    AverageBrightness = g.Average(x => x.Brightness)
                })
                .ToListAsync(cancellationToken);

            return dailyAverages;
        }
    }
}
