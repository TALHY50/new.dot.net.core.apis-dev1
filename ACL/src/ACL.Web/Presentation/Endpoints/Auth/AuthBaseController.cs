using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using ACL.Business.Domain.Entities;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace ACL.Web.Presentation.Endpoints.Auth;

public class AuthBaseController : ApiControllerBase
{
    protected static readonly EmailAddressAttribute _emailAddressAttribute = new();
    protected readonly IServiceProvider _serviceProvider;
    protected UserManager<User> _userManager;
    protected IUserStore<User> _userStore;
    protected IUserEmailStore<User> _emailStore;
    protected readonly TimeProvider _timeProvider;
    protected readonly IOptionsMonitor<BearerTokenOptions> _bearerTokenOptions;
    protected readonly IEmailSender<User> _emailSender;
    protected readonly LinkGenerator _linkGenerator;
    protected readonly IHttpContextAccessor _context;
    public AuthBaseController(
        ILogger<AuthBaseController> logger, 
        ICurrentUser currentUser,
        IServiceProvider serviceProvider,
        TimeProvider timeProvider,
        IOptionsMonitor<BearerTokenOptions> bearerTokenOptions,
        IEmailSender<User> emailSender,
        LinkGenerator linkGenerator,
        IHttpContextAccessor context)
        : base(logger, currentUser)
    {
        _serviceProvider = serviceProvider;
        _timeProvider = timeProvider;
        _bearerTokenOptions = bearerTokenOptions;
        _emailSender = emailSender;
        _linkGenerator = linkGenerator;
        _context = context;
    }

    protected AuthBaseController(ILogger<CreateJwtTokenController> logger, ICurrentUser currentUser)
    {
        
    }

    protected async Task SendConfirmationEmailAsync(User user, UserManager<User> userManager, HttpContext context, string email, bool isChange = false)
    {
        string? confirmEmailEndpointName = AuthRoutes.ConfirmEmailName;
        if (confirmEmailEndpointName is null)
        {
            throw new NotSupportedException("No email confirmation endpoint was registered!");
        }

        var code = isChange
            ? await userManager.GenerateChangeEmailTokenAsync(user, email)
            : await userManager.GenerateEmailConfirmationTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

        var userId = await userManager.GetUserIdAsync(user);
        var routeValues = new RouteValueDictionary()
        {
            ["userId"] = userId,
            ["code"] = code,
        };

        if (isChange)
        {
            // This is validated by the /confirmEmail endpoint on change.
            routeValues.Add("changedEmail", email);
        }

        var confirmEmailUrl = _linkGenerator.GetUriByName(context, confirmEmailEndpointName, routeValues)
                              ?? throw new NotSupportedException($"Could not find endpoint named '{confirmEmailEndpointName}'.");

        await _emailSender.SendConfirmationLinkAsync(user, email, HtmlEncoder.Default.Encode(confirmEmailUrl));
    }
}