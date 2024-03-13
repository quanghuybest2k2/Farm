using AutoMapper;
using Core.Constract;
using Core.Queries;
using DAL.Repositories.Interface;
using farm_api.Filter.Environment;
using farm_api.Models.Request;
using farm_api.Models;
using farm_api.Responses;
using farm_api.Services.Interface;
using FluentValidation;
using Core.Entities;
using farm_api.Filter.Device;

namespace farm_api.Services.Implementation
{
    public class DeviceService: IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<DeviceRequest> _validator;
        private readonly IUnitOfWork _unitOfWork;
        public DeviceService(
              IDeviceRepository deviceRepository
            , IMapper mapper
            , IValidator<DeviceRequest> validator
            , IUnitOfWork unitOfWork)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public async Task AddDeviceAsync(DeviceRequest environment, CancellationToken cancellationToken = default)
        {
            await _validator.ValidateAndThrowAsync(environment);
            var env = _mapper.Map<Device>(environment);
            _deviceRepository.Insert(env);
            _unitOfWork.Save();
        }

        public async Task DeleteDeviceAsync(Guid id)
        {
            await _deviceRepository.Delete(id);

            _unitOfWork.Save();
        }

        public async Task<PagedFarmResponse<DeviceDTO>> GetAllAsync(DeviceQuery deviceQuery, IPagingParams pagingParams, CancellationToken cancellationToken = default)
        {
            var mapper = _mapper.Map<DeviceQueryDTO>(deviceQuery);
            var result = await _deviceRepository.GetAllAsync(mapper, cancellationToken);
            var totalItems = result.Count();
            var itemPage = result.Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                                .Take(pagingParams.PageSize)
                                .ToList();
            return new PagedFarmResponse<DeviceDTO>(itemPage.Select(x => _mapper.Map<DeviceDTO>(x)), pagingParams.PageNumber, pagingParams.PageSize, totalItems);
        }

        public async Task<DeviceDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _deviceRepository.GetByIdAsync(id, cancellationToken);
            return _mapper.Map<DeviceDTO>(result);
        }

        public async Task UpdateDeviceAsync(Guid id, DeviceRequest deviceRequest, CancellationToken cancellationToken = default)
        {
            await _validator.ValidateAndThrowAsync(deviceRequest);
            var entityUpdate = await _deviceRepository.GetByIdAsync(id);
            if (entityUpdate == null)
            {
                throw new KeyNotFoundException($"not found item with id {id} to update, please  check again ");

            }
            _mapper.Map(deviceRequest, entityUpdate);
            _deviceRepository.Update(entityUpdate);
            _unitOfWork.Save();

        }
    }
}
