using ACL.Business.Application.Features.UserGroups;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Entities;
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

        public async Task<IActionResult> Create(CreateUserGroupCommand command, CancellationToken cancellationToken)
        {
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-user-group-request: {Name} {@UserId} {@Request}",
                    nameof(CreateUserGroupCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                token => Ok(ToSuccess(ToDto(token))),
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


        private UserGroupDto ToDto(Usergroup token)
        {
            return new UserGroupDto(
                token.Id,
                token.GroupName,
                token.Category,
                token.Status,
                token.CompanyId);

        }
    }
}
