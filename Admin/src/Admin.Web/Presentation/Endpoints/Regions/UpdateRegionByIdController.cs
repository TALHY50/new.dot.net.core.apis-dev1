using Admin.Web.Presentation.Endpoints.Country;
using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Weblication.Features.Countries;
using SharedBusiness.Main.Admin.Weblication.Features.Regions;
using SharedBusiness.Main.IMT.Contracts.Contracts.Responses;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.Regions
{
    public class UpdateRegionByIdController : RegionBaseController
    {
        public UpdateRegionByIdController(ILogger<UpdateRegionByIdController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }

        [Tags("Regions")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(RegionRoutes.UpdateRegionTemplate, Name = RegionRoutes.UpdateRegionName)]
        [HttpPatch(RegionRoutes.UpdateRegionTemplate, Name = RegionRoutes.UpdateRegionName)]

        public async Task<IActionResult> Update(uint id, UpdateRegionByIdCommand command, CancellationToken cancellationToken)
        {
            var commandWithId = command with { id = id };
            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-region-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(commandWithId),
                    CurrentUser.UserId,
                    commandWithId),
                cancellationToken);
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
            var response = result.Match(
                region => Ok(ToSuccess(Mapper.Map<RegionDto>(region))),
                Problem);

            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-region-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
