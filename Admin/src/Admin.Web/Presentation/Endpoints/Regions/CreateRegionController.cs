using Admin.App.Presentation.Routes;
using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Regions;
using SharedBusiness.Main.IMT.Contracts.Contracts.Responses;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.Regions
{
    public class CreateRegionController(ILogger<CreateRegionController> logger, ICurrentUser currentUser)
        : RegionBaseController(logger, currentUser)
    {
        [Tags("Regions")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(RegionRoutes.CreateRegionTemplate, Name = RegionRoutes.CreateRegionName)]


        public async Task<IActionResult> Create(CreateRegionCommand command, CancellationToken cancellationToken)
        {
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-region-request: {Name} {@UserId} {@Request}",
                    nameof(CreateRegionCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                region => Ok(ToSuccess(Mapper.Map<RegionDto>(region))),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-region-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
