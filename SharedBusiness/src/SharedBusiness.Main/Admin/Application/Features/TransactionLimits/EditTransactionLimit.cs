using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;



namespace SharedBusiness.Main.Admin.Application.Features.TransactionLimits
{

        public record UpdateTransactionLimitCommand(

         uint id,

         sbyte TransactionType,

         sbyte UserCategory,

         int DailyTotalNumber,

         decimal DailyTotalAmount,

         int MonthlyTotalNumber,

        decimal MonthlyTotalAmount,

        uint CurrencyId) : IRequest<ErrorOr<TransactionLimit>>;

        public class UpdateTransactionLimitCommandValidator : AbstractValidator<UpdateTransactionLimitCommand>
        {
            public UpdateTransactionLimitCommandValidator()
            {
                RuleFor(x => x.TransactionType).GreaterThan((sbyte)0).NotEmpty().WithMessage("Transaction Type  is required");
                RuleFor(x => x.UserCategory).GreaterThan((sbyte)0).NotEmpty().WithMessage("User Category  is required");
                RuleFor(x => x.DailyTotalNumber).GreaterThan(0).NotEmpty().WithMessage("Daily Total Number is required");
                RuleFor(x => x.DailyTotalAmount).GreaterThan(0m).NotEmpty().WithMessage("Daily Total Amount is required");
                RuleFor(x => x.MonthlyTotalNumber).GreaterThan(0).NotEmpty().WithMessage("Monthly Total Number is required");
                RuleFor(x => x.MonthlyTotalAmount).GreaterThan(0m).NotEmpty().WithMessage("Monthly Total Amount is required");
                RuleFor(x => x.CurrencyId).NotEmpty().WithMessage("Currency is required").GreaterThan((uint)0).WithMessage("Currency is required");
            }
        }

        public class UpdateTransactionLimitCommandHandler : IRequestHandler<UpdateTransactionLimitCommand, ErrorOr<TransactionLimit>>
        {
            private readonly ITransactionLimitRepository _repository;

            public UpdateTransactionLimitCommandHandler(ITransactionLimitRepository repository)
            {
                _repository = repository;
            }

            public async Task<ErrorOr<TransactionLimit>> Handle(UpdateTransactionLimitCommand request, CancellationToken cancellationToken)
            {
                var transactionLimit = new TransactionLimit
                {
                    CurrencyId = request.CurrencyId,
                    DailyTotalAmount = request.DailyTotalAmount,
                    MonthlyTotalAmount = request.MonthlyTotalAmount,
                    DailyTotalNumber = request.DailyTotalNumber,
                    MonthlyTotalNumber = request.MonthlyTotalNumber,
                    TransactionType = request.TransactionType,
                    UserCategory = request.UserCategory,

                    CreatedById = 1,
                    UpdatedById = 1,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                };

                return  _repository.Edit(request.id,transactionLimit);
            }
        }

}

