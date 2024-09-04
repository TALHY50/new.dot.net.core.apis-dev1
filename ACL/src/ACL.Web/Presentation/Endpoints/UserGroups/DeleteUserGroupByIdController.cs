using ACL.Business.Application.Features.UserGroups;
using ACL.Web.Presentation.Routes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;

namespace ACL.Web.Presentation.Endpoints.UserGroups
{
    public class DeleteUserGroupByIdController(ILogger<DeleteUserGroupByIdController> logger, ICurrentUser currentUser)
        : UserGroupBaseController(logger, currentUser)
    {
        [Tags("UserGroups")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(ACLUserGroupRoutes.DeleteACLUserGroupTemplate, Name = ACLUserGroupRoutes.DeleteACLUserGroupName)]

        public async Task<IActionResult> Delete(uint id, CancellationToken cancellationToken)
        {
            var command = new DeleteUserGroupByIdCommand(id)
;
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-user-group-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(DeleteUserGroupByIdCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                isSuccess => Ok(ToSuccess(result.Value)),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-user-group-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}