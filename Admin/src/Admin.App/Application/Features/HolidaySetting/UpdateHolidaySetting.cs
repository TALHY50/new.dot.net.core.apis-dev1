using ErrorOr;
using FluentValidation;
using IMT.App.Application.Interfaces.Repositories;
using IMT.App.Infrastructure.Persistence.Context;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using Duplicates_HolidaySetting = IMT.App.Domain.Entities.HolidaySetting;

namespace Admin.App.Application.Features.HolidaySetting;

public class UpdateHolidaySettingController : ApiControllerBase
{
    //[Authorize(Policy = "HasPermission")]
    [HttpPut(Routes.UpdateHolidaySettingUrl, Name = Routes.UpdateHolidaySettingName)]
    public async Task<ActionResult<ErrorOr<Duplicates_HolidaySetting>>> Create(UpdateHolidaySettingCommand command)
    {
        return await Mediator.Send(command).ConfigureAwait(false);
    }

    public record UpdateHolidaySettingCommand(int Id, uint? CountryId, DateTime Date, byte Type, sbyte Gmt, DateTime? OpenAt, DateTime? CloseAt, uint? CompanyId)
    : IRequest<ErrorOr<Duplicates_HolidaySetting>>;


    internal sealed class UpdateHolidaySettingCommandValidator : AbstractValidator<UpdateHolidaySettingCommand>
    {
        public UpdateHolidaySettingCommandValidator()
        {
            RuleFor(r => r.Id).NotEmpty();
            RuleFor(r => r.Date).NotEmpty().WithMessage("Date is required.");
            RuleFor(r => r.Gmt).NotEmpty().WithMessage("Gmt is required.");
        }
    }

    internal sealed class UpdateHolidaySettingHandler(ApplicationDbContext _context, IHolidaySettingRepository repository) : IRequestHandler<UpdateHolidaySettingCommand, ErrorOr<Duplicates_HolidaySetting>>
    {
        public async Task<ErrorOr<Duplicates_HolidaySetting>> Handle(UpdateHolidaySettingCommand request, CancellationToken cancellationToken)
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
