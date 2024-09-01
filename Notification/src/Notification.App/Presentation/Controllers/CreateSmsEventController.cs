using ErrorOr;

using Microsoft.AspNetCore.Mvc;

using Notification.App.Application.Features.Notifications.Events;
using Notification.App.Domain.Entities.Events;

using SharedKernel.Main.Presentation;

namespace Notification.App.Presentation.Controllers;

public class CreateSmsEventController : ApiControllerBase
{
    [HttpPost("/api/notification/event/sms/create")]
    public async Task<ActionResult<ErrorOr<Event>>> Create(CreateSmsEventCommand command)
    {
        return await Mediator.Send(command).ConfigureAwait(false);
    }
}