using ACL.Business.Application.Features.UserGroupRoles;
using ACL.Business.Contracts.Responses;
using ACL.Web.Presentation.Routes;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;

namespace ACL.Web.Presentation.Endpoints.UserGroupRoles
{
    public class GetUserGroupRoleByIdController(ILogger<GetUserGroupRoleByIdController> logger, ICurrentUser currentUser)
        : UserGroupRoleBaseController(logger, currentUser)
    {
        [Tags("User Group Roles")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(UserGroupRoleRoutes.GetUserGroupRoleByUserGroupIdTemplate, Name = UserGroupRoleRoutes.GetUserGroupRoleByUserGroupIdName)]
        public async Task<IActionResult> GetById(uint user_group_id, CancellationToken cancellationToken)
        {
            var query = new GetUserGroupRoleByUserGroupIdQuery(user_group_id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-user-group-roles-by-user-group-id-request: {Name} {@UserId} {@Request}",
                    nameof(GetUserGroupRoleByUserGroupIdQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);

            var response = result.Match(
                    userGroupRoles => Ok(ToSuccess(userGroupRoles.Select(userGroupRole => userGroupRole.Adapt<UserGroupRoleDto>()).ToList())),
                    Problem
                );

            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-user-group-roles-by-user-group-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);

            return response;
        }
    }
}
