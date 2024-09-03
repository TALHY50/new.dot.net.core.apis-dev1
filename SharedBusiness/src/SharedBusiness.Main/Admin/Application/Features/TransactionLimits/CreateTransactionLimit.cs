
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;



namespace SharedBusiness.Main.Admin.Weblication.Features.TransactionLimits
{
    public record CreateTransactionLimitCommand(
         sbyte TransactionType,

         int DailyTotalNumber,

         decimal DailyTotalAmount,

         int MonthlyTotalNumber,

        decimal MonthlyTotalAmount,

        uint CurrencyId) : IRequest<ErrorOr<TransactionLimit>>;

    public class CreateTransactionLimitCommandValidator : AbstractValidator<CreateTransactionLimitCommand>
    {
        public CreateTransactionLimitCommandValidator()
        {
            RuleFor(x => x.TransactionType).GreaterThan((sbyte)0).NotEmpty().WithMessage("Transaction Type  is required");
            RuleFor(x => x.DailyTotalNumber).GreaterThan(0).NotEmpty().WithMessage("Daily Total Number is required");
            RuleFor(x => x.DailyTotalAmount).GreaterThan(0m).NotEmpty().WithMessage("Daily Total Amount is required");
            RuleFor(x => x.MonthlyTotalNumber).GreaterThan(0).NotEmpty().WithMessage("Monthly Total Number is required");
            RuleFor(x => x.MonthlyTotalAmount).GreaterThan(0m).NotEmpty().WithMessage("Monthly Total Amount is required");
            RuleFor(x => x.CurrencyId).NotEmpty().WithMessage("Currency is required").GreaterThan((uint)0).WithMessage("Currency is required");
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
                CurrencyId = request.CurrencyId,
                DailyTotalAmount = request.DailyTotalAmount,
                MonthlyTotalAmount = request.MonthlyTotalAmount,
                DailyTotalNumber = request.DailyTotalNumber,
                MonthlyTotalNumber = request.MonthlyTotalNumber,
                TransactionType = request.TransactionType,

                UserCategory = 1,
                CreatedById = 1,
                UpdatedById = 1,

                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };


            bool currencyExist =  _repository.IsCurrencyExist(request.CurrencyId);

            if (!currencyExist)
            {
                return Error.NotFound(description: "Currency not found", code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }
            var result = await _repository.AddAsync(transactionLimit, cancellationToken);
              
            return result;



        }
    }
}
