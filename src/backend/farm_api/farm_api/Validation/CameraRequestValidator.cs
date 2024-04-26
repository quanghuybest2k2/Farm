using Core.Constant;
using farm_api.Models.Request;
using FluentValidation;

namespace farm_api.Validation
{
    public class CameraRequestValidator:AbstractValidator<CameraRequest>
    {
        public CameraRequestValidator() 
        {
            RuleFor(x => x.Name).NotNull().WithMessage(APIResponseMessage.NotNull);
            RuleFor(x=>x.IPAddress).NotNull().WithMessage(APIResponseMessage.NotNull);
            RuleFor(x => x.Port).NotNull().WithMessage(APIResponseMessage.NotNull);
            RuleFor(x => x.Location).NotNull().WithMessage(APIResponseMessage.NotNull);
        }
    }
}
