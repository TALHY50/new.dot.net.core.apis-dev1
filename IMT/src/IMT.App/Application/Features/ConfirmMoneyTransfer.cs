using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using IMT.App.Application.Common;
using SharedKernel.Main.Infrastructure.Persistence;

namespace IMT.App.Application.Features;

public class ConfirmTransferController : ApiControllerBase
{
    [HttpPost("/api/money-transfer/international/confirm")]
    public async Task<ActionResult<ErrorOr<object>>> Create(ConfirmMoneyTransfer command)
    {
        return await Mediator.Send(command).ConfigureAwait(false);
    }
}

public record ConfirmMoneyTransfer(int Id) : IRequest<ErrorOr<object>>;

internal sealed class ConfirmMoneyTransferValidator : AbstractValidator<ConfirmMoneyTransfer>
{
    public ConfirmMoneyTransferValidator()
    {
        RuleFor(v => v.Id)
            .GreaterThan(0)
            .NotEmpty();
    }
}

internal sealed class ConfirmMoneyTransferHandler(ApplicationDbContext context)
    : IRequestHandler<ConfirmMoneyTransfer, ErrorOr<object>>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<ErrorOr<object>> Handle(ConfirmMoneyTransfer request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();

    }
}