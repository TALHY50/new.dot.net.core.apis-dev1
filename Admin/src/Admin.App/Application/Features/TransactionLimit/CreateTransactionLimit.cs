
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;

namespace Admin.App.Application.Features.TransactionTypes
{
    public class CreateTransactionLimitController : ApiControllerBase
    {
        [Tags("Transaction Limit")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(Routes.CreateTransactionLimitUrl, Name = Routes.CreateTransactionLimitName)]
        public async Task<ActionResult<ErrorOr<TransactionLimit>>> Create(CreateTransactionLimitCommand command)
        {
            var result = await Mediator.Send(command).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }

    public record CreateTransactionLimitCommand(
         sbyte? TransactionType,

         sbyte? UserCategory,

         int? DailyTotalNumber,

         decimal? DailyTotalAmount,

         int? MonthlyTotalNumber,

        decimal? MonthlyTotalAmount,

        uint? CurrencyId) : IRequest<ErrorOr<TransactionLimit>>;

    public class CreateTransactionLimitCommandValidator : AbstractValidator<CreateTransactionLimitCommand>
    {
        public CreateTransactionLimitCommandValidator()
        {
            RuleFor(x => x.TransactionType).NotEmpty().WithMessage("Transaction Type  is required");
            RuleFor(x => x.UserCategory).NotEmpty().WithMessage("User Category  is required");
            RuleFor(x => x.DailyTotalNumber).NotEmpty().WithMessage("Daily Total Number is required");
            RuleFor(x => x.DailyTotalAmount).NotEmpty().WithMessage("Daily Total Amount is required");
            RuleFor(x => x.MonthlyTotalNumber).NotEmpty().WithMessage("Monthly Total Number is required");
            RuleFor(x => x.MonthlyTotalAmount).NotEmpty().WithMessage("Monthly Total Amount is required");
            RuleFor(x => x.CurrencyId).NotEmpty().WithMessage("Currency is required");
        }
    }


    public class CreateTransactionLimitCommandHandler : IRequestHandler<CreateTransactionLimitCommand, ErrorOr<TransactionLimit>>
    {
        private readonly IImtTransactionLimitRepository _transactionLimitRepository;

        public CreateTransactionLimitCommandHandler(IImtTransactionLimitRepository transactionLimitRepository)
        {
            _transactionLimitRepository = transactionLimitRepository;
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
                UserCategory = request.UserCategory,

                CreatedById = 1,
                UpdatedById = 1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            return await _transactionLimitRepository.AddAsync(transactionLimit);
        }
    }
}
