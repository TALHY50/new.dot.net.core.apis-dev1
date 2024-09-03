using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Application.Rules;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.PayerPaymentSpeeds
{
    public record UpdatePayerPaymentSpeedCommand(
         uint id,
         uint payer_id,
         uint processing_time,
         string gmt,
         string working_days,
         bool is_processing_during_banking_holiday,
         StatusValues status) : IRequest<ErrorOr<PayerPaymentSpeed>>;

    public class UpdatePayerPaymentSpeedCommandValidator : AbstractValidator<UpdatePayerPaymentSpeedCommand>
    {
        public UpdatePayerPaymentSpeedCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("PayerPaymentSpeed ID is required");
            RuleFor(x => x.payer_id).PayerIdRule();
            RuleFor(x => x.processing_time).ProcessingTimeRule();
            RuleFor(x => x.gmt).GmtRule();
            RuleFor(x => x.working_days).WorkingDaysRule();
            RuleFor(x => x.is_processing_during_banking_holiday).IsProcessingDuringBankingHolidayRule();
            RuleFor(x => x.status).IsInEnum();
        }
    }

    public class UpdatePayerPaymentSpeedCommandHandler : PayerPaymentSpeedBase, IRequestHandler<UpdatePayerPaymentSpeedCommand, ErrorOr<PayerPaymentSpeed>>
    {
        private readonly IPayerPaymentSpeedRepository _repository;
        private readonly IGuardAgainstNullUpdate _guard;

        public UpdatePayerPaymentSpeedCommandHandler(IPayerPaymentSpeedRepository repository, IGuardAgainstNullUpdate guard)
        {
            _repository = repository;
            _guard = guard;
        }

        public async Task<ErrorOr<PayerPaymentSpeed>> Handle(UpdatePayerPaymentSpeedCommand command, CancellationToken cancellationToken)
        {
            PayerPaymentSpeed? payerPaymentSpeed = await _repository.GetByIdAsync(command.id, cancellationToken);
            if (payerPaymentSpeed == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }


            // Update properties conditionally using the helper function
            _guard.UpdateIfNotNullOrEmpty(value => payerPaymentSpeed.PayerId = value, command.payer_id);
            _guard.UpdateIfNotNullOrEmpty(value => payerPaymentSpeed.ProcessingTime = value, command.processing_time);
            _guard.UpdateIfNotNullOrEmpty(value => payerPaymentSpeed.Gmt = value, command.gmt);
            _guard.UpdateIfNotNullOrEmpty(value => payerPaymentSpeed.WorkingDays = value, command.working_days);
            _guard.UpdateIfNotNullOrEmpty(value => payerPaymentSpeed.IsProcessingDuringBankingHoliday = value, command.is_processing_during_banking_holiday);

            payerPaymentSpeed.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(payerPaymentSpeed, cancellationToken);

            return payerPaymentSpeed;


        }

    }
}
