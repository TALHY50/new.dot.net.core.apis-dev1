
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;



namespace SharedBusiness.Main.Admin.Application.Features.TransactionLimits
{
    public record CreateTransactionLimitCommand(
         sbyte transaction_type,

         int daily_total_number,

         decimal daily_total_amount,

         int monthly_total_number,

        decimal monthly_total_amount,

        uint currency_id) : IRequest<ErrorOr<TransactionLimit>>;

    public class CreateTransactionLimitCommandValidator : AbstractValidator<CreateTransactionLimitCommand>
    {
        public CreateTransactionLimitCommandValidator()
        {
            RuleFor(x => x.transaction_type).GreaterThan((sbyte)0).NotEmpty().WithMessage("Transaction Type  is required");
            RuleFor(x => x.daily_total_number).GreaterThan(0).NotEmpty().WithMessage("Daily Total Number is required");
            RuleFor(x => x.daily_total_amount).GreaterThan(0m).NotEmpty().WithMessage("Daily Total Amount is required");
            RuleFor(x => x.monthly_total_number).GreaterThan(0).NotEmpty().WithMessage("Monthly Total Number is required");
            RuleFor(x => x.monthly_total_amount).GreaterThan(0m).NotEmpty().WithMessage("Monthly Total Amount is required");
            RuleFor(x => x.currency_id).NotEmpty().WithMessage("Currency is required").GreaterThan((uint)0).WithMessage("Currency is required");
        }
    }


    public class CreateTransactionLimitCommandHandler : IRequestHandler<CreateTransactionLimitCommand, ErrorOr<Common.Domain.Entities.TransactionLimit>>
    {
        private readonly ITransactionLimitRepository _repository;
       
        public CreateTransactionLimitCommandHandler(ITransactionLimitRepository repository)
        {
            _repository = repository;
        }


        public async Task<ErrorOr<TransactionLimit>> Handle(CreateTransactionLimitCommand request, CancellationToken cancellationToken)
        {
            var transactionLimit = new TransactionLimit
            {
                CurrencyId = request.currency_id,
                DailyTotalAmount = request.daily_total_amount,
                MonthlyTotalAmount = request.monthly_total_amount,
                DailyTotalNumber = request.daily_total_number,
                MonthlyTotalNumber = request.monthly_total_number,
                TransactionType = request.transaction_type,

                UserCategory = 1,
                CreatedById = 1,
                UpdatedById = 1,

                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };


            bool currencyExist =  _repository.IsCurrencyExist(request.currency_id);

            if (!currencyExist)
            {
                return Error.NotFound(description: Language.GetMessage("Currency not found"), code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }
            var result = await _repository.AddAsync(transactionLimit, cancellationToken);
              
            return result;



        }
    }
}
