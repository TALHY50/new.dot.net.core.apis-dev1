using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.Admin;

namespace ADMIN.App.Application.Features.HolidaySetting;

public class UpdateHolidaySettingController : ApiControllerBase
{
    //[Authorize(Policy = "HasPermission")]
    [HttpPut(Routes.UpdateHolidaySettingUrl, Name = Routes.UpdateHolidaySettingName)]
    public async Task<ActionResult<ErrorOr<BusinessHoursAndWeekends>>> Create(UpdateHolidaySettingCommand command)
    {
        return await Mediator.Send(command).ConfigureAwait(false);
    }

    public record UpdateHolidaySettingCommand(int id, byte HourType, int? CountryId,
    string Day, byte IsWeekend, sbyte Gmt, DateTime OpenAt, DateTime CloseAt, int CompanyId, byte Status)
    : IRequest<ErrorOr<BusinessHoursAndWeekends>>;


    internal sealed class UpdateHolidaySettingCommandValidator : AbstractValidator<UpdateHolidaySettingCommand>
    {
        public UpdateHolidaySettingCommandValidator()
        {
            RuleFor(r => r.id).NotEmpty();
        }
    }

    internal sealed class UpdateHolidaySettingHandler() : IRequestHandler<UpdateHolidaySettingCommand, ErrorOr<BusinessHoursAndWeekends>>
    {
        public Task<ErrorOr<BusinessHoursAndWeekends>> Handle(UpdateHolidaySettingCommand request, CancellationToken cancellationToken)
        {

            // ToDo
            // First get the item from db
            // Then update current item
            throw new NotImplementedException();
        }
    }






}
