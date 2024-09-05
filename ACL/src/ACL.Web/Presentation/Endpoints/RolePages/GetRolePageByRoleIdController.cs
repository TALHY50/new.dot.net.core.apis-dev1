using ACL.Business.Application.Features.RolePages;
using ACL.Business.Contracts.Responses;
using ACL.Web.Presentation.Routes;
using ErrorOr;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;

namespace ACL.Web.Presentation.Endpoints.RolePages;

public class GetRolePageByRoleIdController(ILogger<GetRolePageByRoleIdController> logger, ICurrentUser currentUser)
    : RolePageBaseController(logger, currentUser)
{
    [Tags("Role Page Association")]
    //[Authorize(Policy = "HasPermission")]
    [HttpGet(RolePageRoutes.GetRolePageByRoleIdTemplate, Name = RolePageRoutes.GetRolePageByRoleIdName)]
    public async Task<IActionResult> GetById(uint role_id, CancellationToken cancellationToken)
    {
        var query = new GetRolePageByRoleIdQuery(role_id);
        _ = Task.Run(
            () => _logger.LogInformation(
                "get-role-pages-by-role-id-request: {Name} {@UserId} {@Request}",
                nameof(GetRolePageByRoleIdQuery),
                CurrentUser.UserId,
                query),
            cancellationToken);
        var result = await Mediator.Send(query).ConfigureAwait(false);

        var response = result.Match(
                rolePages => Ok(ToSuccess(rolePages.Select(rolePage => rolePage.Adapt<RolePageDto>()).ToList())),
                Problem
            );

        _ = Task.Run(
            () => _logger.LogInformation(
                "get-role-pages-by-role-id-response: {Name} {@UserId} {@Response}",
                nameof(response),
                CurrentUser.UserId,
                response),
            cancellationToken);

        return response;
    }
}