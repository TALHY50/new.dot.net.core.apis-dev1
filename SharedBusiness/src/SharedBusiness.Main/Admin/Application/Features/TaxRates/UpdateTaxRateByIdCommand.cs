using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Application.Rules;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.TaxRates
{
    public record UpdateTaxRateByIdCommand(
        uint id,
        byte tax_type,
        uint? corridor_id,
        uint? country_id,
        uint? tax_currency_id,
        decimal tax_percentage,
        decimal tax_fixed,
        uint? company_id,
        StatusValues status) : IRequest<ErrorOr<TaxRate>>;

    public class UpdateTaxRateByIdCommandValidator : AbstractValidator<UpdateTaxRateByIdCommand>
    {
        public UpdateTaxRateByIdCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("TaxRate ID is required");
            RuleFor(x => x.tax_type).TaxTypeRule();
            RuleFor(x => x.corridor_id).CorridorIdRule();
            RuleFor(x => x.country_id).CountryIdRule();
            RuleFor(x => x.tax_currency_id).TaxCurrencyId();
            RuleFor(x => x.tax_percentage).TaxPercentageRule();
            RuleFor(x => x.tax_fixed).TaxFixedRule();
            RuleFor(x => x.company_id).CompanyIdRule();
            RuleFor(x => x.status).NotEmpty().IsInEnum();
        }
    }

    public class UpdateTaxRateByIdCommandHandler : TaxRateBase, IRequestHandler<UpdateTaxRateByIdCommand, ErrorOr<TaxRate>>
    {
        private readonly ITaxRateRepository _repository;
        private readonly IGuardAgainstNullUpdate _guard;

        public UpdateTaxRateByIdCommandHandler(ITaxRateRepository repository, IGuardAgainstNullUpdate guard)
        {
            _repository = repository;
            _guard = guard;
        }

        public async Task<ErrorOr<TaxRate>> Handle(UpdateTaxRateByIdCommand command, CancellationToken cancellationToken)
        {
            TaxRate? taxRate = await _repository.GetByIdAsync(command.id, cancellationToken);
            if (taxRate == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }


            // Update properties conditionally using the helper function
            _guard.UpdateIfNotNullOrEmpty(value => taxRate.TaxType = value, command.tax_type);
            _guard.UpdateIfNotNullOrEmpty(value => taxRate.CorridorId = value, command.corridor_id);
            _guard.UpdateIfNotNullOrEmpty(value => taxRate.CountryId = value, command.country_id);
            _guard.UpdateIfNotNullOrEmpty(value => taxRate.TaxCurrencyId = value, command.tax_currency_id);
            _guard.UpdateIfNotNullOrEmpty(value => taxRate.TaxPercentage = value, command.tax_percentage);
            _guard.UpdateIfNotNullOrEmpty(value => taxRate.TaxFixed = value, command.tax_fixed);
            _guard.UpdateIfNotNullOrEmpty(value => taxRate.CompanyId = value, command.company_id);

            taxRate.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(taxRate, cancellationToken);

            return taxRate;


        }
    }
    }
