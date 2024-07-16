using FluentValidation;

using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Notification.App.Application.Common;
using Notification.Main.Infrastructure.Persistence;

namespace Notification.App.Application.Features.Notifications;

public class TestIndexController : ApiControllerBase
{
    [HttpPost("/api/notification/test/index")]
    public async Task<ActionResult<int>> Create(TestIndexCommand command)
    {
        return await Mediator.Send(command);
    }
}

public record TestIndexCommand(int Clean) : IRequest<int>;

internal sealed class TestIndexCommandValidator : AbstractValidator<TestIndexCommand>
{
    public TestIndexCommandValidator()
    {
        /*RuleFor(v => v.Event.Category)
            .MaximumLength(200)
            .NotEmpty();*/
    }
}

internal sealed class TestIndexCommandHandler(ApplicationDbContext context) : IRequestHandler<TestIndexCommand, int>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<int> Handle(TestIndexCommand request, CancellationToken cancellationToken)
    {
        int clean = request.Clean;

        if (clean == 1)
        {
            await _context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE notification_event_templates", cancellationToken: cancellationToken).ConfigureAwait(false);
            await _context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE notification_events", cancellationToken: cancellationToken).ConfigureAwait(false);
            await _context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE notification_app_event_data", cancellationToken: cancellationToken).ConfigureAwait(false);
            await _context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE notification_email_events", cancellationToken: cancellationToken).ConfigureAwait(false);
            await _context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE notification_sms_events", cancellationToken: cancellationToken).ConfigureAwait(false);
            await _context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE notification_web_events", cancellationToken: cancellationToken).ConfigureAwait(false);
            await _context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE notification_email_outgoings", cancellationToken: cancellationToken).ConfigureAwait(false);
            await _context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE notification_sms_outgoings", cancellationToken: cancellationToken).ConfigureAwait(false);
            await _context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE notification_web_outgoings", cancellationToken: cancellationToken).ConfigureAwait(false);
            return 1;
        }

        return 0;
    }
}