using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Features.Countries;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Application.Rules;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.InstitutionFunds
{
    public record UpdateInstitutionFundCommand(
        uint id,
        uint institution_id,
        uint provider_id,
        uint fund_country_id,
        uint fund_currency_id,
        string account_number,
        decimal starting_amount,
        decimal current_amount,
        uint? company_id,
        StatusValues status) : IRequest<ErrorOr<InstitutionFund>>;

    public class UpdateInstitutionFundCommandValidator : AbstractValidator<UpdateInstitutionFundCommand>
    {
        public UpdateInstitutionFundCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("InstitutionFund ID is required");
            RuleFor(x => x.institution_id).InstitutionIdRule();
            RuleFor(x => x.provider_id).ProviderIdRule();
            RuleFor(x => x.fund_country_id).FundCountryIdRule();
            RuleFor(x => x.fund_currency_id).FundCurrencyIdRule();
            RuleFor(x => x.account_number).AccountNumberRule();
            RuleFor(x => x.starting_amount).StartingAmountRule();
            RuleFor(x => x.current_amount).CurrentAmountRule();
            RuleFor(x => x.status).IsInEnum();
        }
    }

    public class UpdateInstitutionFundCommandHandler : InstitutionFundBase, IRequestHandler<UpdateInstitutionFundCommand, ErrorOr<InstitutionFund>>
    {
        private readonly IInstitutionFundRepository _repository;
        private readonly IGuardAgainstNullUpdate _guard;

        public UpdateInstitutionFundCommandHandler(IInstitutionFundRepository repository, IGuardAgainstNullUpdate guard)
        {
            _repository = repository;
            _guard = guard;
        }

        public async Task<ErrorOr<InstitutionFund>> Handle(UpdateInstitutionFundCommand command, CancellationToken cancellationToken)
        {
            InstitutionFund? institutionFund = await _repository.GetByIdAsync(command.id, cancellationToken);
            if (institutionFund == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }


            // Update properties conditionally using the helper function
            _guard.UpdateIfNotNullOrEmpty(value => institutionFund.InstitutionId = value, command.institution_id);
            _guard.UpdateIfNotNullOrEmpty(value => institutionFund.ProviderId = value, command.provider_id);
            _guard.UpdateIfNotNullOrEmpty(value => institutionFund.FundCountryId = value, command.fund_country_id);
            _guard.UpdateIfNotNullOrEmpty(value => institutionFund.FundCurrencyId = value, command.fund_currency_id);
            _guard.UpdateIfNotNullOrEmpty(value => institutionFund.AccountNumber = value, command.account_number);
            _guard.UpdateIfNotNullOrEmpty(value => institutionFund.StartingAmount = value, command.starting_amount);
            _guard.UpdateIfNotNullOrEmpty(value => institutionFund.CurrentAmount = value, command.current_amount);
            _guard.UpdateIfNotNullOrEmpty(value => institutionFund.CompanyId = value, command.company_id);

            institutionFund.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(institutionFund, cancellationToken);

            return institutionFund;


        }

    }


}
