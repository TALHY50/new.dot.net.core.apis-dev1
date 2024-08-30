using Ardalis.Specification;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using System.ComponentModel.Design;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common.Constants.Routes;

namespace Admin.App.Application.Features.Mtts
{
    public class MttsCreate : ApiControllerBase
    {
        [Tags("Mtt")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(AdminRoute.CreateMttsRouteUrl, Name = AdminRoute.CreateMttsRouteName)]
        public async Task<ActionResult<ErrorOr<Mtt>>> Create(CreateMttCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }

        public record CreateMttCommand(uint Id, uint? CorridorId, uint PayerId, uint? ServiceMethodId, uint TransactionTypeId, uint? CotCurrencyId, decimal CotPercentage, decimal CotFixed, decimal FxSpread, uint? MarkUpCurrencyId, decimal MarkUpPercentage, decimal MarkUpFixed, decimal Increment, byte MoneyPrecision, uint? CompanyId, byte Status)
            : IRequest<ErrorOr<Mtt>>;


        internal sealed class CreateMttCommandValidator : AbstractValidator<CreateMttCommand>
        {
            public CreateMttCommandValidator()
            {
                RuleFor(r => r.PayerId).NotEmpty();
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

        internal sealed class CreateMttCommandHandler : IRequestHandler<CreateMttCommand, ErrorOr<Mtt>>
        {
            private readonly ICurrentUserService _user;
            private readonly IImtMttsRepository _repository;

            public CreateMttCommandHandler(ICurrentUserService user, IImtMttsRepository repository)
            {
                _user = user;
                _repository = repository;
            }

            public async Task<ErrorOr<Mtt>> Handle(CreateMttCommand request, CancellationToken cancellationToken)
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
                    Status = request.Status,
                    TransactionTypeId = request.TransactionTypeId,
                    Id = request.Id,
                };

                    if (_user?.UserId != null)
                    {
                        entity.CreatedById = uint.Parse(_user?.UserId ?? "1");
                        entity.UpdatedById = uint.Parse(_user?.UserId ?? "1");
                    }
                    else
                    {
                        entity.UpdatedById = 1;
                        entity.CreatedById = 1;
                    }

                    entity.CreatedAt = DateTime.Now;
                    entity.UpdatedAt = DateTime.Now;
                    return _repository.Add(entity);
            }
        }
    }
}