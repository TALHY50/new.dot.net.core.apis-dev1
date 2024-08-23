using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Domain.Admin;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;
using Entities = SharedKernel.Main.Domain.IMT.Entities;

namespace Admin.App.Application.Features.HolidaySetting;

public class GetHolidaySettingByIdController : ApiControllerBase
{

    //[Authorize(Policy = "HasPermission")]
    [HttpGet(Routes.GetHolidaySettingByIdUrl, Name = Routes.GetHolidaySettingByIdName)]
    public async Task<ActionResult<ErrorOr<Entities.HolidaySetting>>> Get(uint id)
    {
        return await Mediator.Send(new GetHolidaySettingByIdCommand(id)).ConfigureAwait(false);
    }

    public record GetHolidaySettingByIdCommand(uint Id) : IRequest<ErrorOr<Entities.HolidaySetting>>;

    public class GetHolidaySettingByIdCommandValidator : AbstractValidator<GetHolidaySettingByIdCommand>
    {
        public GetHolidaySettingByIdCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Business hour and weekend ID is required");
        }
    }

    internal sealed class GetHolidaySettingByIdHandler(ImtApplicationDbContext _context, IHolidaySettingRepository repository) : IRequestHandler<GetHolidaySettingByIdCommand, ErrorOr<Entities.HolidaySetting>>
    {
        public async Task<ErrorOr<Entities.HolidaySetting>> Handle(GetHolidaySettingByIdCommand request, CancellationToken cancellationToken)
        {
            var holidaySetting = await _context.ImtHolidaySettings.FirstAsync(e => e.Id == request.Id, cancellationToken: cancellationToken).ConfigureAwait(false);
            if (holidaySetting == null)
            {
                return Error.NotFound("Holiday Setting not found!");
            }
            return holidaySetting;

        }
    }



}
