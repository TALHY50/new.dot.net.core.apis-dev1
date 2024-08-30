using Ardalis.SharedKernel;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;

namespace Admin.App.Application.Features.Corridors
{
    public class GetCorridorController : ApiControllerBase
    {
        [Tags("Corridor")]
        //[Authorize]
        [HttpGet(Routes.GetCorridorUrl, Name = Routes.GetCorridorName)]
        public async Task<ActionResult<ErrorOr<List<Corridor>>>> Get()
        {
            var result = await Mediator.Send(new GetCorridorQuery()).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }
    public record GetCorridorQuery() : IQuery<ErrorOr<List<Corridor>>>;

    public class GetCorridorHandler
        : IQueryHandler<GetCorridorQuery, ErrorOr<List<Corridor>>>
    {
        private readonly IImtCorridorRepository _repository;
        public GetCorridorHandler(IImtCorridorRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<List<Corridor>>> Handle(GetCorridorQuery request, CancellationToken cancellationToken)
        {
            var corridors = _repository.GetAll();
            return corridors;

        }
    }
}
