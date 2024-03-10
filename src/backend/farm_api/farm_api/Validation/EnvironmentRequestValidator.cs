using farm_api.Models;
using FluentValidation;

namespace farm_api.Validation
{
    public class EnvironmentRequestValidator:AbstractValidator<EnvironmentDTO>
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
