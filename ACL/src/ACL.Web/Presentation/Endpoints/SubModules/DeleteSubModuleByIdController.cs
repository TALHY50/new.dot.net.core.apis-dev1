
using ACL.Business.Application.Features.SubModules;
using ACL.Web.Presentation.Endpoints.Modules;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;

namespace ACL.Web.Presentation.Endpoints.SubModules
{
    public class DeleteSubModuleByIdController(ILogger<DeleteSubModuleByIdController> logger, ICurrentUser currentUser): SubModuleBaseController(logger, currentUser)
    {
        [Tags("SubModule")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(SubModuleRoutes.DeleteSubModuleTemplate, Name = SubModuleRoutes.DeleteSubModuleName)]

        public async Task<IActionResult> Delete(uint id, CancellationToken cancellationToken)
        {
            var command = new DeleteSubModuleCommand(id)
;
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-submodule-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(DeleteSubModuleCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                isSuccess => Ok(ToSuccess(result.Value)),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-submodule-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}