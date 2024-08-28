using ErrorOr;
using FluentValidation;
using IMT.App.Infrastructure.Persistence.Context;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using Thunes.Route;

namespace IMT.App.Application.Features;

public class CreateQuotation : ApiControllerBase
{
    [Tags("Quotation")]
    [HttpPost(ImtRoute.CreateQuotationRouteUrl,Name = ImtRoute.CreateQuotationRouteName)]
    public async Task<ActionResult<ErrorOr<object>>> CreateMoneyTransferQuotation(CreateMoneyTransferQuotation command)
    {
        return await Mediator.Send(command).ConfigureAwait(false);
    }
}

public record CreateMoneyTransferQuotation(string invoice_id, int mode, int transaction_type, decimal amount, Source source, Destination destination) : IRequest<ErrorOr<object>>;

public class Destination
{
    public string country_iso_code { get; set; }
    public string currency { get; set; }
}

public class Source
{
    public string country_iso_code { get; set; }
    public string currency { get; set; }
}

internal sealed class CreateMoneyTransferQuotationValidator : AbstractValidator<CreateMoneyTransferQuotation>
{
    public CreateMoneyTransferQuotationValidator()
    {
        RuleFor(v => v.invoice_id).NotEmpty().WithMessage("invoice_id is required").ToErrorOr();
        RuleFor(v => v.mode).NotEmpty().WithMessage("mode is required").ToErrorOr();
        RuleFor(v => v.transaction_type).NotEmpty().WithMessage("transaction_type is required").ToErrorOr();
        RuleFor(v => v.amount).NotEmpty().WithMessage("amount is required").ToErrorOr();
        RuleFor(v => v.source).NotEmpty().WithMessage("source is required").ToErrorOr();
        RuleFor(v => v.source.country_iso_code).NotEmpty().WithMessage("source.country_iso_code is required").ToErrorOr();
        RuleFor(v => v.source.currency).NotEmpty().WithMessage("source.currency is required").ToErrorOr();
        RuleFor(v => v.destination).NotEmpty().WithMessage("destination is required").ToErrorOr();
        RuleFor(v => v.destination.country_iso_code).NotEmpty().WithMessage("destination.country_iso_code is required").ToErrorOr();
        RuleFor(v => v.destination.currency).NotEmpty().WithMessage("destination.currency is required").ToErrorOr();
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