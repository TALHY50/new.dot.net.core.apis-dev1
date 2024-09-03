using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.Admin.Application.Features.CurrencyConversionRates;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Application.Rules;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.CreateCurrencyConversionRates
{
    //[Authorize]
    public record CreateCurrencyConversionRateCommand(
        uint corridor_id,
        decimal exchange_rate,
        decimal fx_spread,
        uint? company_id,
        StatusValues status
        ) : IRequest<ErrorOr<CurrencyConversionRate>>;

    public class CreateCurrencyConversionRateCommandValidator : AbstractValidator<CreateCurrencyConversionRateCommand>
    {
        public CreateCurrencyConversionRateCommandValidator()
        {
            RuleFor(x => x.corridor_id).CorridorIdRule();
            RuleFor(x => x.exchange_rate).ExchangeRateRule();
            RuleFor(x => x.fx_spread).FxSpreadRule();
            RuleFor(x => x.company_id).CompanyIdRule();
            RuleFor(x => x.status).NotEmpty().IsInEnum().WithMessage("Status is required");
        }
    }

    public class CreateCurrencyConversionRateCommandHandler(ILogger<CreateCurrencyConversionRateCommandHandler> logger, ApplicationDbContext dbContext, ITransactionHandler transactionHandler, ICurrencyConversionRateRepository repository)
        : CurrencyConversionRateBase, IRequestHandler<CreateCurrencyConversionRateCommand, ErrorOr<CurrencyConversionRate>>
    {
        private readonly ILogger<CreateCurrencyConversionRateCommandHandler> _logger = logger;

        public async Task<ErrorOr<CurrencyConversionRate>> Handle(CreateCurrencyConversionRateCommand command, CancellationToken cancellationToken)
        {
            var currencyConversionRate = new CurrencyConversionRate
            {
                CorridorId = command.corridor_id,
                ExchangeRate = command.exchange_rate, //Exchange rate between currencies
                FxSpread = command.fx_spread, //Foreign exchange spread
                CompanyId = 0,
                Status = (byte) command.status, // 0=inactive, 1=active, 2=pending, 3=rejected 
                CreatedById = 1,
                UpdatedById = 1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            var result = await transactionHandler.ExecuteWithTransactionAsync<CurrencyConversionRate>(
                async (ct) =>
                {
                    var obj = await repository.AddAsync(currencyConversionRate, cancellationToken);
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
