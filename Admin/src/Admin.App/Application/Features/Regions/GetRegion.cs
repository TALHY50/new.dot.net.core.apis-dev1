using Ardalis.SharedKernel;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.IMT.Entities;

namespace ADMIN.App.Application.Features.Regions
{
    public class GetRegionController : ApiControllerBase
    {
        [Authorize]//(Policy = "HasPermission")]
        [HttpGet(Routes.GetRegionUrl, Name = Routes.GetRegionName)]
        public async Task<ActionResult<ErrorOr<Region>>> Get()
        {
            return await Mediator.Send(new GetRegionQuery()).ConfigureAwait(false);
        }

        public record GetRegionQuery() : IQuery<ErrorOr<Region>>;

        internal sealed class GetRegionHandler() 
            : IQueryHandler<GetRegionQuery, ErrorOr<Region>>
        {
            // get all data 
            public Task<ErrorOr<Region>> Handle(GetRegionQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
