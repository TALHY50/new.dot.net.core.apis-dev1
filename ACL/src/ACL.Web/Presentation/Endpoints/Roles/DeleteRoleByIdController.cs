using ACL.Business.Application.Features.Roles;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;

namespace ACL.Web.Presentation.Endpoints.Roles
{
    public class DeleteRoleById(ILogger<DeleteRoleById> logger, ICurrentUser currentUser)
    : RoleBaseController(logger, currentUser)
    {
        [Tags("Roles")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(RoleRoutes.DeleteRoleTemplate, Name = RoleRoutes.DeleteRoleName)]

        public async Task<IActionResult> Delete(uint id, CancellationToken cancellationToken)
        {
            var command = new DeleteRoleByIdCommand(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-role-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(DeleteRoleByIdCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                isSuccess => Ok(ToSuccess(result.Value)),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-role-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
