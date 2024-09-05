using System.Net.Mime;
using System.Runtime.InteropServices.JavaScript;
using ACL.Business.Application.Features.Auth;
using ACL.Business.Contracts.Responses;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Extensions;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace ACL.Web.Presentation.Endpoints.Auth;
[ApiExplorerSettings(IgnoreApi = true)]
public class CreateJwtTokenController(ILogger<CreateJwtTokenController> logger, ICurrentUser currentUser)
    : AuthBaseController(logger, currentUser)
{
    [Tags("Auth")]
    //[Authorize(Policy = "HasPermission")]
    [HttpPost(AuthRoutes.CreateJwtTokenTemplateTemplate, Name = AuthRoutes.CreateJwtTokenName)]
  
    public async Task<IActionResult> Create([FromHeader]uint user_id, [FromBody] object payload, CancellationToken cancellationToken)
    {
        var command = new CreateJwtTokenCommand(user_id, payload.Minify());
        _ = Task.Run(
            () => _logger.LogInformation(
                "create-jwt-token-request: {Name} {@UserId} {@Request}",
                nameof(CreateJwtTokenCommand),
                CurrentUser.UserId,
                command),
            cancellationToken);
        var result = await Mediator.Send(command).ConfigureAwait(false);
        var response = result.Match(
            token => Ok(ToSuccess(ToDto(token))),
            Problem);
        _ = Task.Run(
            () => _logger.LogInformation(
                "create-jwt-token-response: {Name} {@UserId} {@Response}",
                nameof(response),
                CurrentUser.UserId,
                response),
            cancellationToken);
        return response;
    }

    private AuthResult ToDto(string token)
    {
        return new() { Token = token };
    }
}