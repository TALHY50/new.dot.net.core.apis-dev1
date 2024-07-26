using ErrorOr;

using FluentValidation;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using Notification.App.Application.Common;
using Notification.App.Application.Common.Interfaces;
using Notification.App.Application.Common.Interfaces.Repositories;
using Notification.App.Application.Common.Models;
using Notification.App.Contracts;
using Notification.App.Infrastructure.Persistence;
using Notification.Main.Infrastructure.Persistence;

using Result = Notification.App.Application.Common.Models.Result;

namespace Notification.App.Application.Features.Notifications.Send;

public class SendSmsController : ApiControllerBase
{
    [HttpPost("/api/notification/send/sms")]
    public async Task<ActionResult<ErrorOr<Result>>> Create(SendSmsCommand command)
    {
        return await Mediator.Send(command).ConfigureAwait(false);
    }
}

public record SendSmsCommand(OutgoingId OutgoingId) : IRequest<ErrorOr<Result>>;

internal sealed class SendSmsCommandValidator : AbstractValidator<SendSmsCommand>
{
    public SendSmsCommandValidator()
    {
        /*RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();*/
    }
}

internal sealed class SendSmsCommandHandler(
    ILogger<SendSmsCommandHandler> logger,
    ApplicationDbContext context,
    ISmsOutgoingRepository smsOutgoingRepository,
    ICredentialRepository credentialRepository,
    ISmsService smsService) : IRequestHandler<SendSmsCommand, ErrorOr<Result>>
{
    private readonly ApplicationDbContext _context = context;
    private readonly ILogger _logger = logger;
    private readonly ISmsOutgoingRepository _emailOutgoingRepository = smsOutgoingRepository;
    private readonly ICredentialRepository _credentialRepository = credentialRepository;
    private readonly ISmsService _smsService = smsService;

    public async Task<ErrorOr<Result>> Handle(SendSmsCommand request, CancellationToken cancellationToken)
    {
        var outgoing = await _emailOutgoingRepository.FindActiveRecordByIdAsync(request.OutgoingId.Value, cancellationToken).ConfigureAwait(false);

        if (outgoing is null)
        {
            return Error.NotFound(description: "Record not found!");
        }

        var credential =
            await _credentialRepository.FindByIdAsync(outgoing.NotificationCredentialId, cancellationToken).ConfigureAwait(false);

        if (credential is null)
        {
            return Error.NotFound(description: "Credential not found!");
        }

        ISmsSender? sender = await _smsService.GetSmsSender(credential).ConfigureAwait(false);

        if (sender is null)
        {
            return Error.NotFound(description: "Sender not found!");
        }

        Result result = await sender.SendSmsAsync(outgoing.To.Split(',').ToList(), credential.FromAddress, string.Empty, outgoing.Content).ConfigureAwait(false);

        if (result.Succeeded.Type == Status.Completed.Type)
        {
            outgoing.Status = Status.Completed.Type;
        }
        else
        {
            outgoing.Status = Status.Failed.Type;
        }

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return result;
    }
}