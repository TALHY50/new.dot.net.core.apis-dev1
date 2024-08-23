using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;

namespace Admin.App.Application.Features.Corridors
{
    public class CreateCorridorController : ApiControllerBase
    {
        //[Authorize]
        [HttpPost(Routes.CreateCorridorUrl, Name = Routes.CreateCorridorName)]
        public async Task<ActionResult<ErrorOr<Corridor>>> Create(CreateCorridorCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }
    }

    public record CreateCorridorCommand(
        uint? SourceCountryId,
        uint? DestinationCountryId,
        uint? SourceCurrencyId,
        uint? DestinationCurrencyId,
        uint? CompanyId) : IRequest<ErrorOr<Corridor>>;

    internal sealed class CreateCorridorCommandHandler(ImtApplicationDbContext context) : IRequestHandler<CreateCorridorCommand, ErrorOr<Corridor>>
    {
        private readonly ImtApplicationDbContext _context = context;
        public async Task<ErrorOr<Corridor>> Handle(CreateCorridorCommand request, CancellationToken cancellationToken)
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
