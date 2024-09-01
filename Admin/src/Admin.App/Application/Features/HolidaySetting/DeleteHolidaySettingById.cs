using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts.Common;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace Admin.App.Application.Features.HolidaySetting;

public class DeleteHolidaySettingByIdController : ApiControllerBase
{
    //[Authorize(Policy = "HasPermission")]
    [HttpDelete(Routes.DeleteHolidaySettingUrl, Name = Routes.DeleteHolidaySettingName)]
    public async Task<ActionResult<ErrorOr<bool>>> Delete(uint id)
    {
        var result = await Mediator.Send(new DeleteHolidaySettingCommand(id)).ConfigureAwait(false);
        return result.Match(
            reminder => Ok(result.Value),
            Problem);
    }

    public record DeleteHolidaySettingCommand(uint Id) : IRequest<ErrorOr<bool>>;

    public class DeleteHolidaySettingCommandValidator : AbstractValidator<DeleteHolidaySettingCommand>
    {
        public DeleteHolidaySettingCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Setting holiday ID is required");
        }
    }

    internal sealed class DeleteHolidaySettingCommandHandler(ApplicationDbContext _context, IHolidaySettingRepository repository) : IRequestHandler<DeleteHolidaySettingCommand, ErrorOr<bool>>
    {
        public async Task<ErrorOr<bool>> Handle(DeleteHolidaySettingCommand request, CancellationToken cancellationToken)
        {

            // ToDo delete logic
            var holidaySetting = await _context.ImtHolidaySettings.FirstAsync(e => e.Id == request.Id, cancellationToken: cancellationToken).ConfigureAwait(false);
            if (holidaySetting == null)
            {
                return Error.NotFound("Holiday Setting not found!", ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }

            // Check holiday setting has child table. If exist not delete holiday

            _context.ImtHolidaySettings.Remove(holidaySetting);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            // need to modify return type
            return true;
        }
    }




}
