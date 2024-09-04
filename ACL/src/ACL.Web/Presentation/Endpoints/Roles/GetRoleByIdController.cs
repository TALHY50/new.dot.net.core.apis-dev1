using ACL.Business.Application.Features.Roles;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Entities;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;

namespace ACL.Web.Presentation.Endpoints.Roles
{
    public class GetRoleByIdController(ILogger<GetRoleByIdController> logger, ICurrentUser currentUser)
    : RoleBaseController(logger, currentUser)
    {
        [Tags("Role")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(RoleRoutes.GetRoleByIdTemplate, Name = RoleRoutes.GetRoleByIdName)]
        public async Task<IActionResult> GetById(uint id, CancellationToken cancellationToken)
        {
            var query = new GetRoleByIdQuery(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-role-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(GetRoleByIdQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
            token => Ok(ToSuccess(ToDto(token))),
            Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-role-by-id-response: {Name} {@UserId} {@Response}",
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
