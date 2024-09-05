using ACL.Business.Application.Features.UserGroups;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Entities;
using ACL.Web.Presentation.Routes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace ACL.Web.Presentation.Endpoints.UserGroups
{
    public class GetUserGroupsController(ILogger<GetUserGroupsController> logger, ICurrentUser currentUser) 
        : UserGroupBaseController(logger, currentUser)
    {
        [Tags("Usergroups")]
        // [Authorize(Policy = "HasPermission")]
        [HttpGet(ACLUserGroupRoutes.GetACLUserGroupTemplate, Name = ACLUserGroupRoutes.GetACLUserGroupName)]
        public async Task<IActionResult> Get([FromQuery] PaginatorRequest pageRequest, CancellationToken cancellationToken)
        {
            var query = new GetUserGroupsQuery();
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-user-groups: {Name} {@UserId} {@Request}",
                    nameof(GetUserGroupsQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
            token => Ok(ToSuccess(ToDto(token))),
            Problem);

            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-user-groups-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }

        private List<UserGroupDto> ToDto(List<Usergroup> tokens)
        {
            return tokens.Select(token => new UserGroupDto(
                token.Id,
                token.GroupName,
                token.Category,
                token.Status,
                token.CompanyId)).ToList();
        }
    }
}
