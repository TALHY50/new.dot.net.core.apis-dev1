using ErrorOr;

using Microsoft.AspNetCore.Mvc;

using Notification.App.Application.Features.Notifications.Outgoing;
using Notification.App.Domain.Entities.Outgoings;

using SharedKernel.Main.Application.Common;

namespace Notification.App.Presentation.Controllers;

public class CreateWebOutgoingController : ApiControllerBase
{
    [HttpPost("/api/notification/outgoing/web/create")]
    public async Task<ActionResult<ErrorOr<WebOutgoing>>> Create(CreateWebOutgoingCommand command)
    {
        return await Mediator.Send(command).ConfigureAwait(false);
    }
}