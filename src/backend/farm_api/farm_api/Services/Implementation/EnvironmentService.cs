using AutoMapper;
using DAL.Repositories.Interface;
using farm_api.Models;
using farm_api.Models.Request;
using farm_api.Services.Interface;
using farm_api.Validation;
using FluentValidation;
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

        public  async Task DeleteEnvironmentAsync(Guid id)
        {
            await _environmentRepository.Delete(id);

            _unitOfWork.Save();
        }

        public async Task<EnvironmentDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _environmentRepository.GetByIdAsync(id, cancellationToken);
            return _mapper.Map<EnvironmentDTO>(result);
        }

        public async Task UpdateEnvironmentAsync(Guid id,EnvirontmentRequest environment, CancellationToken cancellationToken = default)
        {
            await _validator.ValidateAndThrowAsync(environment);
            var entityUpdate= await _environmentRepository.GetByIdAsync(id);
            if (entityUpdate == null)
            {
                throw new KeyNotFoundException($"not found item with id {id} to update, please  check again ");

            }
            _mapper.Map(environment,entityUpdate);

            _environmentRepository.Update(entityUpdate);
            _unitOfWork.Save();

        }
    }
}
