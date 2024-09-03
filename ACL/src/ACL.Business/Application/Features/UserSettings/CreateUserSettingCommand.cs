using Ardalis.Specification;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;
using Microsoft.AspNetCore.Authorization;
using SharedKernel.Main.Application.Rules;
using Microsoft.Extensions.Logging;
using SharedKernel.Main.Application.Enums;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Infrastructure.Persistence;
using ACL.Business.Domain.Entities;
using SharedKernel.Main.Contracts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using ACL.Business.Domain.Services;
using Microsoft.AspNetCore.Http;
using ACL.Business.Infrastructure.Auth.Auth;
using ACL.Business.Infrastructure.Persistence.Context;
using ACL.Business.Contracts.Requests;
using Microsoft.Extensions.Configuration;
using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Application.Features.Users;

namespace ACL.Business.Application.Features.UserSettings
{

    [Authorize]

    public record CreateUserSettingCommand(string app_id,string app_secret) : IRequest<ErrorOr<UserSetting>>;



    public class CreateUserSettingCommandValidator : AbstractValidator<CreateUserSettingCommand>
    {
        public CreateUserSettingCommandValidator()
        {
            RuleFor(x => x.app_id).NotEmpty().WithMessage("App Id should not be empty!").WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
            RuleFor(x => x.app_secret).NotEmpty().WithMessage("App Secret should not be empty!").WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public class CreateUserSettingCommandHandler :  IRequestHandler<CreateUserSettingCommand, ErrorOr<UserSetting>>
    {
        private readonly ICurrentUser _user;
        private readonly ApplicationDbContext _otherDbContext;
        public static IHttpContextAccessor HttpContextAccessor;
        private readonly ITransactionHandler _transactionHandler;
        private readonly IUserSettingRepository _repository;
        private readonly ICryptography _cryptography;
        private readonly IConfiguration _config;
        // Constructor
        public CreateUserSettingCommandHandler(
            ILogger<CreateUserSettingCommandHandler> logger,
            ApplicationDbContext dbContext,
            ITransactionHandler transactionHandler,
            ICurrentUser user, ApplicationDbContext otherDbContext, ICompanyService companyRepository, IHttpContextAccessor httpContextAccessor, IUserSettingRepository repository, ICryptography cryptography, IConfiguration config) 
        {
            _user = user ?? throw new ArgumentNullException(nameof(user));
            _config = config ?? throw new ArgumentNullException(nameof(config));
            var _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _cryptography = cryptography ?? throw new ArgumentNullException(nameof(cryptography));
            _otherDbContext = otherDbContext ?? throw new ArgumentNullException(nameof(otherDbContext));
            _transactionHandler = transactionHandler ?? throw new ArgumentNullException(nameof(transactionHandler));
            HttpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            AppAuth.Initialize(HttpContextAccessor, _otherDbContext);
            AppAuth.SetAuthInfo(HttpContextAccessor);
        }
        public async Task<ErrorOr<UserSetting>> Handle(CreateUserSettingCommand command, CancellationToken cancellationToken)
        {
            var req = new UserSetting
            {
                AppId = command.app_id,
                AppSecret = command.app_secret,
            };
          
            var result = await _transactionHandler.ExecuteWithTransactionAsync<UserSetting>(
               async (ct) =>
               {
                   var obj =  await _repository.AddAsync(req);
                   return obj;

               }, _otherDbContext, 3, cancellationToken
           );

            if (result.IsError)
            {
                return result;
            }

            return result.Value;
        }
    }
}