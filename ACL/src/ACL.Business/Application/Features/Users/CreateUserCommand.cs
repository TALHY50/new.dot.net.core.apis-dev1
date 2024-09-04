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
using System.ComponentModel.Design;
using System.Security.Claims;
using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Infrastructure.Persistence.Repositories;

namespace ACL.Business.Application.Features.Users;
//{

//[Authorize]

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
byte status,
uint[]? user_group,
string? salt) : IRequest<ErrorOr<User>>;



//    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
//    {
//        public CreateUserCommandValidator()
//        {
//            //RuleFor(x => x.status).NotEmpty().IsInEnum();
//        }
//    }

//    [ApiExplorerSettings(IgnoreApi = true)]
//    public class CreateUserCommandHandler : UserBase, IRequestHandler<CreateUserCommand, ErrorOr<User>>
//    {
//        private readonly ICurrentUser _user;
//        private readonly ApplicationDbContext _otherDbContext;
//        public static IHttpContextAccessor HttpContextAccessor;
//        private readonly ITransactionHandler _transactionHandler;
//        private readonly IUserService _repository;
//        private readonly IUserUserGroupRepository _userUserGroupRepository;
//        private readonly IUserRepository _userRepository;
//        private readonly ICryptography _cryptography;
//        private readonly IConfiguration _config;
//        // Constructor
//        public CreateUserCommandHandler(
//            ILogger<CreateUserCommandHandler> logger,
//            ApplicationDbContext dbContext,
//            ITransactionHandler transactionHandler,
//            ICurrentUser user, ApplicationDbContext otherDbContext, IUserRepository userRepository, ICompanyService companyRepository, IHttpContextAccessor httpContextAccessor, IUserService repository, IUserUserGroupRepository userUserGroupRepository, ICryptography cryptography, IConfiguration config) : base(logger, user)
//        {
//            _user = user ?? throw new ArgumentNullException(nameof(user));
//            _config = config ?? throw new ArgumentNullException(nameof(config));
//            var _logger = logger ?? throw new ArgumentNullException(nameof(logger));
//            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
//            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
//            _userUserGroupRepository = userUserGroupRepository ?? throw new ArgumentNullException(nameof(userUserGroupRepository));
//            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
//            _otherDbContext = otherDbContext ?? throw new ArgumentNullException(nameof(otherDbContext));
//            _transactionHandler = transactionHandler ?? throw new ArgumentNullException(nameof(transactionHandler));
//            HttpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
//            AppAuth.Initialize(HttpContextAccessor, _otherDbContext);
//            AppAuth.SetAuthInfo(HttpContextAccessor);
//        }
//        public async Task<ErrorOr<User>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
//        {
//            User? req = PrepareInputData(command);
//            var obj = await _repository.AddAsync(req);
//            UserUsergroup[] userUserGroups = PrepareDataForUserUserGroups(command, obj?.Id);
//            _userUserGroupRepository.AddRange(userUserGroups);
//            return obj;

//       //     var result = await _transactionHandler.ExecuteWithTransactionAsync<User>(
//       //    async (ct) =>
//       //    {
//       //        var obj = await _repository.AddAsync(req);
//       //        UserUsergroup[] userUserGroups = PrepareDataForUserUserGroups(command, obj?.Id);
//       //        _userUserGroupRepository.AddRange(userUserGroups);
//       //        return obj;

//       //    }, _otherDbContext, 3, cancellationToken
//       //);

//       //     if (result.IsError)
//       //     {
//       //         return result;
//       //     }

//       //     return result.Value;
//        }

//        public User PrepareInputData(CreateUserCommand request, User? aclUser = null)
//        {
//            var salt = this._cryptography.GenerateSalt();
//            if (aclUser == null)
//            {

//                if (_userRepository.IsAclUserEmailExist(request.email))
//                {
//                    throw new InvalidOperationException("Email already exist");
//                }
//                return new User
//                {
//                    FirstName = request.first_name,
//                    LastName = request.last_name,
//                    Email = request.email,
//                    Password = this._cryptography.HashPassword(request.password, salt),
//                    Avatar = request.avatar,
//                    Dob = request.dob,
//                    Gender = request.gender,
//                    Address = request.address,
//                    City = request.city,
//                    Country = (uint)request.country,
//                    Phone = request.phone,
//                    Username = request.user_name,
//                    Language = request.language,
//                    ImgPath = request.img_path,
//                    Status = (sbyte)request.status,
//                    CreatedAt = DateTime.Now,
//                    UpdatedAt = DateTime.Now,
//                    CreatedById = (uint)AppAuth.GetAuthInfo().UserId,
//                    CompanyId = (uint)AppAuth.GetAuthInfo().CompanyId,
//                    //  UserType = ((uint)AppAuth.GetAuthInfo().CompanyId == 0) ? uint.Parse(this._config["USER_TYPE_S_ADMIN"]) : uint.Parse(this._config["USER_TYPE_USER"]),
//                    UserType = ((uint)AppAuth.GetAuthInfo().CompanyId == 0) ? (uint)1 : (uint)2,
//                    Salt = salt,
//                    Claims = new Domain.Entities.Claim[] { }
//                };
//            }
//            else
//            {
//                if (_userRepository.IsAclUserEmailExist(request.email, aclUser.Id))
//                {
//                    throw new InvalidOperationException("Email already exist");
//                }
//                aclUser.FirstName = request.first_name;
//                aclUser.LastName = request.last_name;
//                aclUser.Email = request.email;
//                aclUser.Password = aclUser.Password;
//                aclUser.Avatar = request.avatar;
//                aclUser.Dob = request.dob;
//                aclUser.Gender = request.gender;
//                aclUser.Address = request.address;
//                aclUser.City = request.city;
//                aclUser.Country = (uint)request.country;
//                aclUser.Phone = request.phone;
//                aclUser.Language = "en-US";
//                aclUser.Username = request.user_name;
//                aclUser.ImgPath = request.img_path;
//                aclUser.Status = (sbyte)request.status;
//                aclUser.UpdatedAt = DateTime.Now;
//#pragma warning disable CS8602 // Dereference of a possibly null reference.
//#pragma warning disable CS8604 // Possible null reference argument.
//#pragma warning disable CS8629 // Possible null reference argument.
//                aclUser.CompanyId = (uint)AppAuth.GetAuthInfo().CompanyId;
//                aclUser.UserType = (uint)AppAuth.GetAuthInfo().UserType;
//                aclUser.Salt = aclUser.Salt;
//                aclUser.Claims = aclUser.Claims;
//            }
//            return aclUser;
//        }

//        /// <inheritdoc/>
//        public UserUsergroup[] PrepareDataForUserUserGroups(CreateUserCommand request, uint? user_id)
//        {
//            IList<UserUsergroup> res = new List<UserUsergroup>();

//            foreach (uint user_group in request.user_group)
//            {
//                UserUsergroup userUserGroup = new UserUsergroup();
//                userUserGroup.UserId = user_id ?? 0;
//                userUserGroup.UsergroupId = user_group;
//                userUserGroup.CreatedAt = DateTime.Now;
//                userUserGroup.UpdatedAt = DateTime.Now;
//                res.Add(userUserGroup);
//            }
//            return res.ToArray();
//        }
//    }
//}