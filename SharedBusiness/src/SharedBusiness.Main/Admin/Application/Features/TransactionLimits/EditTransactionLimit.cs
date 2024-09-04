
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;



namespace SharedBusiness.Main.Admin.Application.Features.TransactionLimits
{

    public record UpdateTransactionLimitCommand(

     uint id,

     sbyte transaction_type,

     int daily_total_number,

     decimal daily_total_amount,

     int monthly_total_number,

     decimal monthly_total_amount,

     uint currency_id) : IRequest<ErrorOr<TransactionLimit>>;

    public class UpdateTransactionLimitCommandValidator : AbstractValidator<UpdateTransactionLimitCommand>
    {
        public UpdateTransactionLimitCommandValidator()
        {
            RuleFor(x => x.transaction_type).GreaterThan((sbyte)0).NotEmpty().WithMessage("Transaction Type  is required");
            RuleFor(x => x.daily_total_number).GreaterThan(0).NotEmpty().WithMessage("Daily Total Number is required");
            RuleFor(x => x.daily_total_amount).GreaterThan(0m).NotEmpty().WithMessage("Daily Total Amount is required");
            RuleFor(x => x.monthly_total_number).GreaterThan(0).NotEmpty().WithMessage("Monthly Total Number is required");
            RuleFor(x => x.monthly_total_amount).GreaterThan(0m).NotEmpty().WithMessage("Monthly Total Amount is required");
            RuleFor(x => x.currency_id).NotEmpty().WithMessage("Currency is required").GreaterThan((uint)0).WithMessage("Currency is required");
        }
    }

    public class UpdateTransactionLimitCommandHandler : IRequestHandler<UpdateTransactionLimitCommand, ErrorOr<TransactionLimit>>
    {
        private readonly ITransactionLimitRepository _repository;
        private readonly IGuardAgainstNullUpdate _guard;

        public UpdateTransactionLimitCommandHandler(ITransactionLimitRepository repository, IGuardAgainstNullUpdate guard)
        {
            _repository = repository;
            _guard = guard;
        }


        public async Task<ErrorOr<Common.Domain.Entities.TransactionLimit>> Handle(UpdateTransactionLimitCommand command, CancellationToken cancellationToken)
        {

            bool transactionTypeExist = _repository.IsTransactionTypeExist(command.transaction_type);

            if (!transactionTypeExist)
            {
                return Error.NotFound(description: Language.GetMessage("Transaction Type not found"), code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }


            bool currencyExist = _repository.IsCurrencyExist(command.currency_id);

            if (!currencyExist)
            {
                return Error.NotFound(description: Language.GetMessage("Currency not found"), code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }

            Common.Domain.Entities.TransactionLimit? transactionLimit = await _repository.GetByIdAsync(command.id, cancellationToken);
            if (transactionLimit == null)
            {
                return Error.NotFound(description: Language.GetMessage("Transaction Limit not found"),
                    code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }


            // Update properties conditionally using the helper function
            _guard.UpdateIfNotNullOrEmpty(value => transactionLimit.DailyTotalAmount = value, command.daily_total_amount);
            _guard.UpdateIfNotNullOrEmpty(value => transactionLimit.DailyTotalNumber = value, command.daily_total_number);
            _guard.UpdateIfNotNullOrEmpty(value => transactionLimit.CurrencyId = value, command.currency_id);
            _guard.UpdateIfNotNullOrEmpty(value => transactionLimit.MonthlyTotalAmount = value, command.monthly_total_amount);
            _guard.UpdateIfNotNullOrEmpty(value => transactionLimit.MonthlyTotalNumber = value, command.monthly_total_number);

            transactionLimit.TransactionType = command.transaction_type;
            transactionLimit.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(transactionLimit, cancellationToken);

            return transactionLimit;


        }
    }

}

