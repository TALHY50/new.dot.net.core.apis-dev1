using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Infrastructure.Persistence.Context;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace Admin.App.Application.Features.BusinessHourAndWeekend;

public class DeleteBusinessHourAndWeekendByIdController : ApiControllerBase
{
    //[Authorize(Policy = "HasPermission")]
    [HttpDelete(Routes.DeleteBusinessHourAndWeekendUrl, Name = Routes.DeleteBusinessHourAndWeekendName)]
    public async Task<ActionResult<ErrorOr<bool>>> Delete(uint id)
    {
        var result = await Mediator.Send(new DeleteBusinessHourAndWeekendCommand(id)).ConfigureAwait(false);
        return result.Match(
            reminder => Ok(result.Value),
            Problem);
    }

    public record DeleteBusinessHourAndWeekendCommand(uint Id) : IRequest<ErrorOr<bool>>;

    public class DeleteBusinessHourAndWeekendCommandValidator : AbstractValidator<DeleteBusinessHourAndWeekendCommand>
    {
        public DeleteBusinessHourAndWeekendCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Business hour and weekend ID is required");
        }
    }

    internal sealed class DeleteBusinessHourAndWeekendCommandHandler(ApplicationDbContext _context, IBusinessHourAndWeekendRepository repository) : IRequestHandler<DeleteBusinessHourAndWeekendCommand, ErrorOr<bool>>
    {
        public async Task<ErrorOr<bool>> Handle(DeleteBusinessHourAndWeekendCommand request, CancellationToken cancellationToken)
        {

            // ToDo delete logic
            var businessHourAndWeekend = await _context.ImtBusinessHoursAndWeekends.FirstAsync(e => e.Id == request.Id, cancellationToken: cancellationToken).ConfigureAwait(false);
            if (businessHourAndWeekend == null)
            {
                return Error.NotFound("Business hour and weekend not found!", AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
            }
            _context.ImtBusinessHoursAndWeekends.Remove(businessHourAndWeekend);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            // need to modify return type
            return true;
        }
    }




}
