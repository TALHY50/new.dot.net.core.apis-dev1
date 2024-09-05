﻿
using ACL.Business.Application.Features.Roles;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Entities;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;

namespace ACL.Web.Presentation.Endpoints.Roles
{
    public class UpdateRoleByIdController : RoleBaseController
    {
        public UpdateRoleByIdController(ILogger<UpdateRoleByIdController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }

        [Tags("Roles")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(RoleRoutes.UpdateRoleTemplate, Name = RoleRoutes.UpdateRoleName)]
        [HttpPatch(RoleRoutes.UpdateRoleTemplate, Name = RoleRoutes.UpdateRoleName)]

        public async Task<IActionResult> Update(UpdateRoleByIdCommand command, CancellationToken cancellationToken)
        {
            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-role-page-request: {Name} {@UserId} {@Request}",
                    nameof(command),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);

            var response = result.Match(
            token => Ok(ToSuccess(ToDto(token))),
            Problem);

            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-role-page-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
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
