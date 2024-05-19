using Core.Constant;
using farm_api.Models.Request;
using FluentValidation;
using MQTTnet.Packets;

namespace farm_api.Validation
{
    public class FarmRequestValidator:AbstractValidator<FarmRequest>
    {
        public FarmRequestValidator() 
        {
            RuleFor(x => x.Name).NotNull().WithMessage(APIResponseMessage.NotNull);
            RuleFor(x => x.ControllerCode).NotNull().WithMessage(APIResponseMessage.NotNull);
            RuleFor(x => x.DeviceStatusCode).NotNull().WithMessage(APIResponseMessage.NotNull);
            RuleFor(x => x.SensorLocation).NotNull().WithMessage(APIResponseMessage.NotNull);
            RuleFor(x => x.Latitude).NotNull().WithMessage(APIResponseMessage.NotNull);
            RuleFor(x => x.Longitude).NotNull().WithMessage(APIResponseMessage.NotNull);
        }
    }
}
