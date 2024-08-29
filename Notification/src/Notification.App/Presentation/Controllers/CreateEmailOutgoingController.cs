using ErrorOr;

using Microsoft.AspNetCore.Mvc;

using Notification.App.Application.Features.Notifications.Outgoing;
using Notification.App.Domain.Entities.Outgoings;

using SharedKernel.Main.Application.Common;

namespace Notification.App.Presentation.Controllers;

public class CreateEmailOutgoingController : ApiControllerBase
{
    [HttpPost("/api/notification/outgoing/email/create")]
    public async Task<ActionResult<ErrorOr<EmailOutgoing>>> Create(CreateEmailOutgoingCommand command)
    {
        return await Mediator.Send(command).ConfigureAwait(false);
    }
}