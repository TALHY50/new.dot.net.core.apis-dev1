using ACL.Business.Application.Features.UserGroups;
using ACL.Business.Application.Features.Users;
using ACL.Business.Application.Interfaces;
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
using System.Threading;

namespace ACL.Web.Presentation.Endpoints.Users;

public class GetByUserIdController : UserBaseController
{
    public GetByUserIdController(ILogger<UserBaseController> logger, ICurrentUser currentUser) : base(logger, currentUser)
    {
    }
    [Tags("Users")]
    /// <inheritdoc/>
    //[Authorize(Policy = "HasPermission")]
    [HttpGet(AcluserRoutes.GetUserByIdTemplate, Name = AcluserRoutes.GetUserByIdName)]
    public async Task<ActionResult> GetById(uint id,CancellationToken cancellationToken)
    {
        // return await Mediator.Send(new GetUserByIdQuery(id)).ConfigureAwait(false);
        var query = new GetUserGroupByIdQuery(id);
        _ = Task.Run(
            () => _logger.LogInformation(
                "get-user-by-id-request: {Name} {@UserId} {@Request}",
                nameof(GetUserGroupByIdQuery),
                CurrentUser.UserId,
                query),
            cancellationToken);
        var result = await Mediator.Send(query).ConfigureAwait(false);
        var response = result.Match(
        user => Ok(ToSuccess(user.Adapt<UserDto>())),
        Problem);
        _ = Task.Run(
            () => _logger.LogInformation(
                "get-user-by-id-response: {Name} {@UserId} {@Response}",
                nameof(response),
                CurrentUser.UserId,
                response),
            cancellationToken);

        return response;
    }
}