using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Application.Rules;
using SharedKernel.Main.Contracts;


namespace SharedBusiness.Main.Admin.Application.Features.Payers
{
    public record UpdatePayerByIdCommand(
        uint id,
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

    public class UpdatePayerByIdCommandValidator : AbstractValidator<UpdatePayerByIdCommand>
    {
        public UpdatePayerByIdCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Id is required");
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

    public class UpdatePayerByIdCommandHandler : PayerBase, IRequestHandler<UpdatePayerByIdCommand, ErrorOr<Payer>>
    {
        private readonly IPayerRepository _repository;
        private readonly IGuardAgainstNullUpdate _guard;

        public UpdatePayerByIdCommandHandler(IPayerRepository repository, IGuardAgainstNullUpdate guard)
        {
            _repository = repository;
            _guard = guard;
        }

        public async Task<ErrorOr<Payer>> Handle(UpdatePayerByIdCommand command, CancellationToken cancellationToken)
        {
            Payer? payer = await _repository.GetByIdAsync(command.id, cancellationToken);
            if (payer == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }


            // Update properties conditionally using the helper function
            _guard.UpdateIfNotNullOrEmpty(value => payer.Name = value, command.Name);
            _guard.UpdateIfNotNullOrEmpty(value => payer.ProviderId = value, command.CorridorId);
            _guard.UpdateIfNotNullOrEmpty(value => payer.InternalPayerId = value, command.InternalPayerId);
            _guard.UpdateIfNotNullOrEmpty(value => payer.FundCurrencyId = value, command.FundCurrencyId);
            _guard.UpdateIfNotNullOrEmpty(value => payer.Increment = value, command.Increment);
            _guard.UpdateIfNotNullOrEmpty(value => payer.MoneyPrecision = value, command.MoneyPrecision);
            _guard.UpdateIfNotNullOrEmpty(value => payer.ServiceMethodId = value, command.ServiceMethodId);
            _guard.UpdateIfNotNullOrEmpty(value => payer.TransactionTypeIds = value, command.TransactionTypeIds);
            _guard.UpdateIfNotNullOrEmpty(value => payer.SourceAmountMax = value, command.SourceAmountMax);
            _guard.UpdateIfNotNullOrEmpty(value => payer.SourceAmountMin = value, command.SourceAmountMin);
            _guard.UpdateIfNotNullOrEmpty(value => payer.DestinationAmountMax = value, command.DestinationAmountMax);
            _guard.UpdateIfNotNullOrEmpty(value => payer.DestinationAmountMin = value, command.DestinationAmountMin);
            _guard.UpdateIfNotNullOrEmpty(value => payer.CotCurrencyId = value, command.CotCurrencyId);
            _guard.UpdateIfNotNullOrEmpty(value => payer.CotPercentage = value, command.CotPercentage);
            _guard.UpdateIfNotNullOrEmpty(value => payer.CotFixed = value, command.CotFixed);
            _guard.UpdateIfNotNullOrEmpty(value => payer.FxSpread = value, command.FxSpread);
            _guard.UpdateIfNotNullOrEmpty(value => payer.PaymentSpeed = value, command.PaymentSpeed);
            _guard.UpdateIfNotNullOrEmpty(value => payer.CompanyId = value, command.CompanyId);

            payer.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(payer, cancellationToken);

            return payer;


        }

    }
}
