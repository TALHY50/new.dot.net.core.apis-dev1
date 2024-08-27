using ErrorOr;

using FluentValidation;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Interfaces;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Application.Common.Models;
using SharedKernel.Main.Infrastructure.Persistence;
using SharedKernel.Main.Notification.Application.Interfaces.Repositories;
using SharedKernel.Main.Notification.Contracts;
using SharedKernel.Main.Notification.Infrastructure.Persistence.Context;

using Result = SharedKernel.Main.Application.Common.Models.Result;

namespace Notification.App.Application.Features.Notifications.Send;

public class SendWebhookController : ApiControllerBase
{
    [HttpPost("/api/notification/send/webhook")]
    public async Task<ActionResult<ErrorOr<Result>>> Create(SendWebhookCommand command)
    {
        return await Mediator.Send(command).ConfigureAwait(false);
    }
}

public record SendWebhookCommand(OutgoingId OutgoingId) : IRequest<ErrorOr<Result>>;

internal sealed class SendWebhookCommandValidator : AbstractValidator<SendWebhookCommand>
{
    public SendWebhookCommandValidator()
    {
        /*RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();*/
    }
}

internal sealed class SendWebhookCommandHandler(
    ILogger<SendWebhookCommandHandler> logger,
    ApplicationDbContext context,
    IWebOutgoingRepository webOutgoingRepository,
    ICredentialRepository credentialRepository,
    IWebService webService) : IRequestHandler<SendWebhookCommand, ErrorOr<Result>>
{
    private readonly ApplicationDbContext _context = context;
    private readonly ILogger _logger = logger;
    private readonly IWebOutgoingRepository _webOutgoingRepository = webOutgoingRepository;
    private readonly ICredentialRepository _credentialRepository = credentialRepository;
    private readonly IWebService _webService = webService;

    public async Task<ErrorOr<Result>> Handle(SendWebhookCommand request, CancellationToken cancellationToken)
    {
        var outgoing = await _webOutgoingRepository.FindActiveRecordByIdAsync(request.OutgoingId.Value, cancellationToken).ConfigureAwait(false);

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

        Result result = await _webService.SendWebhookAsync(outgoing.Host.Split(',').ToList(), outgoing.Content).ConfigureAwait(false);

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