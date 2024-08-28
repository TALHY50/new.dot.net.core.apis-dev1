using ErrorOr;
using FluentValidation;
using IMT.App.Application.Interfaces.Repositories;
using IMT.App.Infrastructure.Persistence.Context;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Duplicates_HolidaySetting = IMT.App.Domain.Entities.HolidaySetting;


namespace Admin.App.Application.Features.HolidaySetting;

public class GetHolidaySettingByIdController : ApiControllerBase
{

    //[Authorize(Policy = "HasPermission")]
    [HttpGet(Routes.GetHolidaySettingByIdUrl, Name = Routes.GetHolidaySettingByIdName)]
    public async Task<ActionResult<ErrorOr<Duplicates_HolidaySetting>>> Get(uint id)
    {
        var result = await Mediator.Send(new GetHolidaySettingByIdCommand(id)).ConfigureAwait(false);
        return result.Match(
            reminder => Ok(result.Value),
            Problem);
    }

    public record GetHolidaySettingByIdCommand(uint Id) : IRequest<ErrorOr<Duplicates_HolidaySetting>>;

    public class GetHolidaySettingByIdCommandValidator : AbstractValidator<GetHolidaySettingByIdCommand>
    {
        public GetHolidaySettingByIdCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Business hour and weekend ID is required");
        }
    }

    internal sealed class GetHolidaySettingByIdHandler(ApplicationDbContext _context, IHolidaySettingRepository repository) : IRequestHandler<GetHolidaySettingByIdCommand, ErrorOr<Duplicates_HolidaySetting>>
    {
        public async Task<ErrorOr<Duplicates_HolidaySetting>> Handle(GetHolidaySettingByIdCommand request, CancellationToken cancellationToken)
        {
            var holidaySetting = await _context.ImtHolidaySettings.FirstAsync(e => e.Id == request.Id, cancellationToken: cancellationToken).ConfigureAwait(false);
            if (holidaySetting == null)
            {
                return Error.NotFound("Holiday Setting not found!", AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
            }
            return holidaySetting;

        }
    }



}
