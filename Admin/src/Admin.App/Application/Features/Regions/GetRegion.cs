using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;
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
            private readonly IRegionRepository _regionRepository;
            
            public GetRegionHandler(IRegionRepository regionRepository)
            {
                _regionRepository = regionRepository;
            }

            public async Task<ErrorOr<List<Region>>> Handle(GetRegionQuery request, CancellationToken cancellationToken)
            {
                return _regionRepository.GetAll().ToList();
            }
        }
    }
}
