using ACL.Business.Application.Features.Auth;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;

namespace ACL.Web.Presentation.Endpoints.Auth;

public class CreateCountry(ILogger<CreateCountry> logger, ICurrentUser currentUser)
    : AuthBase(logger, currentUser)
{
    [Tags("Countries")]
    //[Authorize(Policy = "HasPermission")]
    [HttpPost(AuthRoutes.CreateJwtTokenTemplateTemplate, Name = AuthRoutes.CreateJwtTokenName)]

    public async Task<IActionResult> Create(CreateJwtTokenCommand command, CancellationToken cancellationToken)
    {
        _ = Task.Run(
            () => _logger.LogInformation(
                "create-jwt-token-request: {Name} {@UserId} {@Request}",
                nameof(CreateJwtTokenCommand),
                CurrentUser.UserId,
                command),
            cancellationToken);
        var result = await Mediator.Send(command).ConfigureAwait(false);
        var response = result.Match(
            token => Ok(ToSuccess(token)),
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
}