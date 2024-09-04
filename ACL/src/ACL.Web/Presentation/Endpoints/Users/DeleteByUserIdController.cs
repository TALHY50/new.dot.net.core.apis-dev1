using ACL.Business.Application.Features.UserGroups;
using ACL.Business.Application.Features.Users;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Services;
using ACL.Web.Presentation.Endpoints.Users;
using ACL.Web.Presentation.Routes;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;
using System.Threading;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ACL.Web.Presentation.Endpoints.Users;

public class DeleteByUserIdController : UserBaseController
{
    public DeleteByUserIdController(ILogger<UserBaseController> logger, ICurrentUser currentUser) : base(logger, currentUser)
    {
    }
    [Tags("User")]
    // [Authorize(Policy = "HasPermission")]
    [HttpDelete(AcluserRoutes.DeleteUserTemplate, Name = AcluserRoutes.DeleteUserName)]
    public async Task<IActionResult> Destroy(uint id,CancellationToken cancellationToken)
    {
        //return this._userService.DeleteById(id);
        //return await Mediator.Send(command).ConfigureAwait(false);
        var command = new DeleteUserByIdCommand(id)
;
        _ = Task.Run(
            () => _logger.LogInformation(
                "delete-user-by-id-request: {Name} {@UserId} {@Request}",
                nameof(DeleteUserGroupByIdCommand),
                CurrentUser.UserId,
                command),
            cancellationToken);
        var result = await Mediator.Send(command).ConfigureAwait(false);
        var response = result.Match(
            isSuccess => Ok(ToSuccess(result.Value)),
            Problem);
        _ = Task.Run(
            () => _logger.LogInformation(
                "delete-user-by-id-response: {Name} {@UserId} {@Response}",
                nameof(response),
                CurrentUser.UserId,
                response),
            cancellationToken);
        return response;
    }
}