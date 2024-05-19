using AutoMapper;
using Core.Constract;
using Core.Entities;
using Core.Queries;
using DAL.Repositories.Implementation;
using DAL.Repositories.Interface;
using DAL.Repositories.UnitOfWork;
using farm_api.Filter.Environment;
using farm_api.Filter.Farm;
using farm_api.Models;
using farm_api.Models.Request;
using farm_api.Responses;
using System.Linq.Dynamic.Core;
using farm_api.Services.Interface;
using FluentValidation;

namespace farm_api.Services.Implementation
{
    public class FarmService : IFarmService
    {
        private readonly IFarmRepositorty _farmRepositorty;
        private readonly IMapper _mapper;
        private readonly IValidator<FarmRequest> _validator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly  IMQTTService _mQTTService;
        public FarmService(IFarmRepositorty farmRepositorty, IMapper mapper, IValidator<FarmRequest> validator,IMQTTService mQTTService, IUnitOfWork unitOfWork)
        {
            _farmRepositorty = farmRepositorty;
            _mapper = mapper;
            _validator = validator;
            _unitOfWork = unitOfWork;
            _mQTTService = mQTTService;
        }

        public async Task AddFarmAsync(FarmRequest farmRequest, CancellationToken cancellationToken = default)
        {
            await _validator.ValidateAndThrowAsync(farmRequest);
            var env = _mapper.Map<Farm>(farmRequest);
            if (env == null) { throw new ArgumentNullException(); }
            await _mQTTService.SubscribeAsync(env.DeviceStatusCode);
            await _mQTTService.SubscribeAsync(env.SensorLocation);
            _farmRepositorty.Insert(env);
            _unitOfWork.Save();
        }

        public async Task DeleteFarmAsync(Guid id)
        {
            await _farmRepositorty.Delete(id);
            _unitOfWork.Save();
        }

        public async Task<PagedFarmResponse<FarmDTO>> GetAllAsync(FarmQuery farmQuery, IPagingParams pagingParams, CancellationToken cancellationToken = default)
        {
            var mapper = _mapper.Map<FarmQueryDTO>(farmQuery);
            var result = await _farmRepositorty.GetAllAsync(mapper, cancellationToken);
            var totalItems = result.Count();
            // Áp dụng dynamic sorting
            var itemPage = result.Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                                 .Take(pagingParams.PageSize)
                                 .AsQueryable()  // Chuyển đổi sang IQueryable để sử dụng Dynamic Linq
                                 .OrderBy($"{pagingParams.SortColumn} {pagingParams.SortOrder}")
                                 .ToList();
            return new PagedFarmResponse<FarmDTO>(itemPage.Select(x => _mapper.Map<FarmDTO>(x)), pagingParams.PageNumber, pagingParams.PageSize, totalItems);
        }

        public async Task<FarmDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _farmRepositorty.GetByIdDetailAsync(id, cancellationToken);
            return _mapper.Map<FarmDTO>(result);
        }

        public async Task UpdateFarmAsync(Guid id, FarmRequest farmRequest, CancellationToken cancellationToken = default)
        {
            await _validator.ValidateAndThrowAsync(farmRequest);
            var entityUpdate = await _farmRepositorty.GetByIdAsync(id);
            if (entityUpdate == null)
            {
                throw new KeyNotFoundException($"not found item with id {id} to update, please  check again ");
            }
            _mapper.Map(farmRequest, entityUpdate);
            _farmRepositorty.Update(entityUpdate);
            if (entityUpdate == null) { throw new ArgumentNullException(); }
            await _mQTTService.SubscribeAsync(entityUpdate.DeviceStatusCode);
            await _mQTTService.SubscribeAsync(entityUpdate.SensorLocation);
            _unitOfWork.Save();

        }
    }
}
