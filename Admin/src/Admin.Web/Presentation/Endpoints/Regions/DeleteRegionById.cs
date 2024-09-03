using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Weblication.Features.Countries;
using SharedBusiness.Main.Admin.Weblication.Features.Regions;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.Regions
{
    public class DeleteRegionById(ILogger<DeleteRegionById> logger, ICurrentUser currentUser) 
        : RegionBase(logger, currentUser)
    {
        [Tags("Regions")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(RegionRoutes.DeleteRegionTemplate, Name = RegionRoutes.DeleteRegionName)]

        public async Task<IActionResult> Delete(uint id, CancellationToken cancellationToken)
        {
            var command = new DeleteRegionByIdCommand(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-region-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(DeleteRegionByIdCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                isSuccess => Ok(ToSuccess(result.Value)),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-region-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
