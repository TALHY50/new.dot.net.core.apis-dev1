using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;


namespace Admin.App.Application.Features.HolidaySetting;

public class DeleteHolidaySettingByIdController : ApiControllerBase
{
    //[Authorize(Policy = "HasPermission")]
    [HttpDelete(Routes.DeleteHolidaySettingUrl, Name = Routes.DeleteHolidaySettingName)]
    public async Task<ActionResult<ErrorOr<bool>>> Delete(uint id)
    {
        return await Mediator.Send(new DeleteHolidaySettingCommand(id)).ConfigureAwait(false);
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
                return Error.NotFound("Holiday Setting not found!");
            }
            _context.ImtHolidaySettings.Remove(holidaySetting);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            // need to modify return type
            return true;
        }
    }




}
