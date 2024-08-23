using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.Admin;

using Entities = SharedKernel.Main.Domain.IMT.Entities;

namespace Admin.App.Application.Features.HolidaySetting;

public class UpdateHolidaySettingController : ApiControllerBase
{
    //[Authorize(Policy = "HasPermission")]
    [HttpPut(Routes.UpdateHolidaySettingUrl, Name = Routes.UpdateHolidaySettingName)]
    public async Task<ActionResult<ErrorOr<Entities.HolidaySetting>>> Create(UpdateHolidaySettingCommand command)
    {
        return await Mediator.Send(command).ConfigureAwait(false);
    }

    public record UpdateHolidaySettingCommand(int Id, int? CountryId, DateTime Date, byte Type, sbyte Gmt, DateTime? OpenAt, DateTime? CloseAt, int CompanyId)
    : IRequest<ErrorOr<Entities.HolidaySetting>>;


    internal sealed class UpdateHolidaySettingCommandValidator : AbstractValidator<UpdateHolidaySettingCommand>
    {
        public UpdateHolidaySettingCommandValidator()
        {
            RuleFor(r => r.Id).NotEmpty();
        }
    }

    internal sealed class UpdateHolidaySettingHandler() : IRequestHandler<UpdateHolidaySettingCommand, ErrorOr<Entities.HolidaySetting>>
    {
        public Task<ErrorOr<Entities.HolidaySetting>> Handle(UpdateHolidaySettingCommand request, CancellationToken cancellationToken)
        {

            // ToDo
            // First get the item from db
            // Then update current item
            throw new NotImplementedException();
        }
    }






}
