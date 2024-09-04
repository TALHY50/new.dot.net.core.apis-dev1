using ACL.Business.Application.Features.Roles;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Entities;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace ACL.Web.Presentation.Endpoints.Roles
{
    public class GetRolesController(ILogger<GetRolesController> logger, ICurrentUser currentUser)
    : RoleBaseController(logger, currentUser)
    {
        [Tags("Role")]
        // [Authorize(Policy = "HasPermission")]
        [HttpGet(RoleRoutes.GetRoleTemplate, Name = RoleRoutes.GetRoleName)]
        public async Task<IActionResult> Get([FromQuery] PaginatorRequest pageRequest, CancellationToken cancellationToken)
        {
            var query = new GetRolesQuery(PageNumber: pageRequest.page_number, PageSize: pageRequest.page_size);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-roles: {Name} {@UserId} {@Request}",
                    nameof(GetRolesQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
            token => Ok(ToSuccess(ToDto(token))),
            Problem);

            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-roles-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }

        private List<RoleDto> ToDto(List<Role> tokens)
        {
            return tokens.Select(token => new RoleDto(
                token.Id,
                token.Name,
                token.Title
            )).ToList();
        }
    }
}
