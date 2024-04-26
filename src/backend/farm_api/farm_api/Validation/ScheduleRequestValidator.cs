using Core.Constant;
using DAL.Repositories.Interface;
using farm_api.Models.Request;
using FluentValidation;

namespace farm_api.Validation
{
    public class ScheduleRequestValidator:AbstractValidator<ScheduleRequest>
    {
        public ScheduleRequestValidator() 
        {
            RuleFor(x => x.FarmId).NotNull().WithMessage(APIResponseMessage.NotNull);
            RuleFor(x => x.DevicesId).NotNull().WithMessage(APIResponseMessage.NotNull);
            RuleFor(x => x.StartValue).NotNull().WithMessage(APIResponseMessage.NotNull);
            RuleFor(x => x.EndValue).NotNull().WithMessage(APIResponseMessage.NotNull);
            RuleFor(x => x.StartDate).NotNull().WithMessage(APIResponseMessage.NotNull);
            RuleFor(x => x.EndDate).NotNull().WithMessage(APIResponseMessage.NotNull);
        }
    }
    
}
