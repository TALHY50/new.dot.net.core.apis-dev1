using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.Admin.Application.Features.Regions;
using SharedBusiness.Main.IMT.Contracts.Contracts.Responses;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.Regions
{
    public class GetRegionById(ILogger<GetRegionById> logger, ICurrentUser currentUser)
        : RegionBase(logger, currentUser)
    {
        [Tags("Regions")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(RegionRoutes.GetRegionByIdTemplate, Name = RegionRoutes.GetRegionByIdName)]

        public async Task<IActionResult> GetById(uint id, CancellationToken cancellationToken)
        {
            var query = new GetRegionByIdQuery(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-region-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(GetRegionByIdQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                region => Ok(ToSuccess(Mapper.Map<RegionDto>(region))),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-region-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);

            return response;
        }
    }
}
