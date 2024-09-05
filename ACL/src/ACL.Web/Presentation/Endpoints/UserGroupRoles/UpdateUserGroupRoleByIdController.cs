using ACL.Business.Application.Features.UserGroupRoles;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;

namespace ACL.Web.Presentation.Endpoints.UserGroupRoles
{
    public class UpdateUserGroupRoleByIdController : UserGroupRoleBaseController
    {
        public UpdateUserGroupRoleByIdController(ILogger<UserGroupRoleBaseController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }
        [Tags("UsergroupRoles")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(UserGroupRoleRoutes.UpdateUserGroupRoleTemplate, Name = UserGroupRoleRoutes.UpdateUserGroupRoleName)]
        //[HttpPatch(UserGroupRoleRoutes.UpdateUserGroupRoleTemplate, Name = UserGroupRoleRoutes.UpdateUserGroupRoleName)]

        public async Task<IActionResult> Update(UpdateUserGroupRoleCommand command, CancellationToken cancellationToken)
        {
            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-user-group-roles-request: {Name} {@UserId} {@Request}",
                    nameof(command),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);

            var response = result.Match(
                        isSuccess => Ok(ToSuccess(result.Value)),
                        Problem);

            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-user-group-roles-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
