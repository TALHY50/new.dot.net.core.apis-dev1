using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Application.Rules;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.CurrencyConversionRates
{
    public record UpdateCurrencyConversionRateByIdCommand(
        uint id,
        uint corridor_id,
        decimal exchange_rate,
        decimal fx_spread,
        uint? company_id,
        StatusValues status) : IRequest<ErrorOr<CurrencyConversionRate>>;

    public class UpdateCurrencyConversionRateCommandValidator : AbstractValidator<UpdateCurrencyConversionRateByIdCommand>
    {
        public UpdateCurrencyConversionRateCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Country ID is required");
            RuleFor(x => x.corridor_id).CorridorIdRuleRequired();
            RuleFor(x => x.exchange_rate).ExchangeRateRule();
            RuleFor(x => x.fx_spread).FxSpreadRule();
            RuleFor(x => x.company_id).CompanyIdRule();
            RuleFor(x => x.status).IsInEnum();
        }
    }

    public class UpdateCurrencyConversionRateCommandHandler : CurrencyConversionRateBase, IRequestHandler<UpdateCurrencyConversionRateByIdCommand, ErrorOr<CurrencyConversionRate>>
    {
        private readonly ICurrencyConversionRateRepository _repository;
        private readonly IGuardAgainstNullUpdate _guard;

        public UpdateCurrencyConversionRateCommandHandler(ICurrencyConversionRateRepository repository, IGuardAgainstNullUpdate guard)
        {
            _repository = repository;
            _guard = guard;
        }

        public async Task<ErrorOr<CurrencyConversionRate>> Handle(UpdateCurrencyConversionRateByIdCommand command, CancellationToken cancellationToken)
        {
            CurrencyConversionRate? currencyConversionRate = await _repository.GetByIdAsync(command.id, cancellationToken);
            if (currencyConversionRate == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }


            // Update properties conditionally using the helper function
            _guard.UpdateIfNotNullOrEmpty(value => currencyConversionRate.CorridorId = value, command.corridor_id);
            _guard.UpdateIfNotNullOrEmpty(value => currencyConversionRate.ExchangeRate = value, command.exchange_rate);
            _guard.UpdateIfNotNullOrEmpty(value => currencyConversionRate.FxSpread = value, command.fx_spread);
            _guard.UpdateIfNotNullOrEmpty(value => currencyConversionRate.CompanyId = value, command.company_id);

            currencyConversionRate.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(currencyConversionRate, cancellationToken);

            return currencyConversionRate;


        }

    }
}
