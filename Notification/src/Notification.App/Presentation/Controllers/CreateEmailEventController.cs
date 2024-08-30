using ErrorOr;

using Microsoft.AspNetCore.Mvc;

using Notification.App.Application.Features.Notifications.Events;
using Notification.App.Contracts.Responses;
using Notification.App.Domain.Entities.Events;

using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Constants.Routes;

namespace Notification.App.Presentation.Controllers;

public class CreateEmailEventController : ApiControllerBase
{
    // [Authorize(Policy = "HasPermission")]
    [HttpPost(Routes.CreateEmailEventRoute, Name = Routes.CreateEmailEventRouteName)]
    public async Task<ActionResult<ErrorOr<Event>>> Create(CreateEmailEventCommand command)
    {
        var result = await Mediator.Send(command).ConfigureAwait(false);

        return result.Match(
            @event => Ok(ToSuccess(Mapper.Map<NotificationEventResponse>(@event))),
            Problem);
    }
}