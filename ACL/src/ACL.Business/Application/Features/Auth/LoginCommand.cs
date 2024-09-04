using System.ComponentModel.DataAnnotations;
using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace ACL.Business.Application.Features.Auth
{
    

    public record LoginCommand(string Email, string Password, string? TwoFactorCode, string? TwoFactorRecoveryCode, bool? useCookies, bool? useSessionCookies) : IRequest<SignInResult>;



    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            /*RuleFor(x => x.app_id).NotEmpty().WithMessage("App Id should not be empty!").WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
            RuleFor(x => x.app_secret).NotEmpty().WithMessage("App Secret should not be empty!").WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());*/
        }
    }
    
    public class LoginCommandHandler :  IRequestHandler<LoginCommand, SignInResult>
    {
        private ILogger<LoginCommandHandler> _logger;
        private ICurrentUser _currentUser;
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
        private readonly SignInManager<User> _signInManager;
        // Constructor
        public LoginCommandHandler(
            ILogger<LoginCommandHandler> logger,
            ICurrentUser currentUser,
            IServiceProvider serviceProvider,
            TimeProvider timeProvider,
            IOptionsMonitor<BearerTokenOptions> bearerTokenOptions,
            IEmailSender<User> emailSender,
            LinkGenerator linkGenerator,
            IHttpContextAccessor context,
            SignInManager<User> signInManager
            )
        {
            _logger = logger;
            _currentUser = currentUser;
            _serviceProvider = serviceProvider;
            _timeProvider = timeProvider;
            _bearerTokenOptions = bearerTokenOptions;
            _emailSender = emailSender;
            _linkGenerator = linkGenerator;
            _context = context;
            _signInManager = signInManager;
        }
        public async Task<SignInResult> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var useCookies = command.useCookies;
            var useSessionCookies = command.useSessionCookies;
            var useCookieScheme = (useCookies == true) || (useSessionCookies == true);
            var isPersistent = (useCookies == true) && (useSessionCookies != true);
            _signInManager.AuthenticationScheme = useCookieScheme ? IdentityConstants.ApplicationScheme : IdentityConstants.BearerScheme;

            var result = await _signInManager.PasswordSignInAsync(command.Email, command.Password, isPersistent, lockoutOnFailure: true);

            if (result.RequiresTwoFactor)
            {
                if (!string.IsNullOrEmpty(command.TwoFactorCode))
                {
                    result = await _signInManager.TwoFactorAuthenticatorSignInAsync(command.TwoFactorCode, isPersistent, rememberClient: isPersistent);
                }
                else if (!string.IsNullOrEmpty(command.TwoFactorRecoveryCode))
                {
                    result = await _signInManager.TwoFactorRecoveryCodeSignInAsync(command.TwoFactorRecoveryCode);
                }
            }

            if (!result.Succeeded)
            {
                /*return Error.Unauthorized(code: ApplicationStatusCodes.API_ERROR_AUTHORIZATION_FAILED.ToString(),
                    "Unauthorized");*/
            }
            var info = await _signInManager.GetExternalLoginInfoAsync();

            return result;
        }
        
       
    }
}