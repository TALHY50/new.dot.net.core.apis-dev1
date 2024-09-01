using ErrorOr;

using Microsoft.AspNetCore.Mvc;

using Notification.App.Application.Features.Notifications.Outgoing;
using Notification.App.Domain.Entities.Outgoings;

using SharedKernel.Main.Presentation;

namespace Notification.App.Presentation.Controllers;

public class CreateSmsOutgoingController : ApiControllerBase
{
    [HttpPost("/api/notification/outgoing/sms/create")]
    public async Task<ActionResult<ErrorOr<SmsOutgoing>>> Create(CreateSmsOutgoingCommand command)
    {
        return await Mediator.Send(command).ConfigureAwait(false);
    }
}