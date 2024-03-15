using AutoMapper;
using Core.Constract;
using Core.Entities;
using Core.Queries;
using DAL.Repositories.Interface;
using DAL.Repositories.UnitOfWork;
using farm_api.Filter.Device;
using farm_api.Models.Request;
using farm_api.Models;
using farm_api.Responses;
using farm_api.Services.Interface;
using FluentValidation;
using farm_api.Filter.Camera;

namespace farm_api.Services.Implementation
{
    public class CameraService: ICameraService
    {
        private readonly ICameraRepository _cameraRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CameraRequest> _validator;
        private readonly IUnitOfWork _unitOfWork;
        public CameraService(
              ICameraRepository cameraRepository
            , IMapper mapper
            , IValidator<CameraRequest> validator
            , IUnitOfWork unitOfWork)
        {
            _cameraRepository = cameraRepository;
            _mapper = mapper;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public async Task AddCameraAsync(CameraRequest cameraRequest, CancellationToken cancellationToken = default)
        {
            await _validator.ValidateAndThrowAsync(cameraRequest);
            var camera = _mapper.Map<Camera>(cameraRequest);
            _cameraRepository.Insert(camera);
            _unitOfWork.Save();
        }

        public async Task DeleteCameraAsync(Guid id)
        {
            await _cameraRepository.Delete(id);
            _unitOfWork.Save();
        }

        public async Task<PagedFarmResponse<CameraDTO>> GetAllAsync(CameraQuery cameraQuery, IPagingParams pagingParams, CancellationToken cancellationToken = default)
        {
            var mapper = _mapper.Map<CameraQueryDTO>(cameraQuery);
            var result = await _cameraRepository.GetAllAsync(mapper, cancellationToken);
            var totalItems = result.Count();
            var itemPage = result.Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                                .Take(pagingParams.PageSize)
                                .ToList();
            return new PagedFarmResponse<CameraDTO>(itemPage.Select(x => _mapper.Map<CameraDTO>(x)), pagingParams.PageNumber, pagingParams.PageSize, totalItems);
        }

        public async Task<CameraDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _cameraRepository.GetByIdAsync(id, cancellationToken);
            return _mapper.Map<CameraDTO>(result);
        }

        public async Task UpdateCameraAsync(Guid id, CameraRequest cameraRequest, CancellationToken cancellationToken = default)
        {
            await _validator.ValidateAndThrowAsync(cameraRequest);
            var entityUpdate = await _cameraRepository.GetByIdAsync(id);
            if (entityUpdate == null)
            {
                throw new KeyNotFoundException($"not found item with id {id} to update, please  check again ");

            }
            _mapper.Map(cameraRequest, entityUpdate);
            _cameraRepository.Update(entityUpdate);
            _unitOfWork.Save();

        }
    }
}
