using ACL.Business.Application.Features.RolePages;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;


namespace ACL.Web.Presentation.Endpoints.RolePages;

public class UpdateRolePageController : RolePageBaseController
{
    public UpdateRolePageController(ILogger<UpdateRolePageController> logger, ICurrentUser currentUser) : base(logger, currentUser)
    {
    }

    [Tags("RolePageUpdate")]
    //[Authorize(Policy = "HasPermission")]
    [HttpPut(RolePageRoutes.UpdateRolePageTemplate, Name = RolePageRoutes.UpdateRolePageName)]
    [HttpPatch(RolePageRoutes.UpdateRolePageTemplate, Name = RolePageRoutes.UpdateRolePageName)]

    public async Task<IActionResult> Update(UpdateRolePageCommand command, CancellationToken cancellationToken)
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
                    isSuccess => Ok(ToSuccess(result.Value)),
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
}
