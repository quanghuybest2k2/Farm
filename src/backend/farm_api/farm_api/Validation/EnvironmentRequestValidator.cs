using Core.Constant;
using farm_api.Models;
using farm_api.Models.Request;
using FluentValidation;

namespace farm_api.Validation
{
    public class EnvironmentRequestValidator:AbstractValidator<EnvirontmentRequest>
    {
        public EnvironmentRequestValidator() 
        {
            RuleFor(x => x.Temperature).NotEmpty().WithMessage(APIResponseMessage.NotNull);
            RuleFor(x => x.SensorLocation).NotEmpty().WithMessage(APIResponseMessage.NotNull);
            RuleFor(x => x.Brightness).NotEmpty().WithMessage(APIResponseMessage.NotNull);
            RuleFor(x => x.SensorLocation).NotNull().WithMessage(APIResponseMessage.NotNull);
        }
    }
}
