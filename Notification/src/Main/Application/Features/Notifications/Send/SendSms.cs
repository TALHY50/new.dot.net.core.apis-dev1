using FluentValidation;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using ACL.Application.Contracts;
using Notification.Main.Application.Common;
using Notification.Main.Domain.Todos;
using Notification.Main.Infrastructure.Persistence;

namespace Notification.Main.Application.Features.Notifications.Send;

public class SendSmsController : ApiControllerBase
{
    [HttpPost("/api/notification/send/sms")]
    public async Task<ActionResult<int>> Create(SendSmsCommand command)
    {
        return await Mediator.Send(command);
    }
}

public record SendSmsCommand(OutgoingId OutgoingId) : IRequest<int>;

internal sealed class SendSmsCommandValidator : AbstractValidator<SendSmsCommand>
{
    public SendSmsCommandValidator()
    {
        /*RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();*/
    }
}

internal sealed class SendSmsCommandHandler(ApplicationDbContext context) : IRequestHandler<SendSmsCommand, int>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<int> Handle(SendSmsCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask.ConfigureAwait(false);
        return 0;
    }
}