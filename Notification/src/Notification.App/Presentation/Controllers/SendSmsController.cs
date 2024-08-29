using Microsoft.AspNetCore.Mvc;

using Notification.App.Application.Features.Notifications.Send;

using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Models;

namespace Notification.App.Presentation.Controllers;

public class SendSmsController : ApiControllerBase
{
    [HttpPost("/api/notification/send/sms")]
    public async Task<ActionResult<ErrorOr.ErrorOr<Result>>> Create(SendSmsCommand command)
    {
        return await Mediator.Send(command).ConfigureAwait(false);
    }
}