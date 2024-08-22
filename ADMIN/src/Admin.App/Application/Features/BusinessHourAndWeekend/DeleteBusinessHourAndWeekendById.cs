using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.Notification.Notifications.Events;

namespace ADMIN.App.Application.Features.BusinessHourAndWeekend;

public class DeleteBusinessHourAndWeekendByIdController : ApiControllerBase
{
    //[Authorize(Policy = "HasPermission")]
    [HttpPost(Routes.DeleteBusinessHourAndWeekendUrl, Name = Routes.DeleteBusinessHourAndWeekendName)]
    public async Task<ActionResult<ErrorOr<Event>>> Delete(DeleteBusinessHourAndWeekendCommand command, int id)
    {
        return await Mediator.Send(command).ConfigureAwait(false);
    }

    public record DeleteBusinessHourAndWeekendCommand(int Id) : IRequest<ErrorOr<Event>>;

    public class DeleteBusinessHourAndWeekendCommandValidator : AbstractValidator<DeleteBusinessHourAndWeekendCommand>
    {
        public DeleteBusinessHourAndWeekendCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Business hour and weekend ID is required");
        }
    }

    internal sealed class DeleteBusinessHourAndWeekendCommandHandler() : IRequestHandler<DeleteBusinessHourAndWeekendCommand, ErrorOr<Event>>
    {
        public Task<ErrorOr<Event>> Handle(DeleteBusinessHourAndWeekendCommand request, CancellationToken cancellationToken)
        {

            // ToDo delete logic

            throw new NotImplementedException();
        }
    }




}
