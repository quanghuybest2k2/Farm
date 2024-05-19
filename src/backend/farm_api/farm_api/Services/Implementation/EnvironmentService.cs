using AutoMapper;
using Core.Constract;
using Core.DTO;
using Core.Queries;
using DAL.Repositories.Interface;
using DAL.Repositories.UnitOfWork;
using farm_api.Filter.Environment;
using farm_api.Models;
using farm_api.Models.Request;
using farm_api.Responses;
using farm_api.Services.Interface;
using farm_api.Validation;
using FluentValidation;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Formats.Asn1;
using Environment = Core.Entities.Environment;

namespace farm_api.Services.Implementation
{
    public class EnvironmentService : IEnvironmentService
    {
        private readonly IEnvironmentRepository _environmentRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<EnvirontmentRequest> _validator;
        private readonly IUnitOfWork _unitOfWork;
        public EnvironmentService(
              IEnvironmentRepository environmentRepository
            , IMapper mapper
            , IValidator<EnvirontmentRequest> validator
            , IUnitOfWork unitOfWork)
        {
            _environmentRepository = environmentRepository;
            _mapper = mapper;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public async Task AddEnvironmentAsync(EnvirontmentRequest environment, CancellationToken cancellationToken = default)
        {
            await _validator.ValidateAndThrowAsync(environment);
            var env = _mapper.Map<Environment>(environment);
            _environmentRepository.Insert(env);
            _unitOfWork.Save();
        }

        public async Task DeleteEnvironmentAsync(Guid id)
        {
            await _environmentRepository.Delete(id);

            _unitOfWork.Save();
        }

        public async Task<PagedFarmResponse<EnvironmentDTO>> GetAllAsync(EnvironmentQuery environmentQuery, IPagingParams pagingParams, CancellationToken cancellationToken = default)
        {
            var mapper = _mapper.Map<EnvironmentQueryDTO>(environmentQuery);
            var result = await _environmentRepository.GetAllAsync(mapper, cancellationToken);
            var totalItems = result.Count();
            // Áp dụng dynamic sorting
            var itemPage = result.Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                                 .Take(pagingParams.PageSize)
                                 .AsQueryable()  // Chuyển đổi sang IQueryable để sử dụng Dynamic Linq
                                 .OrderBy($"{pagingParams.SortColumn} {pagingParams.SortOrder}")
                                 .ToList();
            return new PagedFarmResponse<EnvironmentDTO>(itemPage.Select(x => _mapper.Map<EnvironmentDTO>(x)), pagingParams.PageNumber, pagingParams.PageSize, totalItems);
        }

        public async Task<EnvironmentDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _environmentRepository.GetByIdAsync(id, cancellationToken);
            return _mapper.Map<EnvironmentDTO>(result);
        }

        public async Task UpdateEnvironmentAsync(Guid id, EnvirontmentRequest environment, CancellationToken cancellationToken = default)
        {
            await _validator.ValidateAndThrowAsync(environment);
            var entityUpdate = await _environmentRepository.GetByIdAsync(id);
            if (entityUpdate == null)
            {
                throw new KeyNotFoundException($"not found item with id {id} to update, please  check again ");

            }
            _mapper.Map(environment, entityUpdate);

            _environmentRepository.Update(entityUpdate);
            _unitOfWork.Save();

        }

        public async Task<IEnumerable<TemperatureHumidityStats>> GetAverageTemperatureAndHumidityByLocationAsync(CancellationToken cancellationToken = default)
        {
            // Directly call the repository method
            var stats = await _environmentRepository.GetAverageTemperatureAndHumidityByLocationAsync(cancellationToken);
            return stats;
        }

        public async Task<IEnumerable<EnvironmentAverageData>> GetAverageEnvironmentValues(
        string sensorLocation,
        DateTime startDate,
        DateTime endDate,
        CancellationToken cancellationToken = default)
        {
            return await _environmentRepository.GetAverageEnvironmentValues(sensorLocation, startDate, endDate, cancellationToken);
        }

        public async Task<EnvironmentDTO> GetEnvironmentBySensorLocatonRecentDays(string sensorLocation, CancellationToken cancellationToken = default)
        {
            return _mapper.Map<EnvironmentDTO>(await _environmentRepository.GetEnvironmentBySensorLocatonRecentDays(sensorLocation, cancellationToken));
        }

        public async Task<IEnumerable<EnvironmentDTO>> GetEnvironmentsByLocationAndCreationDay(string sensorLocation, DateTime targetDate, CancellationToken cancellationToken = default)
        {
            return _mapper.Map<IEnumerable<EnvironmentDTO>>(await _environmentRepository.GetEnvironmentsByLocationAndCreationDay(sensorLocation, targetDate, cancellationToken));
        }
    }
}
