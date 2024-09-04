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
    

    public record RegisterCommand(RegisterRequest registration) : IRequest<ErrorOr<User>>;



    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            /*RuleFor(x => x.app_id).NotEmpty().WithMessage("App Id should not be empty!").WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
            RuleFor(x => x.app_secret).NotEmpty().WithMessage("App Secret should not be empty!").WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());*/
        }
    }
    
    public class RegisterCommandHandler :  IRequestHandler<RegisterCommand, ErrorOr<User>>
    {
        private ILogger<RegisterCommandHandler> _logger;
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
        // Constructor
        public RegisterCommandHandler(
            ILogger<RegisterCommandHandler> logger)
        {
            _logger = logger;
        }
        public async Task<ErrorOr<User>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}