using Core.Constant;
using DAL.Repositories.Interface;
using farm_api.Models.Request;
using FluentValidation;
using System.Text.RegularExpressions;

namespace farm_api.Validation
{
    public class ScheduleRequestValidator : AbstractValidator<ScheduleRequest>
    {
        public ScheduleRequestValidator()
        {
            RuleFor(x => x.FarmId).NotNull().WithMessage(APIResponseMessage.NotNull);
            RuleFor(x => x.Devices).NotNull().WithMessage(APIResponseMessage.NotNull);
            RuleFor(x => x.StartValue).NotNull().WithMessage(APIResponseMessage.NotNull);
            RuleFor(x => x.EndValue).NotNull().WithMessage(APIResponseMessage.NotNull);
            RuleFor(x => x.StartDate).NotNull().WithMessage(APIResponseMessage.NotNull)
                .MustAsync(IsValidDate).WithMessage("Invalid date format. Use YYYY/mm/dd hh:mm:ss");
            RuleFor(x => x.EndDate).NotNull().WithMessage(APIResponseMessage.NotNull)
                .MustAsync(IsValidDate).WithMessage("Invalid date format. Use YYYY/mm/dd hh:mm:ss");
        }
        private async Task<bool> IsValidDate(string date, CancellationToken cancellationToken)
        {
            if (date == null)
                return false;

            // Updated regex to allow one or two digits for the hour
            Regex regex = new Regex(@"^\d{4}/(0[1-9]|1[0-2])/(0[1-9]|[12][0-9]|3[01])\s([0-9]|1[0-9]|2[0-3]):([0-5][0-9]):([0-5][0-9])$");
            Match match = regex.Match(date);
            return match.Success;
        }

    }

}
