using Admin.App.Presentation.Endpoints.Providers;
using Admin.App.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Providers;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.Providers
{
    public class DeleteProviderByIdController(ILogger<DeleteProviderByIdController> logger, ICurrentUser currentUser)
        : ProviderBaseController(logger, currentUser)
    {
        [Tags("Providers")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(ProviderRoutes.DeleteProviderTemplate, Name = ProviderRoutes.DeleteProviderName)]

        public async Task<IActionResult> Delete(uint id, CancellationToken cancellationToken)
        {
            var command = new DeleteProviderByIdCommand(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-provider-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(DeleteProviderByIdCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                isSuccess => Ok(ToSuccess(result.Value)),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-provider-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
