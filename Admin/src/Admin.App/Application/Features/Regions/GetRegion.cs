using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Admin.App.Application.Features.Regions
{
    public class GetRegionController : ApiControllerBase
    {
        [Tags("Regions")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetRegionUrl, Name = Routes.GetRegionName)]
        public async Task<ActionResult<ErrorOr<List<Region>>>> Get()
        {
            var result = await Mediator.Send(new GetRegionQuery()).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }

        public record GetRegionQuery() : IRequest<ErrorOr<List<Region>>>;

        public class GetRegionHandler
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
