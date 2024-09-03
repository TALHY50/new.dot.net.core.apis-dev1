using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;
using Duplicates_HolidaySetting = SharedBusiness.Main.Common.Domain.Entities.HolidaySetting;

namespace Admin.Web.Application.Features.HolidaySetting;

public class UpdateHolidaySettingController : ApiControllerBase
{
    //[Authorize(Policy = "HasPermission")]
    [HttpPut(Routes.UpdateHolidaySettingUrl, Name = Routes.UpdateHolidaySettingName)]
    public async Task<ActionResult<ErrorOr<Duplicates_HolidaySetting>>> Create(UpdateHolidaySettingCommand command)
    {
        var result = await Mediator.Send(command).ConfigureAwait(false);
        return result.Match(
            reminder => Ok(result.Value),
            Problem);
    }

    public record UpdateHolidaySettingCommand(int Id, uint? CountryId, DateTime Date, byte Type, string Gmt, DateTime? OpenAt, DateTime? CloseAt, uint? CompanyId)
    : IRequest<ErrorOr<Duplicates_HolidaySetting>>;


    public class UpdateHolidaySettingCommandValidator : AbstractValidator<UpdateHolidaySettingCommand>
    {
        public UpdateHolidaySettingCommandValidator()
        {
            RuleFor(r => r.Id).NotEmpty();
            RuleFor(r => r.Date).NotEmpty().WithMessage("Date is required.");
            RuleFor(r => r.Gmt).NotEmpty().WithMessage("Gmt is required.");
        }
    }

    public class UpdateHolidaySettingHandler(ApplicationDbContext _context, IHolidaySettingRepository repository) : IRequestHandler<UpdateHolidaySettingCommand, ErrorOr<Duplicates_HolidaySetting>>
    {
        public async Task<ErrorOr<Duplicates_HolidaySetting>> Handle(UpdateHolidaySettingCommand request, CancellationToken cancellationToken)
        {

            var holidaySetting = await _context.ImtHolidaySettings.FirstAsync(e => e.Id == request.Id, cancellationToken: cancellationToken).ConfigureAwait(false);
            if (holidaySetting == null)
            {
                return Error.NotFound("Holiday Setting not found!", ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
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
