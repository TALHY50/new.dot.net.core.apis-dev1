using ErrorOr;

using FluentValidation;

using MediatR;

using Notification.App.Application.Interfaces.Repositories;
using Notification.App.Application.Interfaces.Services;
using Notification.App.Contracts;
using Notification.App.Infrastructure.Persistence.Context;

using SharedKernel.Main.Application.Common.Interfaces;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Application.Common.Models;

using Result = SharedKernel.Main.Application.Common.Models.Result;

namespace Notification.App.Application.Features.Notifications.Send;

public record SendEmailCommand(OutgoingId OutgoingId) : IRequest<ErrorOr<Result>>;

public class SendEmailCommandValidator : AbstractValidator<SendEmailCommand>
{
    public SendEmailCommandValidator()
    {
        /*RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();*/
    }
}

public class SendEmailCommandHandler(
    ILogger<SendEmailCommandHandler> logger,
    ApplicationDbContext context,
    IEmailOutgoingRepository emailOutgoingRepository,
    ICredentialRepository credentialRepository,
    IRenderer renderer,
    IHostEnvironment environment,
    IEmailService emailService) : IRequestHandler<SendEmailCommand, ErrorOr<Result>>
{
    private readonly ApplicationDbContext _context = context;
    private readonly ILogger _logger = logger;
    private readonly IEmailOutgoingRepository _emailOutgoingRepository = emailOutgoingRepository;
    private readonly ICredentialRepository _credentialRepository = credentialRepository;
    private readonly IEmailService _emailService = emailService;
    private readonly IRenderer _renderer = renderer;
    private readonly IHostEnvironment _environment = environment;

    public async Task<ErrorOr<Result>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
    {
        var emailOutgoing = await _emailOutgoingRepository.FindActiveRecordByIdAsync(request.OutgoingId.Value, cancellationToken).ConfigureAwait(false);

        if (emailOutgoing is null)
        {
            return Error.NotFound(description: "Record not found!");
        }

        var credential =
            await _credentialRepository.FindByIdAsync(emailOutgoing.NotificationCredentialId, cancellationToken).ConfigureAwait(false);

        if (credential is null)
        {
            return Error.NotFound(description: "Credential not found!");
        }

        IEmailSender? emailSender = await _emailService.GetEmailSender(credential).ConfigureAwait(false);

        if (emailSender is null)
        {
            return Error.NotFound(description: "Sender not found!");
        }

        Result result = await emailSender.SendEmailAsync(emailOutgoing.To.Split(',').ToList(), credential.FromAddress, emailOutgoing.Subject, emailOutgoing.Content).ConfigureAwait(false);

        if (result.Succeeded.Type == Status.Completed.Type)
        {
            emailOutgoing.Status = Status.Completed.Type;
        }
        else
        {
            emailOutgoing.Status = Status.Failed.Type;
        }

        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return result;
    }
}