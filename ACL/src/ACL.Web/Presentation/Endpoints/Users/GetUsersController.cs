using ACL.Business.Application.Features.UserGroups;
using ACL.Business.Application.Features.Users;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Entities;
using ACL.Business.Domain.Services;
using ACL.Web.Presentation.Endpoints.Users;
using ACL.Web.Presentation.Routes;
using ErrorOr;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;
using System.Threading;

namespace ACL.Web.Presentation.Endpoints.Users;

public class GetUsersController : UserBaseController
{
    public GetUsersController(ILogger<UserBaseController> logger, ICurrentUser currentUser) : base(logger, currentUser)
    {
    }
    [Tags("Users")]
    /// <inheritdoc/>
    //[Authorize(Policy = "HasPermission")]
    [HttpGet(AcluserRoutes.GetUserTemplate, Name = AcluserRoutes.GetUserName)]
    public async Task<ActionResult> GetAll([FromQuery] PaginatorRequest pageRequest,CancellationToken cancellationToken)
    {
        //return await Mediator.Send(new GetUsersQuery()).ConfigureAwait(false);
        var query = new GetUserGroupsQuery();
        _ = Task.Run(
            () => _logger.LogInformation(
                "get-users: {Name} {@UserId} {@Request}",
                nameof(GetUserGroupsQuery),
                CurrentUser.UserId,
                query),
            cancellationToken);
        var result = await Mediator.Send(query).ConfigureAwait(false);
        var response = result.Match(
        users => Ok(ToSuccess(users.Select(user => user.Adapt<UserDto>()).ToList())),
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
}