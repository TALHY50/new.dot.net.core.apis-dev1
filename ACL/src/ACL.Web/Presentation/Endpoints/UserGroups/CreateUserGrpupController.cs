using ACL.Business.Contracts.Responses;
using ACL.Web.Presentation.Routes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Extensions;
using SharedKernel.Main.Application.Interfaces.Services;

namespace ACL.Web.Presentation.Endpoints.UserGroups
{
    public class CreateUserGrpupController(ILogger<CreateUserGrpupController> logger, ICurrentUser currentUser)
    : UserGroupBaseController(logger, currentUser)
    {
        [Tags("UserGroups")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(ACLUserGroupRoutes.CreateACLUserGroupTemplate, Name = ACLUserGroupRoutes.CreateACLUserGroupName)]

        public async Task<IActionResult> Create([FromHeader] uint user_id, [FromBody] object payload, CancellationToken cancellationToken)
        {
            var command = new CreateUserGroupCommand(user_id, payload.Minify());
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-user-group-request: {Name} {@UserId} {@Request}",
                    nameof(CreateUserGroupCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                token => Ok(ToSuccess(UserGroupDto(token))),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-user-group-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
