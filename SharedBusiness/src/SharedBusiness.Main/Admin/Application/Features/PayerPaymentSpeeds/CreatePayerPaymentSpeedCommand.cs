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

namespace SharedBusiness.Main.Admin.Application.Features.PayerPaymentSpeeds
{
    public record CreatePayerPaymentSpeedCommand(
        uint payer_id,
        uint processing_time,
        string gmt,
        string working_days,
        bool is_processing_during_banking_holiday,
        StatusValues status
        ) : IRequest<ErrorOr<PayerPaymentSpeed>>;

    public class CreatePayerPaymentSpeedCommandValidator : AbstractValidator<CreatePayerPaymentSpeedCommand>
    {
        public CreatePayerPaymentSpeedCommandValidator()
        {
            RuleFor(x => x.payer_id).PayerIdRule();
            RuleFor(x => x.processing_time).ProcessingTimeRule();
            RuleFor(x => x.gmt).GmtRule();
            RuleFor(x => x.working_days).WorkingDaysRule();
            RuleFor(x => x.is_processing_during_banking_holiday).IsProcessingDuringBankingHolidayRule();
            RuleFor(x => x.status).NotEmpty().IsInEnum();
        }
    }

    public class CreatePayerPaymentSpeedCommandHandler(ILogger<CreatePayerPaymentSpeedCommandHandler> logger, ApplicationDbContext dbContext, ITransactionHandler transactionHandler, IPayerPaymentSpeedRepository repository)
        : PayerPaymentSpeedBase, IRequestHandler<CreatePayerPaymentSpeedCommand, ErrorOr<PayerPaymentSpeed>>
    {
        private readonly ILogger<CreatePayerPaymentSpeedCommandHandler> _logger = logger;

        public async Task<ErrorOr<PayerPaymentSpeed>> Handle(CreatePayerPaymentSpeedCommand command, CancellationToken cancellationToken)
        {
            var payerPaymentSpeed = new PayerPaymentSpeed
            {
                PayerId = command.payer_id,
                ProcessingTime = command.processing_time,
                Gmt = command.gmt,
                OpenAt = DateTime.UtcNow,
                CloseAt = DateTime.UtcNow,
                WorkingDays = command.working_days,
                IsProcessingDuringBankingHoliday = command.is_processing_during_banking_holiday,
                CompanyId = 0,
                Status = (byte)command.status,
                CreatedById = 0,
                UpdatedById = 0,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };
            var result = await transactionHandler.ExecuteWithTransactionAsync<PayerPaymentSpeed>(
                async (ct) =>
                {
                    var obj = await repository.AddAsync(payerPaymentSpeed, cancellationToken);
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
