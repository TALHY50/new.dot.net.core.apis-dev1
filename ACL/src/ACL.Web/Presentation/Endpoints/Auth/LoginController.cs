using ACL.Business.Application.Features.Auth;
using ACL.Business.Domain.Entities;
using ACL.Web.Presentation.Routes;
using ErrorOr;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SharedKernel.Main.Application.Interfaces.Services;

namespace ACL.Web.Presentation.Endpoints.Auth;

/// <summary>
/// Handles the login functionality.
/// </summary>
public class LoginController : AuthBaseController
{
    private readonly SignInManager<User> _signInManager;

    /// <inheritdoc />
    public LoginController(
        ILogger<LoginController> logger, 
        ICurrentUser currentUser,
        IServiceProvider serviceProvider,
        TimeProvider timeProvider,
        IOptionsMonitor<BearerTokenOptions> bearerTokenOptions,
        IEmailSender<User> emailSender,
        LinkGenerator linkGenerator,
        IHttpContextAccessor context,
        SignInManager<User> signInManager)
        : base(logger, currentUser, serviceProvider, timeProvider, bearerTokenOptions, emailSender, linkGenerator, context)
    {
        _signInManager = signInManager;
        // _signInManager = _serviceProvider.GetRequiredService<SignInManager<User>>();
    }

    
    [Tags("Auth")]
    [HttpPost(AuthRoutes.LoginTemplate, Name = AuthRoutes.LoginName)]
    public async Task<ActionResult> Login([FromBody] LoginRequest login, [FromQuery] bool? useCookies, [FromQuery] bool? useSessionCookies)
    {
        var useCookieScheme = (useCookies == true) || (useSessionCookies == true);
        var isPersistent = (useCookies == true) && (useSessionCookies != true);
        _signInManager.AuthenticationScheme = useCookieScheme ? IdentityConstants.ApplicationScheme : IdentityConstants.BearerScheme;

        var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, isPersistent, lockoutOnFailure: true);

        if (result.RequiresTwoFactor)
        {
            if (!string.IsNullOrEmpty(login.TwoFactorCode))
            {
                result = await _signInManager.TwoFactorAuthenticatorSignInAsync(login.TwoFactorCode, isPersistent, rememberClient: isPersistent);
            }
            else if (!string.IsNullOrEmpty(login.TwoFactorRecoveryCode))
            {
                result = await _signInManager.TwoFactorRecoveryCodeSignInAsync(login.TwoFactorRecoveryCode);
            }
        }

        if (!result.Succeeded)
        {
            return Problem(result.ToString(), statusCode: StatusCodes.Status401Unauthorized);
        }

        // The signInManager already produced the needed response in the form of a cookie or bearer token.
        return  Ok();
    }
    
    
    /*
    [Tags("Auth")]
    //[Authorize(Policy = "HasPermission")]
    [HttpPost(AuthRoutes.LoginTemplate, Name = AuthRoutes.LoginName)]

    
    public async Task<IActionResult> Login1([FromBody] LoginRequest login, [FromQuery] bool? useCookies, [FromQuery] bool? useSessionCookies, CancellationToken cancellationToken)
    {
        var command = new LoginCommand(login.Email, login.Password, login.TwoFactorCode, login.TwoFactorRecoveryCode,
            useCookies, useSessionCookies);
        _ = Task.Run(
            () => _logger.LogInformation(
                "login-request: {Name} {@UserId} {@Request}",
                nameof(LoginCommand),
                CurrentUser.UserId,
                command),
            cancellationToken);
        var result = await Mediator.Send(command).ConfigureAwait(false);

        return Ok(result);
        // return Ok(ToSuccess(response.Value));
        /*var response = result.Match(
            result => Ok(result),
            Problem);
        _ = Task.Run(
            () => _logger.LogInformation(
                "login-response: {Name} {@UserId} {@Response}",
                nameof(response),
                CurrentUser.UserId,
                response),
            cancellationToken);#1#
        //return response;
    }*/
}
