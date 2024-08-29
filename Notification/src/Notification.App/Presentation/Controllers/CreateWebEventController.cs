using ErrorOr;

using Microsoft.AspNetCore.Mvc;

using Notification.App.Application.Features.Notifications.Events;
using Notification.App.Domain.Entities.Events;

using SharedKernel.Main.Application.Common;

namespace Notification.App.Presentation.Controllers;

public class CreateWebEventController : ApiControllerBase
{
    [HttpPost("/api/notification/event/web/create")]
    public async Task<ActionResult<ErrorOr<Event>>> Create(CreateWebEventCommand command)
    {
        return await Mediator.Send(command).ConfigureAwait(false);
    }
}