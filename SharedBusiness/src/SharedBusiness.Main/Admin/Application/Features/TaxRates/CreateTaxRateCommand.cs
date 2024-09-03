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

namespace SharedBusiness.Main.Admin.Application.Features.TaxRates
{
    public record CreateTaxRateCommand(
        byte tax_type,
        uint? corridor_id,
        uint? country_id,
        uint? tax_currency_id,
        decimal tax_percentage,
        decimal tax_fixed,
        uint? company_id,
        StatusValues status
        ) : IRequest<ErrorOr<TaxRate>>;

    public class CreateTaxRateCommandValidator : AbstractValidator<CreateTaxRateCommand>
    {
        public CreateTaxRateCommandValidator()
        {
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

    public class CreateTaxRateCommandHandler(ILogger<CreateTaxRateCommandHandler> logger, ApplicationDbContext dbContext, ITransactionHandler transactionHandler, ITaxRateRepository repository)
        : TaxRateBase, IRequestHandler<CreateTaxRateCommand, ErrorOr<TaxRate>>
    {
        private readonly ILogger<CreateTaxRateCommandHandler> _logger = logger;

        public async Task<ErrorOr<TaxRate>> Handle(CreateTaxRateCommand command, CancellationToken cancellationToken)
        {
            var taxRate = new TaxRate
            {
                TaxType = command.tax_type,
                CorridorId = command.corridor_id,
                CountryId = command.country_id,
                TaxCurrencyId = command.tax_currency_id,
                TaxPercentage = command.tax_percentage,
                TaxFixed = command.tax_fixed,
                CompanyId = 0,
                Status = (byte)command.status, 
                CreatedById = 0,
                UpdatedById = 0,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };
            var result = await transactionHandler.ExecuteWithTransactionAsync<TaxRate>(
                async (ct) =>
                {
                    var obj = await repository.AddAsync(taxRate, cancellationToken);
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
