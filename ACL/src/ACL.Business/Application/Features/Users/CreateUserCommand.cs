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

namespace ACL.Business.Application.Features.Users
{

    [Authorize]

    public record CreateUserCommand(
    string? first_name,
    string? last_name,
    string? email,
    string? avatar,
    string? language,
    string? password,
    DateTime? dob,
    sbyte? gender,
    string? address,
    string? city,
    uint? country,
    string? phone,
    string? user_name,
    string? img_path,
    sbyte? status,
    ulong[]? user_group,
    string? salt) : IRequest<ErrorOr<User>>;



    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.status).NotEmpty().IsInEnum();
        }
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public class CreateUserCommandHandler : UserBase, IRequestHandler<CreateUserCommand, ErrorOr<User>>
    {
        private readonly ICurrentUser _user;
        private readonly ApplicationDbContext _otherDbContext;
        public static IHttpContextAccessor HttpContextAccessor;
        private readonly ITransactionHandler _transactionHandler;
        private readonly IUserService _repository;
        private readonly ICryptography _cryptography;
        private readonly IConfiguration _config;
        // Constructor
        public CreateUserCommandHandler(
            ILogger<CreateUserCommandHandler> logger,
            ApplicationDbContext dbContext,
            ITransactionHandler transactionHandler,
            ICurrentUser user, ApplicationDbContext otherDbContext, ICompanyService companyRepository, IHttpContextAccessor httpContextAccessor, IUserService repository, ICryptography cryptography, IConfiguration config) : base(logger, user)
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
        public async Task<ErrorOr<User>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var salt = this._cryptography.GenerateSalt();
            var companyId = (uint)AppAuth.GetAuthInfo().CompanyId;
            var req = new User
            {
                FirstName = command.first_name,
                LastName = command.last_name,
                Email = command.email,
                Password = this._cryptography.HashPassword(command.password, salt),
                Avatar = command.avatar,
                Dob = command.dob,
                Gender = (sbyte)command.gender,
                Address = command.address,
                City = command.city,
                Country = (uint)command.country,
                Phone = command.phone,
                Username = command.user_name,
                Language = command.language,
                ImgPath = command.img_path,
                Status = (sbyte)command.status,
                Salt = salt,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedById = (uint)AppAuth.GetAuthInfo().UserId,
                CompanyId = (companyId != 0) ? companyId : (uint)AppAuth.GetAuthInfo().CompanyId,
                UserType = (companyId == 0) ? uint.Parse(this._config["USER_TYPE_S_ADMIN"]) : uint.Parse(this._config["USER_TYPE_USER"]),
                Claims = new Claim[] { }
            };
          
            var result = await _transactionHandler.ExecuteWithTransactionAsync<User>(
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