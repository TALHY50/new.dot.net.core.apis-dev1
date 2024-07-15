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
using Notification.Main.Domain.Todos;
using Notification.Main.Infrastructure.Persistence;
using Notification.RazorTemplateEngine.Services;

using RazorHtmlEmails.RazorClassLib.Views.Emails.ConfirmAccount;

namespace Notification.Main.Application.Features.Notifications.Send;

public class SendEmailController : ApiControllerBase
{
    [HttpPost("/api/notification/send/email")]
    public async Task<ActionResult<ErrorOr<bool>>> Create(SendEmailCommand command)
    {
        return await Mediator.Send(command);
    }
}

public record SendEmailCommand(OutgoingId OutgoingId) : IRequest<ErrorOr<bool>>;

internal sealed class SendEmailCommandValidator : AbstractValidator<SendEmailCommand>
{
    public SendEmailCommandValidator()
    {
        /*RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();*/
    }
}

internal sealed class SendEmailCommandHandler(
    ILogger<SendEmailCommandHandler> logger,
    ApplicationDbContext context,
    IEmailOutgoingRepository emailOutgoingRepository,
    ICredentialRepository credentialRepository,
    IRazorViewToStringRenderer razorViewToStringRenderer,
    IHostEnvironment environment,
    IEmailService emailService) : IRequestHandler<SendEmailCommand, ErrorOr<bool>>
{
    private readonly ApplicationDbContext _context = context;
    private readonly ILogger _logger = logger;
    private readonly IEmailOutgoingRepository _emailOutgoingRepository = emailOutgoingRepository;
    private readonly ICredentialRepository _credentialRepository = credentialRepository;
    private readonly IEmailService _emailService = emailService;
    private readonly IRazorViewToStringRenderer _razorViewToStringRenderer = razorViewToStringRenderer;
    private readonly IHostEnvironment _environment = environment;

    public async Task<ErrorOr<bool>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;
        var emailOutgoing = await _emailOutgoingRepository.FindActiveRecordByIdAsync(request.OutgoingId.Value, cancellationToken).ConfigureAwait(false);

        if (emailOutgoing is null)
        {
            return Error.NotFound(description: "outgoing record not found");
        }

        var credential =
            await _credentialRepository.FindByIdAsync(emailOutgoing.NotificationCredentialId, cancellationToken).ConfigureAwait(false);

        if (credential is null)
        {
            return Error.NotFound(description: "credential not found");
        }

        IEmailSender? emailSender = await _emailService.GetEmailSender(credential).ConfigureAwait(false);

        if (emailSender is null)
        {
            return Error.NotFound(description: "email sender not found");
        }

        await emailSender.SendEmailAsync(emailOutgoing.To.Split(',').ToList(), credential.FromAddress, emailOutgoing.Subject, emailOutgoing.Content).ConfigureAwait(false);

        return false;
    }
}