using ErrorOr;

using FluentValidation;

using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using IMT.App.Application.Common;
using IMT.App.Contracts;
using IMT.App.Infrastructure.Persistence;
using SharedKernel.Main.Infrastructure.Persistence.Configurations;

namespace IMT.App.Application.Features;

public class CreateMoneyTransferController : ApiControllerBase
{
    [HttpPost("/api/notification/event/sms/create")]
    public async Task<ActionResult<ErrorOr<object>>> Create(ConfirmMoneyTransfer command)
    {
        return await Mediator.Send(command).ConfigureAwait(false);
    }
}

public record ConfirmMoneyTransfer(int Id) : IRequest<ErrorOr<object>>;

internal sealed class CConfirmMoneyTransferValidator : AbstractValidator<ConfirmMoneyTransfer>
{
    public CConfirmMoneyTransferValidator()
    {
        /*RuleFor(v => v.CategoricalData.Category)
            .MaximumLength(200)
            .NotEmpty();*/
    }
}

internal sealed class CConfirmMoneyTransferHandler(ApplicationDbContext context)
    : IRequestHandler<ConfirmMoneyTransfer, ErrorOr<object>>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<ErrorOr<object>> Handle(ConfirmMoneyTransfer request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();

    }
}