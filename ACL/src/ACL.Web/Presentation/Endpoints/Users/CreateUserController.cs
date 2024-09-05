using ACL.Business.Application.Features.Users;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Entities;
using ACL.Business.Domain.Services;
using ACL.Web.Presentation.Routes;
using ErrorOr;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;
using System.Threading;

namespace ACL.Web.Presentation.Endpoints.Users;


public class CreateUserController : UserBaseController
{
    public CreateUserController(ILogger<UserBaseController> logger, ICurrentUser currentUser) : base(logger, currentUser)
    {
    }
    [Tags("Users")]
    /// <inheritdoc/>
    // [Authorize(Policy = "HasPermission")]
    [HttpPost(AcluserRoutes.CreateUserTemplate, Name = AcluserRoutes.CreateUserName)]
    public async Task<IActionResult> Create(CreateUserCommand command,CancellationToken cancellationToken)
    {
      _ = Task.Run(
         () => _logger.LogInformation(
             "create-user-request: {Name} {@UserId} {@Response}",
             nameof(CreateUserCommand),
             CurrentUser.UserId,
         command),
         cancellationToken);
     var result = await Mediator.Send(command).ConfigureAwait(false);
     var response = result.Match(
         user => Ok(ToSuccess(user.Adapt<UserDto>())),
         Problem);
     _ = Task.Run(
         () => _logger.LogInformation(
             "create-user-response: {Name} {@UserId} {@Response}",
             nameof(response),
             CurrentUser.UserId,
             response), cancellationToken);
     return response;
        //var result = await Mediator.Send(command).ConfigureAwait(false);

        //if (result.IsError)
        //{
        //    return Problem(result.Errors); // Return errors as a problem
        //}

        //return Ok(result.Value); // Return the successful result
    }
}