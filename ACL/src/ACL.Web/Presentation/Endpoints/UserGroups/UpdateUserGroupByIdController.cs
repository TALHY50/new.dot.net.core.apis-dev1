﻿using ACL.Business.Application.Features.UserGroups;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Entities;
using ACL.Web.Presentation.Routes;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;

namespace ACL.Web.Presentation.Endpoints.UserGroups
{
    public class UpdateUserGroupByIdController : UserGroupBaseController
    {
        public UpdateUserGroupByIdController(ILogger<UpdateUserGroupByIdController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }

        [Tags("Usergroups")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(ACLUserGroupRoutes.UpdateACLUserGroupTemplate, Name = ACLUserGroupRoutes.UpdateACLUserGroupName)]
        [HttpPatch(ACLUserGroupRoutes.UpdateACLUserGroupTemplate, Name = ACLUserGroupRoutes.UpdateACLUserGroupName)]

        public async Task<IActionResult> Update(UpdateUserGroupByIdCommand command, CancellationToken cancellationToken)
        {
            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-user-group-page-request: {Name} {@UserId} {@Request}",
                    nameof(command),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);

            var response = result.Match(
            userGroup => Ok(ToSuccess(userGroup.Adapt<UserGroupDto>())),
            Problem);

            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-user-group-page-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
