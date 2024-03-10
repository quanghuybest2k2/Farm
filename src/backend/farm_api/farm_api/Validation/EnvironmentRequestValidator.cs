using farm_api.Models;
using farm_api.Models.Request;
using FluentValidation;

namespace farm_api.Validation
{
    public class EnvironmentRequestValidator:AbstractValidator<EnvirontmentRequest>
    {
        public EnvironmentRequestValidator() 
        {
            RuleFor(x => x.Temperature).NotEmpty().WithMessage("Not Null");
            RuleFor(x => x.AirQuality).NotEmpty().WithMessage("Not Null");
            RuleFor(x => x.SensorLocation).NotEmpty().WithMessage("Not Null");
            RuleFor(x => x.Brightness).NotEmpty().WithMessage("Not Null");

        }
    }
}
