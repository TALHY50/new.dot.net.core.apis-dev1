using System.Net.Mail;
using System.Reflection;

using ACL.Application.Contracts;
using ACL.Application.Domain.Notifications.Outgoings;

using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Notification.Main.Application.Common;
using Notification.Main.Application.Common.Interfaces;
using Notification.Main.Application.Common.Interfaces.Repositories;
using Notification.Main.Application.Common.Models;
using Notification.Main.Domain.Todos;
using Notification.Main.Infrastructure.Persistence;
using Notification.Renderer.Services;

using Result = Notification.Main.Application.Common.Models.Result;

namespace Notification.Main.Application.Features.Notifications.Send;

public class SendSmsController : ApiControllerBase
{
    [HttpPost("/api/notification/send/sms")]
    public async Task<ActionResult<ErrorOr<bool>>> Create(SendSmsCommand command)
    {
        return await Mediator.Send(command);
    }
}

public record SendSmsCommand(OutgoingId OutgoingId) : IRequest<ErrorOr<bool>>;

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
    ISmsService smsService) : IRequestHandler<SendSmsCommand, ErrorOr<bool>>
{
    private readonly ApplicationDbContext _context = context;
    private readonly ILogger _logger = logger;
    private readonly ISmsOutgoingRepository _emailOutgoingRepository = smsOutgoingRepository;
    private readonly ICredentialRepository _credentialRepository = credentialRepository;
    private readonly ISmsService _smsService = smsService;

    public async Task<ErrorOr<bool>> Handle(SendSmsCommand request, CancellationToken cancellationToken)
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

        return true;
    }
}