using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;

namespace ADMIN.App.Application.Features.Corridors
{
    public class UpdateCorridorController : ApiControllerBase
    {
        //[Authorize]//(Policy = "HasPermission")]
        [HttpPost(Routes.UpdateCorridorUrl, Name = Routes.UpdateCorridorName)]

        public async Task<ActionResult<ErrorOr<Corridor>>> Update(UpdateCorridorCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }
    }
    public record UpdateCorridorCommand(
        uint? SourceCountryId,
        uint? DestinationCountryId,
        uint? SourceCurrencyId,
        uint? DestinationCurrencyId,
        uint? CompanyId) : IRequest<ErrorOr<Corridor>>;
    internal sealed class UpdateCorridorCommandHandler(ImtApplicationDbContext context)
        : IRequestHandler<UpdateCorridorCommand, ErrorOr<Corridor>>
    {
        private readonly ImtApplicationDbContext _context = context;
        public async Task<ErrorOr<Corridor>> Handle(UpdateCorridorCommand request, CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;
            var @corridor = new Corridor
            {
                SourceCountryId = request.SourceCountryId,
                DestinationCountryId = request.DestinationCountryId,
                SourceCurrencyId = request.SourceCurrencyId,
                DestinationCurrencyId = request.DestinationCurrencyId,
                CompanyId = request.CompanyId,
                CreatedById = 1,
                UpdatedById = 2,
                Status = 1,
                CreatedAt = now,
                UpdatedAt = now,
            };
            return @corridor;
        }
    }
}
