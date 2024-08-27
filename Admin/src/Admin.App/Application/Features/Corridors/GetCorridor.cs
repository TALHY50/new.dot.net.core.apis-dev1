using Ardalis.SharedKernel;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.IMT.Domain.Entities;

namespace Admin.App.Application.Features.Corridors
{
    public class GetCorridorController : ApiControllerBase
    {
        [Tags("Corridor")]
        //[Authorize]
        [HttpGet(Routes.GetCorridorUrl, Name = Routes.GetCorridorName)]
        public async Task<ActionResult<ErrorOr<List<Corridor>>>> Get()
        {
            return await Mediator.Send(new GetCorridorQuery()).ConfigureAwait(false);
        }
    }
    public record GetCorridorQuery() : IQuery<ErrorOr<List<Corridor>>>;

    internal sealed class GetCorridorHandler
        : IQueryHandler<GetCorridorQuery, ErrorOr<List<Corridor>>>
    {
        private readonly IImtCorridorRepository _repository;
        public GetCorridorHandler(IImtCorridorRepository repository)
        {
            _repository = repository;
        }
        public Task<ErrorOr<List<Corridor>>> Handle(GetCorridorQuery request, CancellationToken cancellationToken)
        {
            var corridors = _repository.All().ToList();
            return Task.FromResult<ErrorOr<List<Corridor>>>(corridors);

        }
    }
}
