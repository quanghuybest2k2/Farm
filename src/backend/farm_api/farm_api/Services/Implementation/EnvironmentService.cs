using AutoMapper;
using DAL.Repositories.Interface;
using farm_api.Models;
using farm_api.Services.Interface;
using farm_api.Validation;
using FluentValidation;
using System.Formats.Asn1;

namespace farm_api.Services.Implementation
{
    public class EnvironmentService : IEnvironmentService
    {
        private readonly IEnvironmentRepository _environmentRepository;
        private readonly IMapper _mapper;
        //private readonly IValidator<EnvironmentRequestValidator> _validator;
        private readonly IUnitOfWork _unitOfWork;
        public EnvironmentService(
              IEnvironmentRepository environmentRepository
            , IMapper mapper
            //, IValidator<EnvironmentRequestValidator> validator
            , IUnitOfWork unitOfWork)
        {
            _environmentRepository = environmentRepository;
            _mapper = mapper;
            //_validator = validator;
            _unitOfWork = unitOfWork;
        }

        public Task<EnvironmentDTO> AddEnvironmentAsync(EnvironmentDTO environment, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEnvironmentAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<EnvironmentDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _environmentRepository.GetByIdAsync(id, cancellationToken);
            return _mapper.Map<EnvironmentDTO>(result);
        }

        public Task UpdateEnvironmentAsync(EnvironmentDTO environment, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
