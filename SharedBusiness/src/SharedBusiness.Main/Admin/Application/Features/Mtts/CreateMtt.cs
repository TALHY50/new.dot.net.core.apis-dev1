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
    uint? transaction_type_id,
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
            RuleFor(r => r.PayerId).NotEmpty().PayerIdRule();
            RuleFor(r => r.TransactionTypeId).NotEmpty().TransactionTypeIdRule();
            RuleFor(r => r.CotPercentage).NotEmpty().CotPercentageRule();
            RuleFor(r => r.CotFixed).NotEmpty().CotFixedRule();
            RuleFor(r => r.FxSpread).NotEmpty().FxSpreadRule();
            RuleFor(r => r.MarkUpPercentage).NotEmpty().MarkUpPercentageRule();
            RuleFor(r => r.MarkUpFixed).NotEmpty().MarkUpFixedRule();
            RuleFor(r => r.Increment).NotEmpty().IncrementRule();
            RuleFor(r => r.MoneyPrecision).NotEmpty().MoneyPrecisionRule();
            RuleFor(x => x.Status).NotEmpty().IsInEnum();
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
                CompanyId = request.CompanyId,
                CorridorId = request.CorridorId,
                //  CotCurrencyId = request.CotCurrencyId,
                CotFixed = request.CotFixed,
                CotPercentage = request.CotPercentage,
                FxSpread = request.FxSpread,
                Increment = request.Increment,
                //  MarkUpCurrencyId = request.MarkUpCurrencyId,
                MarkUpFixed = request.MarkUpFixed,
                MarkUpPercentage = request.MarkUpPercentage,
                MoneyPrecision = request.MoneyPrecision,
                PayerId = request.PayerId,
                ServiceMethodId = request.ServiceMethodId,
                Status = (byte)((int)request.Status),
                TransactionTypeId = request.TransactionTypeId
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