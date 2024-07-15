using FluentValidation;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Notification.Application.Contracts;
using Notification.Main.Application.Common;
using Notification.Main.Domain.Todos;
using Notification.Main.Infrastructure.Persistence;

namespace Notification.Main.Application.Features.Notifications.Send;

public class SendWebhookController : ApiControllerBase
{
    [HttpPost("/api/notification/send/webhook")]
    public async Task<ActionResult<int>> Create(SendWebhookCommand command)
    {
        return await Mediator.Send(command);
    }
}

public record SendWebhookCommand(OutgoingId OutgoingId) : IRequest<int>;

internal sealed class SendWebhookCommandValidator : AbstractValidator<SendWebhookCommand>
{
    public SendWebhookCommandValidator()
    {
        /*RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();*/
    }
}

internal sealed class SendWebhookCommandHandler(ApplicationDbContext context) : IRequestHandler<SendWebhookCommand, int>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<int> Handle(SendWebhookCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask.ConfigureAwait(false);
        return 0;
    }
}