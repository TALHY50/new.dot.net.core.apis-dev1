using Ardalis.Specification;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Application.Interfaces.Repositories.IMT.Services;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Domain.Notification.Notifications.Events;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;

namespace Admin.App.Application.Features.Mtts
{
    public class MttsCreate : ApiControllerBase
    {
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(AdminRoute.CreateMttsRouteUrl, Name = AdminRoute.CreateMttsRouteName)]
        public async Task<ActionResult<ErrorOr<Mtt>>> Create(CreateMttCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }

        public record CreateMttCommand(uint Id, uint? CorridorId, uint PayerId, uint? ServiceMethodId, string TransactionTypeId, uint? CotCurrencyId, decimal CotPercentage, decimal CotFixed, decimal FxSpread, uint? MarkUpCurrencyId, decimal MarkUpPercentage, decimal MarkUpFixed, decimal Increment, byte MoneyPrecision, uint? CompanyId, byte Status)
            : IRequest<ErrorOr<Mtt>>;


        internal sealed class CreateMttCommandValidator : AbstractValidator<CreateMttCommand>
        {
            public CreateMttCommandValidator()
            {
                //RuleFor(r => r.Day).NotEmpty();
                //RuleFor(r => r.Day).NotEmpty();
                //RuleFor(r => r.Day).NotEmpty();
                //RuleFor(r => r.Day).NotEmpty();
                //RuleFor(r => r.Day).NotEmpty();
                //RuleFor(r => r.Day).NotEmpty();
                //RuleFor(r => r.Day).NotEmpty();
                //RuleFor(r => r.Day).NotEmpty();
                //RuleFor(r => r.Day).NotEmpty();
                RuleFor(r => r.Status).NotEmpty();
            }
        }

        internal sealed class CreateMttCommandHandler : IRequestHandler<CreateMttCommand, ErrorOr<Mtt>>
        {
            private readonly ImtApplicationDbContext _context;
            private readonly IImtMttsRepository _repository;

            public CreateMttCommandHandler(ImtApplicationDbContext context, IImtMttsRepository repository)
            {
                _context = context;
                _repository = repository;
            }

            public async Task<ErrorOr<Mtt>> Handle(CreateMttCommand request, CancellationToken cancellationToken)
            {
                var entity = new Mtt
                {
                    CompanyId = request.CompanyId,
                    CorridorId = request.CorridorId,
                    CotCurrencyId = request.CotCurrencyId,
                    CotFixed = request.CotFixed,
                    CotPercentage = request.CotPercentage,
                    FxSpread = request.FxSpread,
                    Increment = request.Increment,
                    MarkUpCurrencyId = request.MarkUpCurrencyId,
                    MarkUpFixed = request.MarkUpFixed,
                    MarkUpPercentage = request.MarkUpPercentage,
                    MoneyPrecision = request.MoneyPrecision,
                    PayerId = request.PayerId,
                    ServiceMethodId = request.ServiceMethodId,
                    Status = request.Status,
                    TransactionTypeId = request.TransactionTypeId,
                    CreatedById= request.Id, //HardCoded value Will update later
                    CreatedAt= DateTime.Now,
                    UpdatedAt= DateTime.Now,
                    Id = request.Id,
                };

                if (request.Id > 0)
                {
                    entity = _repository.GetById(request.Id);
                    if (entity != null)
                    {
                        entity.PayerId = request.PayerId;
                        return await _repository.UpdateAsync(entity);
                    }
                }
                else
                {
                    return await _repository.AddAsync(entity);
                }

                return await _repository.AddAsync(entity);
            }
        }

    }
}
