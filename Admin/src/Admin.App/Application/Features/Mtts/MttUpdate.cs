using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.IMT.Domain.Entities;
using static Admin.App.Application.Features.Mtts.MttsCreate;

namespace Admin.App.Application.Features.Mtts
{
    public class MttUpdate : ApiControllerBase
    {
        [Tags("Mtt")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(AdminRoute.EditMttsRouteUrl, Name = AdminRoute.EditMttsRouteName)]
        public async Task<ActionResult<ErrorOr<Mtt>>> Update(uint id,UpdateMttCommand command)
        {
            var commandWithId = command with { id = id };
            return await Mediator.Send(commandWithId).ConfigureAwait(false);
        }

        public record UpdateMttCommand(uint id, uint? CorridorId, uint PayerId, uint? ServiceMethodId, string TransactionTypeId, uint? CotCurrencyId, decimal CotPercentage, decimal CotFixed, decimal FxSpread, uint? MarkUpCurrencyId, decimal MarkUpPercentage, decimal MarkUpFixed, decimal Increment, byte MoneyPrecision, uint? CompanyId, byte Status)
          : IRequest<ErrorOr<Mtt>>;


        internal sealed class UpdateMttCommandValidator : AbstractValidator<UpdateMttCommand>
        {
            public UpdateMttCommandValidator()
            {
                RuleFor(r => r.PayerId).NotEmpty();
                RuleFor(r => r.id).NotEmpty();
                RuleFor(r => r.TransactionTypeId).NotEmpty();
                RuleFor(r => r.CotPercentage).NotEmpty();
                RuleFor(r => r.CotFixed).NotEmpty();
                RuleFor(r => r.FxSpread).NotEmpty();
                RuleFor(r => r.MarkUpPercentage).NotEmpty();
                RuleFor(r => r.MarkUpFixed).NotEmpty();
                RuleFor(r => r.Increment).NotEmpty();
                RuleFor(r => r.MoneyPrecision).NotEmpty();
                RuleFor(r => r.Status).NotEmpty();
            }
        }

        internal sealed class UpdateMttCommandHandler : IRequestHandler<UpdateMttCommand, ErrorOr<Mtt>>
        {
            private readonly ICurrentUserService _user;
            private readonly IImtMttsRepository _repository;

            public UpdateMttCommandHandler(ICurrentUserService user, IImtMttsRepository repository)
            {
                _user = user;
                _repository = repository;
            }

            public async Task<ErrorOr<Mtt>> Handle(UpdateMttCommand request, CancellationToken cancellationToken)
            {
                Mtt? entity = _repository.GetByUintId(request.id);
                if (entity != null)
                {
                    entity.CompanyId = request.CompanyId;
                    entity.CorridorId = request.CorridorId;
                    entity.CotCurrencyId = request.CotCurrencyId;
                    entity.CotFixed = request.CotFixed;
                    entity.CotPercentage = request.CotPercentage;
                    entity.FxSpread = request.FxSpread;
                    entity.Increment = request.Increment;
                    entity.MarkUpCurrencyId = request.MarkUpCurrencyId;
                    entity.MarkUpFixed = request.MarkUpFixed;
                    entity.MarkUpPercentage = request.MarkUpPercentage;
                    entity.MoneyPrecision = request.MoneyPrecision;
                    entity.PayerId = request.PayerId;
                    entity.ServiceMethodId = request.ServiceMethodId;
                    entity.Status = request.Status;
                    entity.UpdatedAt = DateTime.Now;
                    entity.TransactionTypeId = request.TransactionTypeId;
                    if (_user?.UserId != null)
                    {
                        entity.UpdatedById = uint.Parse(_user?.UserId ?? "1");
                    }
                    else
                    {
                        entity.UpdatedById = 1;
                    }
                }

                return await _repository.UpdateAsync(entity);
            }
        }
    }
}
