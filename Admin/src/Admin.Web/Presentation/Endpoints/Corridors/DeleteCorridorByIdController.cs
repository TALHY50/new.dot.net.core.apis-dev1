using Admin.Web.Presentation.Endpoints.Corridors;
using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Corridors;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.App.Presentation.Endpoints.Corridors
{
    public class DeleteCorridorById(ILogger<DeleteCorridorById> logger, ICurrentUser currentUser)
    : CorridorBaseController(logger, currentUser)
    {
        [Tags("Currencies")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(CorridorsRoutes.DeleteCorridorTemplate, Name = CorridorsRoutes.DeleteCorridorName)]

        public async Task<IActionResult> Delete(uint id, CancellationToken cancellationToken)
        {
            var command = new DeleteCorridorByIdCommand(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-corridor-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(DeleteCorridorByIdCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                isSuccess => Ok(ToSuccess(result.Value)),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-corridor-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
