using ACL.Business.Application.Features.UserGroups;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Entities;
using ACL.Web.Presentation.Routes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;

namespace ACL.Web.Presentation.Endpoints.UserGroups
{
    public class GetUserGroupByIdController(ILogger<GetUserGroupByIdController> logger, ICurrentUser currentUser) 
        : UserGroupBaseController(logger, currentUser)
    {
        [Tags("UserGroups")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(ACLUserGroupRoutes.GetACLUserGroupByIdTemplate, Name = ACLUserGroupRoutes.GetACLUserGroupByIdName)]
        public async Task<IActionResult> GetById(uint id, CancellationToken cancellationToken)
        {
            var query = new GetUserGroupByIdQuery(id)
    ;
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-user-group-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(GetUserGroupByIdQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
            token => Ok(ToSuccess(ToDto(token))),
            Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-user-group-by-id-response: {Name} {@UserId} {@Response}",
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
