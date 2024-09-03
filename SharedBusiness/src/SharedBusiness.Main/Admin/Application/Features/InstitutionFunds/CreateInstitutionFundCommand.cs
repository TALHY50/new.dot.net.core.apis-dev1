using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedBusiness.Main.Common.Application.Features.Countries;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Application.Rules;

namespace SharedBusiness.Main.Admin.Application.Features.InstitutionFunds
{
    public record CreateInstitutionFundCommand(
        uint institution_id,
        uint provider_id,
        uint fund_country_id,
        uint fund_currency_id,
        string account_number,
        decimal starting_amount,
        decimal current_amount,
        uint? company_id,
        StatusValues status
        ) : IRequest<ErrorOr<InstitutionFund>>;

    public class CreateInstitutionFundCommandValidator : AbstractValidator<CreateInstitutionFundCommand>
    {
        public CreateInstitutionFundCommandValidator()
        {
            RuleFor(x => x.institution_id).InstitutionIdRule();
            RuleFor(x => x.provider_id).ProviderIdRule();
            RuleFor(x => x.fund_country_id).FundCountryIdRule();
            RuleFor(x => x.fund_currency_id).FundCurrencyIdRule();
            RuleFor(x => x.account_number).AccountNumberRule();
            RuleFor(x => x.starting_amount).StartingAmountRule();
            RuleFor(x => x.company_id).CompanyIdRule();
            RuleFor(x => x.status).NotEmpty().IsInEnum();
        }
    }

    public class CreateInstitutionFundCommandHandler(ILogger<CreateInstitutionFundCommandHandler> logger, ApplicationDbContext dbContext, ITransactionHandler transactionHandler, IInstitutionFundRepository repository)
        : InstitutionFundBase, IRequestHandler<CreateInstitutionFundCommand, ErrorOr<InstitutionFund>>
    {
        private readonly ILogger<CreateInstitutionFundCommandHandler> _logger = logger;

        public async Task<ErrorOr<InstitutionFund>> Handle(CreateInstitutionFundCommand command, CancellationToken cancellationToken)
        {
            var institutionFund = new InstitutionFund
            {
                InstitutionId = command.institution_id,
                ProviderId = command.provider_id,
                FundCountryId = command.fund_country_id,
                FundCurrencyId = command.fund_currency_id,
                AccountNumber = command.account_number,
                StartingAmount = command.starting_amount,
                CurrentAmount = command.current_amount,
                CompanyId = 0,
                Status = (byte)command.status,
                CreatedById = 0,
                UpdatedById = 0,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };
            var result = await transactionHandler.ExecuteWithTransactionAsync<InstitutionFund>(
                async (ct) =>
                {
                    var obj = await repository.AddAsync(institutionFund, cancellationToken);
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
