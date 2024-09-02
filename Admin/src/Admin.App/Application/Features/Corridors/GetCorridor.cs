using Ardalis.SharedKernel;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

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
        private readonly ICorridorRepository _repository;
        public GetCorridorHandler(ICorridorRepository repository)
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
