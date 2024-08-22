using Ardalis.Specification;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Application.Interfaces.Repositories.IMT.Services;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Domain.Notification.Notifications.Events;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;

namespace ADMIN.App.Features
{
    public class MttsCreateController : ApiControllerBase
    {

        //[Authorize(Policy = "HasPermission")]
        //[HttpPost(Routes.CreateBusinessHourAndWeekendUrl, Name = Routes.CreateBusinessHourAndWeekendName)]
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
                return await repository.AddAsync(entity);
            }
        }
    }
}
