using System.ComponentModel.DataAnnotations;
using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ACL.Business.Domain.Services;
using ACL.Business.Infrastructure.Auth.Auth;
using ACL.Business.Infrastructure.Persistence.Context;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace ACL.Business.Application.Features.Auth
{
    

    public record LogginCommand(LoginRequest login,  bool? useCookies, bool? useSessionCookies) : IRequest<ErrorOr<User>>;



    public class LogginCommandValidator : AbstractValidator<LogginCommand>
    {
        public LogginCommandValidator()
        {
            /*RuleFor(x => x.app_id).NotEmpty().WithMessage("App Id should not be empty!").WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
            RuleFor(x => x.app_secret).NotEmpty().WithMessage("App Secret should not be empty!").WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());*/
        }
    }
    
    public class LogginCommandHandler :  IRequestHandler<LogginCommand, ErrorOr<User>>
    {
        private ILogger<LogginCommandHandler> _logger;
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
        public LogginCommandHandler(
            ILogger<LogginCommandHandler> logger,
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
        public async Task<ErrorOr<User>> Handle(LogginCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}