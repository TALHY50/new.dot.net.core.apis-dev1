using ACL.Business.Domain.Entities;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SharedKernel.Main.Application.Interfaces.Services;

namespace ACL.Web.Presentation.Endpoints.Auth;


/// <summary>
/// 
/// </summary>
[ApiExplorerSettings(IgnoreApi = true)]
public class RegisterController : AuthBaseController
{
    /// <inheritdoc />
    public RegisterController(
        ILogger<RegisterController> logger, 
        ICurrentUser currentUser,
        IServiceProvider serviceProvider,
        TimeProvider timeProvider,
        IOptionsMonitor<BearerTokenOptions> bearerTokenOptions,
        IEmailSender<User> emailSender,
        LinkGenerator linkGenerator,
        IHttpContextAccessor context
        )
        : base(logger, currentUser, serviceProvider, timeProvider, bearerTokenOptions, emailSender, linkGenerator, context)
    {
        _userManager = _serviceProvider.GetRequiredService<UserManager<User>>();

        if (!_userManager.SupportsUserEmail)
        {
            throw new NotSupportedException($"{nameof(RegisterController)} requires a user store with email support.");
        }

        _userStore = _serviceProvider.GetRequiredService<IUserStore<User>>();
        _emailStore = (IUserEmailStore<User>)_userStore;
    }
    

    [Tags("Auth")]
    [HttpPost(AuthRoutes.RegisterTemplate, Name = AuthRoutes.RegisterName)]
    public async Task<ActionResult> Register([FromBody] RegisterRequest registration)
    {
        var email = registration.Email;

        if (string.IsNullOrEmpty(email) || !_emailAddressAttribute.IsValid(email))
        {
            return CreateValidationProblem(IdentityResult.Failed(_userManager.ErrorDescriber.InvalidEmail(email)));
        }

        var user = new User();
        await _userStore.SetUserNameAsync(user, email, CancellationToken.None);
        await _emailStore.SetEmailAsync(user, email, CancellationToken.None);
        var result = await _userManager.CreateAsync(user, registration.Password);

        if (!result.Succeeded)
        {
            return CreateValidationProblem(result);
        }

        //await SendConfirmationEmailAsync(user, _userManager, _context.HttpContext, email);
        return Ok();
    }

    private ActionResult CreateValidationProblem(IdentityResult result)
    {
        var errors = result.Errors;
        foreach (var error in errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }
        return ValidationProblem(ModelState);
    }

   
}
