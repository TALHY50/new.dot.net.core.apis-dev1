using ACL.Business.Application.Features.Users;
using ACL.Business.Application.Interfaces;
using ACL.Business.Contracts.Requests;
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

public class UpdateUserByIdController : UserBaseController
{
    public UpdateUserByIdController(ILogger<UserBaseController> logger, ICurrentUser currentUser) : base(logger, currentUser)
    {
    }
    [Tags("Users")]
    //[Authorize(Policy = "HasPermission")]
    [HttpPut(AcluserRoutes.UpdateUserTemplate, Name = AcluserRoutes.UpdateUserName)]
    [HttpPatch(AcluserRoutes.UpdateUserTemplate, Name = AcluserRoutes.UpdateUserName)]
    public async Task<ActionResult> Update(uint id, UpdateUserByIdCommand command,CancellationToken cancellationToken)
    {
        var commandWithId = command with { id = id };
        //return await Mediator.Send(commandWithId).ConfigureAwait(false);
        _ = Task.Run(
      () => _logger.LogInformation(
          "update-user-request: {Name} {@UserId} {@Request}",
          nameof(command),
          CurrentUser.UserId,
      command),
      cancellationToken);
        var result = await Mediator.Send(commandWithId).ConfigureAwait(false);

        var response = result.Match(
        user => Ok(ToSuccess(user.Adapt<UserDto>())),
        Problem);

        _ = Task.Run(
            () => _logger.LogInformation(
                "update-user-response: {Name} {@UserId} {@Response}",
                nameof(response),
                CurrentUser.UserId,
            response),
            cancellationToken);
        return response;
    }

}