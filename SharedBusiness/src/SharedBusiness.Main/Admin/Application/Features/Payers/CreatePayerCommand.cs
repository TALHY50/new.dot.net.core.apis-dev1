
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Application.Rules;

namespace SharedBusiness.Main.Admin.Application.Features.Payers
{
    public record CreatePayerCommand(
        string Name,
        uint? ProviderId,
        uint? CorridorId,
        string InternalPayerId,
        uint? FundCurrencyId,
        decimal Increment,
        byte MoneyPrecision,
        uint? ServiceMethodId,
        string TransactionTypeIds,
        decimal SourceAmountMax,
        decimal SourceAmountMin,
        decimal DestinationAmountMax,
        decimal DestinationAmountMin,
        uint? CotCurrencyId,
        decimal CotPercentage,
        decimal CotFixed,
        decimal FxSpread,
        string PaymentSpeed,
        uint? CompanyId,
        StatusValues Status) : IRequest<ErrorOr<Payer>>;
    public class CreatePayerCommandValidator : AbstractValidator<CreatePayerCommand>
    {
        public CreatePayerCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("name is required");
            RuleFor(x => x.InternalPayerId).NotEmpty().WithMessage("InternalPayerId is required");
            RuleFor(x => x.Increment).NotEmpty().IncrementRule();
            RuleFor(x => x.MoneyPrecision).NotEmpty().MoneyPrecisionRule();
            RuleFor(x => x.TransactionTypeIds).NotEmpty().WithMessage("TransactionTypeIds is required");
            RuleFor(x => x.SourceAmountMax).NotEmpty().WithMessage("SourceAmountMax is required");
            RuleFor(x => x.SourceAmountMin).NotEmpty().WithMessage("SourceAmountMin is required");
            RuleFor(x => x.DestinationAmountMax).NotEmpty().WithMessage("DestinationAmountMax is required");
            RuleFor(x => x.DestinationAmountMin).NotEmpty().WithMessage("DestinationAmountMin is required");
            RuleFor(x => x.CotPercentage).NotEmpty().CotPercentageRule();
            RuleFor(x => x.CotFixed).NotEmpty().CotFixedRule();
            RuleFor(x => x.FxSpread).NotEmpty().FxSpreadRule();
            RuleFor(x => x.PaymentSpeed).NotEmpty().WithMessage("PaymentSpeed is required");
        }
    }
    public class CreatePayerCommandHandler(ILogger<CreatePayerCommandHandler> logger, ApplicationDbContext dbContext, ITransactionHandler transactionHandler, IPayerRepository repository)
        : PayerBase, IRequestHandler<CreatePayerCommand, ErrorOr<Payer>>
    {
        private readonly ILogger<CreatePayerCommandHandler> _logger = logger;
        public async Task<ErrorOr<Payer?>> Handle(CreatePayerCommand request, CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;
            var payer = new Payer
            {
                Name = request.Name,
                ProviderId = request.ProviderId,
                CorridorId = request.CorridorId,
                InternalPayerId = request.InternalPayerId,
                FundCurrencyId = request.FundCurrencyId,
                Increment = request.Increment,
                MoneyPrecision = request.MoneyPrecision,
                ServiceMethodId = request.ServiceMethodId,
                TransactionTypeIds = request.TransactionTypeIds,
                SourceAmountMax = request.SourceAmountMax,
                SourceAmountMin = request.SourceAmountMin,
                DestinationAmountMax = request.DestinationAmountMax,
                DestinationAmountMin = request.DestinationAmountMin,
                CotCurrencyId = request.CotCurrencyId,
                CotPercentage = request.CotPercentage,
                CotFixed = request.CotFixed,
                FxSpread = request.FxSpread,
                PaymentSpeed = request.PaymentSpeed,
                CompanyId = request.CompanyId,
                Status = (byte) request.Status,
                CreatedById = 1,
                UpdatedById = 2,
                CreatedAt = now,
                UpdatedAt = now
            };
            var result = await transactionHandler.ExecuteWithTransactionAsync<Payer>(
                async (ct) =>
                {
                    var obj = await repository.AddAsync(payer, cancellationToken);
                    return obj;
                }, dbContext, 3, cancellationToken
            );
            if (result.IsError)
            {
                return result;
            }
            return result.Value;
        }
    }
}
