using Microsoft.AspNetCore.Mvc;

using Notification.App.Application.Features.Notifications.Send;

using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Models;

namespace Notification.App.Presentation.Controllers;

public class SendEmailController : ApiControllerBase
{
    [HttpPost("/api/notification/send/email")]
    public async Task<ErrorOr.ErrorOr<Result>> Create(SendEmailCommand command)
    {
        return await Mediator.Send(command).ConfigureAwait(false);
    }
}