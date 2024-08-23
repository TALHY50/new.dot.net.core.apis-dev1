using Ardalis.SharedKernel;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.IMT.Entities;

namespace ADMIN.App.Application.Features.Corridors
{
    public class GetCorridorController : ApiControllerBase
    {
        //[Authorize]
        [HttpGet(Routes.GetCorridorUrl, Name = Routes.GetCorridorName)]
        public async Task<ActionResult<ErrorOr<Corridor>>> Get()
        {
            return await Mediator.Send(new GetCorridorQuery()).ConfigureAwait(false);
        }
    }
    public record GetCorridorQuery() : IQuery<ErrorOr<Corridor>>;

    internal sealed class GetCorridorHandler()
        : IQueryHandler<GetCorridorQuery, ErrorOr<Corridor>>
    {
        public Task<ErrorOr<Corridor>> Handle(GetCorridorQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
