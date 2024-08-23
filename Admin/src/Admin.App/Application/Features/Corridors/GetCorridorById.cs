using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.IMT.Entities;

namespace ADMIN.App.Application.Features.Corridors
{
    public class GetCorridorById : ApiControllerBase
    {
        //[Authorize]
        [HttpGet(Routes.GetCorridorByIdUrl, Name = Routes.GetCorridorByIdName)]
        public async Task<ActionResult<ErrorOr<Corridor>>> GetById(int id)
        {
            return await Mediator.Send(new GetCorridorByIdQuery(id)).ConfigureAwait(false);
        }
    }
    public record GetCorridorByIdQuery(int id) : IRequest<ErrorOr<Corridor>>;

    internal sealed class GetCorridorByIdQueryHandler() :
        IRequestHandler<GetCorridorByIdQuery, ErrorOr<Corridor>>
    {
        public Task<ErrorOr<Corridor>> Handle(GetCorridorByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
