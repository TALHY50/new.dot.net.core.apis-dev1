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

namespace Admin.App.Application.Features.Mtts
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
    StatusValues status): IRequest<ErrorOr<Mtt>>;


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

    public class CreateMttCommandHandler(ILogger<CreateMttCommandHandler> logger, ApplicationDbContext dbContext, ITransactionHandler transactionHandler, IMTTRepository repository, ICurrentUser user)
: MttBase, IRequestHandler<CreateMttCommand, ErrorOr<Mtt>>
    {
        private readonly ICurrentUser _user = user;
        private readonly IMTTRepository _repository = repository;
        public async Task<ErrorOr<Mtt?>> Handle(CreateMttCommand request, CancellationToken cancellationToken)
        {
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

            var result = await transactionHandler.ExecuteWithTransactionAsync<Mtt>(
               async (ct) =>
               {
                   var obj = await repository.AddAsync(entity, cancellationToken);
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