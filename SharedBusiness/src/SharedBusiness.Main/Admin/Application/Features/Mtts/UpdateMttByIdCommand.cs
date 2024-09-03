using ACL.Business.Domain.Entities;
using ACL.Business.Domain.Services;
using ACL.Business.Infrastructure.Auth.Auth;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Mtts;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Application.Rules;
using SharedKernel.Main.Contracts;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

namespace SharedBusiness.Main.Admin.Application.Features.Mtts
{

    [Authorize]
    public record UpdateMttByIdCommand(uint id,
        uint? corridor_id,
        uint? currency_id,
        uint payer_id,
        uint? service_method_id,
        uint transaction_type_id,
        decimal cot_percentage,
        decimal cot_fixed,
        decimal fx_spread,
        decimal mark_up_percentage,
        decimal mark_up_fixed,
        decimal increment,
        byte money_precision,
        uint company_id,
StatusValues status)
      : IRequest<ErrorOr<Mtt>>;


    public class UpdateMttByIdCommandValidator : AbstractValidator<UpdateMttByIdCommand>
    {
        public UpdateMttByIdCommandValidator()
        {
            RuleFor(r => r.payer_id).NotEmpty().PayerIdRule();
            RuleFor(r => r.transaction_type_id).NotEmpty().TransactionTypeIdRule();
            RuleFor(r => r.cot_percentage).NotEmpty().CotPercentageRule();
            RuleFor(r => r.cot_fixed).NotEmpty().CotFixedRule();
            RuleFor(r => r.fx_spread).NotEmpty().FxSpreadRule();
            RuleFor(r => r.mark_up_percentage).NotEmpty().MarkUpPercentageRule();
            RuleFor(r => r.mark_up_fixed).NotEmpty().MarkUpFixedRule();
            RuleFor(r => r.increment).NotEmpty().IncrementRule();
            RuleFor(r => r.money_precision).NotEmpty().MoneyPrecisionRule();
            RuleFor(x => x.status).NotEmpty().IsInEnum();
        }
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public class UpdateMttByIdCommandHandler : MttBase, IRequestHandler<UpdateMttByIdCommand, ErrorOr<Mtt>>
    {
        private readonly IMTTRepository _repository;
        private readonly ICorridorRepository _corridorRepository;
        private readonly IPayerRepository _payerRepository;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly ICompanyService _companyRepository;
        public static IHttpContextAccessor HttpContextAccessor;
        private readonly ACL.Business.Infrastructure.Persistence.Context.ApplicationDbContext _otherDbContext;
        private readonly IGuardAgainstNullUpdate _guard;

        public UpdateMttByIdCommandHandler(IMTTRepository repository, ICorridorRepository corridorRepository, IPayerRepository payerRepository, ICurrencyRepository currencyRepository, ICompanyService companyRepository, IGuardAgainstNullUpdate guard, IHttpContextAccessor httpContextAccessor, ACL.Business.Infrastructure.Persistence.Context.ApplicationDbContext otherDbContext)
        {
            _repository = repository;
            _corridorRepository = corridorRepository;
            _companyRepository = companyRepository;
            _payerRepository = payerRepository;
            _currencyRepository = currencyRepository;
            _guard = guard;
            _otherDbContext = otherDbContext;
            HttpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            AppAuth.Initialize(HttpContextAccessor, _otherDbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
        }

        public async Task<ErrorOr<Mtt>> Handle(UpdateMttByIdCommand command, CancellationToken cancellationToken)
        {
            Mtt? entity = await _repository.GetByIdAsync(command.id, cancellationToken);
            if (command.corridor_id != null && command.corridor_id > 0)
            {
                Corridor? corridor = await _corridorRepository.GetByIdAsync((uint)command.corridor_id, cancellationToken);
                if (corridor == null)
                {
                    return Error.NotFound(description: "corridor not found",
                        code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
                }
            }
            if (command.currency_id != null && command.currency_id > 0)
            {
                Currency? currency = await _currencyRepository.GetByIdAsync((uint)command.currency_id, cancellationToken);
                if (currency == null)
                {
                    return Error.NotFound(description: "currency not found",
                        code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
                }
            }
            Company? company = await _companyRepository.GetByIdAsync(command.company_id, cancellationToken);
            Payer? payer = await _payerRepository.GetByIdAsync(command.payer_id, cancellationToken);

            if (entity == null)
            {
                return Error.NotFound(description: "Mtt not found",
                    code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }
            if (company == null)
            {
                return Error.NotFound(description: "company not found",
                    code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }
            if (payer == null)
            {
                return Error.NotFound(description: "payer not found",
                    code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }


            // Update properties conditionally using the helper function
            _guard.UpdateIfNotNullOrEmpty(value => entity.PayerId = value, command.payer_id);
            _guard.UpdateIfNotNullOrEmpty(value => entity.TransactionTypeId = value, command.transaction_type_id);
            _guard.UpdateIfNotNullOrEmpty(value => entity.CotPercentage = value, command.cot_percentage);
            _guard.UpdateIfNotNullOrEmpty(value => entity.CotFixed = value, command.cot_fixed);
            _guard.UpdateIfNotNullOrEmpty(value => entity.FxSpread = value, command.fx_spread);
            _guard.UpdateIfNotNullOrEmpty(value => entity.MarkUpPercentage = value, command.mark_up_percentage);
            _guard.UpdateIfNotNullOrEmpty(value => entity.MarkUpFixed = value, command.mark_up_fixed);
            _guard.UpdateIfNotNullOrEmpty(value => entity.Increment = value, command.increment);
            _guard.UpdateIfNotNullOrEmpty(value => entity.MoneyPrecision = value, command.money_precision);

            entity.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(entity, cancellationToken);

            return entity;


        }

    }
}
