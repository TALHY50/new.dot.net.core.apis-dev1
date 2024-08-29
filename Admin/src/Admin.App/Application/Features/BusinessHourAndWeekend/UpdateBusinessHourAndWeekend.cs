using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedBusiness.Main.IMT.Infrastructure.Persistence.Context;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Models;
using SharedKernel.Main.Contracts.Common;

namespace Admin.App.Application.Features.BusinessHourAndWeekend;

public class UpdateBusinessHourAndWeekendController : ApiControllerBase
{
    //[Authorize(Policy = "HasPermission")]
    [HttpPut(Routes.UpdateBusinessHourAndWeekendUrl, Name = Routes.UpdateBusinessHourAndWeekendName)]
    public async Task<ActionResult<ErrorOr<BusinessHoursAndWeekend>>> Create(UpdateBusinessHourAndWeekendCommand command)
    {
        var result = await Mediator.Send(command).ConfigureAwait(false);
        return result.Match(
            reminder => Ok(result.Value),
            Problem);
    }

    public record UpdateBusinessHourAndWeekendCommand(int id, byte HourType, uint? CountryId,
    string Day, sbyte IsWeekend, string Gmt, DateTime OpenAt, DateTime CloseAt, uint? CompanyId, byte Status)
    : IRequest<ErrorOr<BusinessHoursAndWeekend>>;


    internal sealed class UpdateBusinessHourAndWeekendCommandValidator : AbstractValidator<UpdateBusinessHourAndWeekendCommand>
    {
        public UpdateBusinessHourAndWeekendCommandValidator()
        {
            RuleFor(r => r.Day).NotEmpty().WithMessage("Day is required");
            RuleFor(r => r.OpenAt).NotEmpty().WithMessage("OpenAt is required");
            RuleFor(r => r.CloseAt).NotEmpty().WithMessage("CloseAt is required");
            RuleFor(r => r.Gmt).NotEmpty().WithMessage("Gmt is required");
            RuleFor(r => r.IsWeekend).NotEmpty().WithMessage("Gmt is required");
        }
    }

    internal sealed class UpdateBusinessHourAndWeekendHandler(ApplicationDbContext _context, IBusinessHourAndWeekendRepository repository) : IRequestHandler<UpdateBusinessHourAndWeekendCommand, ErrorOr<BusinessHoursAndWeekend>>
    {
        public async Task<ErrorOr<BusinessHoursAndWeekend>> Handle(UpdateBusinessHourAndWeekendCommand request, CancellationToken cancellationToken)
        {

            var businessHourAndWeekend = await _context.ImtBusinessHoursAndWeekends.FirstAsync(e => e.Id == request.id, cancellationToken: cancellationToken).ConfigureAwait(false);
            if (businessHourAndWeekend == null)
            {
                return Error.NotFound("Business hour and weekend not found!", AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
            }

            businessHourAndWeekend.HourType = request.HourType;
            businessHourAndWeekend.CountryId = request.CountryId;
            businessHourAndWeekend.Day = request.Day;
            businessHourAndWeekend.IsWeekend = request.IsWeekend;
            businessHourAndWeekend.Gmt = request.Gmt;
            businessHourAndWeekend.OpenAt = request.OpenAt;
            businessHourAndWeekend.CloseAt = request.CloseAt;
            businessHourAndWeekend.CompanyId = request.CompanyId;
            businessHourAndWeekend.Status = request.Status;
            businessHourAndWeekend.UpdatedAt = DateTime.UtcNow;

            _context.ImtBusinessHoursAndWeekends.Update(businessHourAndWeekend);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return businessHourAndWeekend;
        }
    }






}
