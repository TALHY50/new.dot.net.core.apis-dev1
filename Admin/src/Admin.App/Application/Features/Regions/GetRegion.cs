using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Domain.IMT.Entities;

namespace Admin.App.Application.Features.Regions
{
    public class GetRegionController : ApiControllerBase
    {
        [Tags("Regions")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetRegionUrl, Name = Routes.GetRegionName)]
        public async Task<ActionResult<ErrorOr<List<Region>>>> Get()
        {
            return await Mediator.Send(new GetRegionQuery()).ConfigureAwait(false);
        }

        public record GetRegionQuery() : IRequest<ErrorOr<List<Region>>>;

        internal sealed class GetRegionHandler
            : IRequestHandler<GetRegionQuery, ErrorOr<List<Region>>>
        {
            private readonly IImtRegionRepository _regionRepository;
            
            public GetRegionHandler(IImtRegionRepository regionRepository)
            {
                _regionRepository = regionRepository;
            }

            public async Task<ErrorOr<List<Region>>> Handle(GetRegionQuery request, CancellationToken cancellationToken)
            {
                return _regionRepository.All().ToList();
            }
        }
    }
}
