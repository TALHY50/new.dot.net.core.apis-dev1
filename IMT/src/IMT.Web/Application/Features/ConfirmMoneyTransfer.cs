using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notification.App.Infrastructure.Persistence.Configurations;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedKernel.Main.Presentation;

namespace IMT.App.Application.Features;

public class ConfirmTransferController : ApiControllerBase
{
    [HttpPost("/money-transfer/international/confirm")]
    public async Task<ActionResult<ErrorOr<object>>> Create(ConfirmMoneyTransfer command)
    {
        return await Mediator.Send(command).ConfigureAwait(false);
    }
}

public record ConfirmMoneyTransfer(int Id) : IRequest<ErrorOr<object>>;

public class ConfirmMoneyTransferValidator : AbstractValidator<ConfirmMoneyTransfer>
{
    public ConfirmMoneyTransferValidator()
    {
        RuleFor(v => v.Id)
            .GreaterThan(0)
            .NotEmpty();
    }
}

public class Handler(ApplicationDbContext context)
    : IRequestHandler<ConfirmMoneyTransfer, ErrorOr<object>>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<ErrorOr<object>> Handle(ConfirmMoneyTransfer request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();

    }
}