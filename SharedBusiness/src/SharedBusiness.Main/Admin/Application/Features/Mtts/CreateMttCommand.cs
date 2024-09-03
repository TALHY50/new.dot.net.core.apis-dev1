using Ardalis.Specification;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;
using Microsoft.AspNetCore.Authorization;
using SharedKernel.Main.Application.Rules;
using Microsoft.Extensions.Logging;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.Admin.Application.Features.Mtts;
using SharedKernel.Main.Application.Enums;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Infrastructure.Persistence;
using ACL.Business.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories;
using SharedKernel.Main.Contracts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using ACL.Business.Domain.Services;
using Microsoft.AspNetCore.Http;
using ACL.Business.Infrastructure.Auth.Auth;

namespace Admin.Web.Application.Features.Mtts
{

    [Authorize]

    public record CreateMttCommand(
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
    StatusValues status) : IRequest<ErrorOr<Mtt>>;


    public class CreateMttCommandValidator : AbstractValidator<CreateMttCommand>
    {
        public CreateMttCommandValidator()
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
    public class CreateMttCommandHandler : MttBase, IRequestHandler<CreateMttCommand, ErrorOr<Mtt>>
    {
        private readonly ICurrentUser _user;
        private readonly IMTTRepository _repository;
        private readonly ICorridorRepository _corridorRepository;
        private readonly IPayerRepository _payerRepository;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly ICompanyService _companyRepository;
        private readonly ApplicationDbContext _dbContext;
        private readonly ACL.Business.Infrastructure.Persistence.Context.ApplicationDbContext _otherDbContext;
        public static IHttpContextAccessor HttpContextAccessor;
        private readonly ITransactionHandler _transactionHandler;
        // Constructor
        public CreateMttCommandHandler(
            ILogger<CreateMttCommandHandler> logger,
            ApplicationDbContext dbContext,
            ITransactionHandler transactionHandler,
            IMTTRepository repository,
            ICurrentUser user, ACL.Business.Infrastructure.Persistence.Context.ApplicationDbContext otherDbContext, ICorridorRepository corridorRepository, IPayerRepository payerRepository, ICurrencyRepository currencyRepository, ICompanyService companyRepository, IHttpContextAccessor httpContextAccessor) : base(logger, user)
        {
            _user = user ?? throw new ArgumentNullException(nameof(user));
            var _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _corridorRepository = corridorRepository ?? throw new ArgumentNullException(nameof(corridorRepository));
            _payerRepository = payerRepository ?? throw new ArgumentNullException(nameof(payerRepository));
            _currencyRepository = currencyRepository ?? throw new ArgumentNullException(nameof(currencyRepository));
            _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _otherDbContext = otherDbContext ?? throw new ArgumentNullException(nameof(otherDbContext));
            _transactionHandler = transactionHandler ?? throw new ArgumentNullException(nameof(transactionHandler));
            HttpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            AppAuth.Initialize(HttpContextAccessor, _otherDbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
        }
        public async Task<ErrorOr<Mtt>> Handle(CreateMttCommand request, CancellationToken cancellationToken)
        {
            if (request.corridor_id != null && request.corridor_id > 0)
            {
                Corridor? corridor = await _corridorRepository.GetByIdAsync((uint)request.corridor_id, cancellationToken);
                if (corridor == null)
                {
                    return Error.NotFound(description: "corridor not found",
                    code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
                }
            }
            if (request.currency_id != null && request.currency_id > 0)
            {
                Currency? currency = await _currencyRepository.GetByIdAsync((uint)request.currency_id, cancellationToken);
                if (currency == null)
                {
                    return Error.NotFound(description: "currency not found",
                        code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
                }
            }
            Company? company = await _companyRepository.GetByIdAsync(request.company_id, cancellationToken);
            Payer? payer = await _payerRepository.GetByIdAsync(request.payer_id, cancellationToken);

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
            var entity = new Mtt
            {
                CompanyId = request.company_id,
                CorridorId = request.corridor_id,
                //  CotCurrencyId = request.CotCurrencyId,
                CotFixed = request.cot_fixed,
                CotPercentage = request.cot_percentage,
                FxSpread = request.fx_spread,
                Increment = request.increment,
                //  MarkUpCurrencyId = request.MarkUpCurrencyId,
                MarkUpFixed = request.mark_up_fixed,
                MarkUpPercentage = request.mark_up_percentage,
                MoneyPrecision = request.money_precision,
                PayerId = request.payer_id,
                ServiceMethodId = request.service_method_id,
                Status = (byte)((int)request.status),
                TransactionTypeId = request.transaction_type_id
            };

            entity.CreatedById = uint.Parse(_user?.UserId ?? "1");
            entity.UpdatedById = uint.Parse(_user?.UserId ?? "1");
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;

            var result = await _transactionHandler.ExecuteWithTransactionAsync<Mtt>(
               async (ct) =>
               {
                   var obj = await _repository.AddAsync(entity, cancellationToken);
                   return obj;

               }, _dbContext, 3, cancellationToken
           );

            if (result.IsError)
            {
                return result;
            }

            return result.Value;
        }
    }
}