using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.Admin;

using Entities = SharedKernel.Main.Domain.IMT.Entities;

namespace Admin.App.Application.Features.HolidaySetting;

public class CreateHolidaySettingController : ApiControllerBase
{

    //[Authorize(Policy = "HasPermission")]
    [HttpPost(Routes.CreateHolidaySettingUrl, Name = Routes.CreateHolidaySettingName)]
    public async Task<ActionResult<ErrorOr<Entities.HolidaySetting>>> Create(CreateHolidaySettingCommand command)
    {
        return await Mediator.Send(command).ConfigureAwait(false);
    }

    public record CreateHolidaySettingCommand(int? CountryId, DateTime Date, byte Type, sbyte Gmt, DateTime? OpenAt, DateTime? CloseAt, int CompanyId)
        : IRequest<ErrorOr<Entities.HolidaySetting>>;


    internal sealed class CreateHolidaySettingCommandValidator : AbstractValidator<CreateHolidaySettingCommand>
    {
        public CreateHolidaySettingCommandValidator()
        {
            RuleFor(r => r.Date).NotEmpty().WithMessage("Date is required.");
            RuleFor(r => r.Gmt).NotEmpty().WithMessage("Gmt is required.");
        }
    }

    internal sealed class CreateHolidaySettingHandler() : IRequestHandler<CreateHolidaySettingCommand, ErrorOr<Entities.HolidaySetting>>
    {
        public Task<ErrorOr<Entities.HolidaySetting>> Handle(CreateHolidaySettingCommand request, CancellationToken cancellationToken)
        {

            //_context.Events.Add(@event);
            //await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            throw new NotImplementedException();
        }
    }









}
