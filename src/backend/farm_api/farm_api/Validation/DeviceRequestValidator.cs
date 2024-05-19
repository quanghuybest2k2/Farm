using Core.Constant;
using farm_api.Models.Request;
using FluentValidation;

namespace farm_api.Validation
{
    public class DeviceRequestValidator:AbstractValidator<DeviceRequest>
    {
        public DeviceRequestValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage(APIResponseMessage.NotNull);
            RuleFor(x => x.Type).NotNull().WithMessage(APIResponseMessage.NotNull);
            RuleFor(x => x.FarmId).NotNull().WithMessage(APIResponseMessage.NotNull);
            RuleFor(x => x.Order).NotNull().WithMessage(APIResponseMessage.NotNull);
        }
    }
}
