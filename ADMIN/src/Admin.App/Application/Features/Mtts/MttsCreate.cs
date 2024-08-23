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

namespace ADMIN.App.Application.Features.Mtts
{
    public class MttsCreate : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public MttsCreate(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
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

        internal sealed class CreateMttCommandHandler(ImtApplicationDbContext dbContext, IImtMttsRepository repository) : IRequestHandler<CreateMttCommand, ErrorOr<Mtt>>
        {
            private readonly ImtApplicationDbContext _context = dbContext;
            public async Task<ErrorOr<Mtt>> Handle(CreateMttCommand request, CancellationToken cancellationToken)
            {
                var entity = new Mtt
                {
                };
                if (request.Id > 0)
                {
                    entity = repository.GetById(request.Id);
                    if (entity != null)
                    {
                        entity.PayerId = request.PayerId;
                        return await repository.UpdateAsync(entity);
                    }
                }
                else
                {
                    return await repository.AddAsync(entity);
                }
                return await repository.AddAsync(entity);
            }
        }
    }
}
