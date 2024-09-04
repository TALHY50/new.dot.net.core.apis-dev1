using Mapster;
using ACL.Business.Application.Features.Roles;
using ACL.Business.Contracts.Responses;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;
using ACL.Business.Domain.Entities;

namespace ACL.Web.Presentation.Endpoints.Roles
{
    public class CreateRoleController(ILogger<CreateRoleController> logger, ICurrentUser currentUser)
    : RoleBaseController(logger, currentUser)
    {
        [Tags("Role")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(RoleRoutes.CreateRoleTemplate, Name = RoleRoutes.CreateRoleName)]

        public async Task<IActionResult> Create(CreateRoleCommand command, CancellationToken cancellationToken)
        {
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-corridor-request: {Name} {@UserId} {@Response}",
                    nameof(CreateRoleCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
            token => Ok(ToSuccess(ToDto(token))),
            Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-corridor-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response), cancellationToken);
            return response;
        }

        private RoleDto ToDto(Role token)
        {
            return new RoleDto(
                token.Id,
                 token.Name,
                 token.Title);
        }
    }
}
