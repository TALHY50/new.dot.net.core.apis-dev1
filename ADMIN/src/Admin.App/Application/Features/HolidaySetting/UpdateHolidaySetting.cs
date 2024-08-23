using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Domain.Admin;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;
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

    public record UpdateHolidaySettingCommand(int Id, uint? CountryId, DateTime Date, byte Type, sbyte Gmt, DateTime? OpenAt, DateTime? CloseAt, uint? CompanyId)
    : IRequest<ErrorOr<Entities.HolidaySetting>>;


    internal sealed class UpdateHolidaySettingCommandValidator : AbstractValidator<UpdateHolidaySettingCommand>
    {
        public UpdateHolidaySettingCommandValidator()
        {
            RuleFor(r => r.Id).NotEmpty();
            RuleFor(r => r.Date).NotEmpty().WithMessage("Date is required.");
            RuleFor(r => r.Gmt).NotEmpty().WithMessage("Gmt is required.");
        }
    }

    internal sealed class UpdateHolidaySettingHandler(ImtApplicationDbContext _context, IHolidaySettingRepository repository) : IRequestHandler<UpdateHolidaySettingCommand, ErrorOr<Entities.HolidaySetting>>
    {
        public async Task<ErrorOr<Entities.HolidaySetting>> Handle(UpdateHolidaySettingCommand request, CancellationToken cancellationToken)
        {

            var holidaySetting = await _context.ImtHolidaySettings.FirstAsync(e => e.Id == request.Id, cancellationToken: cancellationToken).ConfigureAwait(false);
            if (holidaySetting == null)
            {
                return Error.NotFound("Holiday Setting not found!");
            }
            holidaySetting.CountryId = request.CountryId;
            holidaySetting.Date = request.Date;
            holidaySetting.Type = request.Type;
            holidaySetting.Type = request.Type;
            holidaySetting.Gmt = request.Gmt;
            holidaySetting.OpenAt = request.OpenAt;
            holidaySetting.CloseAt = request.CloseAt;
            holidaySetting.CompanyId = request.CompanyId;
            holidaySetting.UpdatedAt = DateTime.UtcNow;

            _context.ImtHolidaySettings.Update(holidaySetting);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return holidaySetting;
        }
    }






}
