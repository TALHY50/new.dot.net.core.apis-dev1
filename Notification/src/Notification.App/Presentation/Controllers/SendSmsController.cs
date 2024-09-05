using Microsoft.AspNetCore.Mvc;

using Notification.App.Application.Features.Notifications.Send;

using SharedKernel.Main.Application.Models;
using SharedKernel.Main.Presentation;

namespace Notification.App.Presentation.Controllers;

public class SendSmsController : ApiControllerBase
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [HttpPost("/api/notification/send/sms")]
    public async Task<ActionResult<ErrorOr.ErrorOr<Result>>> Create(SendSmsCommand command)
    {
        return await Mediator.Send(command).ConfigureAwait(false);
    }
}