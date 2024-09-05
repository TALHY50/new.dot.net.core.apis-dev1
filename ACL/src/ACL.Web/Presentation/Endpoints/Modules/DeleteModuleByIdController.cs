using ACL.Business.Application.Features.Modules;
using ACL.Web.Presentation.Endpoints.Modules;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;

namespace ACL.Web.Presentation.Endpoints.UserGroups
{
    public class DeleteModuleByIdController(ILogger<DeleteModuleByIdController> logger, ICurrentUser currentUser): ModuleBaseController(logger, currentUser)
    {
        [Tags("Modules")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(ModuleRoutes.DeleteModuleTemplate, Name = ModuleRoutes.DeleteModuleName)]

        public async Task<IActionResult> Delete(uint id, CancellationToken cancellationToken)
        {
            var command = new DeleteModuleCommand(id)
;
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-module-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(DeleteModuleCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                isSuccess => Ok(ToSuccess(result.Value)),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-module-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}