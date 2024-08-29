using Microsoft.AspNetCore.Mvc;

using Notification.App.Application.Features.Notifications.Send;

using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Models;

namespace Notification.App.Presentation.Controllers;

public class SendWebhookController : ApiControllerBase
{
    [HttpPost("/api/notification/send/webhook")]
    public async Task<ActionResult<ErrorOr.ErrorOr<Result>>> Create(SendWebhookCommand command)
    {
        return await Mediator.Send(command).ConfigureAwait(false);
    }
}