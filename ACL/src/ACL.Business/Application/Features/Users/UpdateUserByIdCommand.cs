using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Domain.Entities;
using ACL.Business.Domain.Services;
using ACL.Business.Infrastructure.Auth.Auth;
using ACL.Business.Infrastructure.Persistence.Context;
using ACL.Business.Infrastructure.Persistence.Repositories;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Application.Rules;
using SharedKernel.Main.Contracts;
using SharedKernel.Main.Infrastructure.Persistence;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

namespace ACL.Business.Application.Features.Users
{

    //[Authorize]
    public record UpdateUserByIdCommand(uint id,

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
    byte? status,
    uint[]? user_group,
    string? salt)
      : IRequest<ErrorOr<User>>;


    public class UpdateUserByIdCommandValidator : AbstractValidator<UpdateUserByIdCommand>
    {
        public UpdateUserByIdCommandValidator()
        {
            // RuleFor(x => x.status).NotEmpty().IsInEnum();
            RuleFor(x => x.email).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_EMAIL_IS_MISSING_OR_INVALID.ToString()).WithMessage("Email should not empty or invalid!");
            RuleFor(x => x.password).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_INPUT_PARAMETER_INVALID.ToString()).WithMessage("Password should not empty or invalid!");
        }
    }



    [ApiExplorerSettings(IgnoreApi = true)]

    public class UpdateUserByIdCommandHandler : UserBase, IRequestHandler<UpdateUserByIdCommand, ErrorOr<User>>
    {

        private readonly ICurrentUser _user;
        private readonly ApplicationDbContext _dbContext;
        private readonly ITransactionHandler _transactionHandler;
        private readonly IUserUserGroupRepository _userUserGroupRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICryptography _cryptography;
        private readonly IConfiguration _config;
        private readonly IGuardAgainstNullUpdate _guard;
        private readonly ILogger<UpdateUserByIdCommandHandler> _logger;
        public UpdateUserByIdCommandHandler(
             ILogger<UpdateUserByIdCommandHandler> logger,
             ApplicationDbContext dbContext, IUserRepository userRepository, IUserUserGroupRepository userUserGroupRepository, ICryptography cryptography, IConfiguration config, ICurrentUser user, ITransactionHandler transactionHandler, IGuardAgainstNullUpdate guard)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _cryptography = cryptography ?? throw new ArgumentNullException(nameof(cryptography));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userUserGroupRepository = userUserGroupRepository ?? throw new ArgumentNullException(nameof(userUserGroupRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _guard = guard;
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _transactionHandler = transactionHandler ?? throw new ArgumentNullException(nameof(transactionHandler));
        }

        public async Task<ErrorOr<User>> Handle(UpdateUserByIdCommand command, CancellationToken cancellationToken)
        {

            User? aclUser = _userRepository.Find(command.id);
            var strategy = this._dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(() =>
            {
                using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = this._dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        if (aclUser != null)
                        {
                            aclUser = PrepareInputData(command);
                            aclUser = _userRepository.Update(aclUser);
                            // first delete all user user group
                            UserUsergroup[] userUserGroups = _userUserGroupRepository.Where(command.id).ToArray();
                            _userUserGroupRepository.RemoveRange(userUserGroups);
                            // need to insert user user group
                            UserUsergroup[]? userGroupPrepareData = PrepareDataForUserUserGroups(command);
                            _userUserGroupRepository.AddRange(userGroupPrepareData);

                            List<uint> users = new List<uint> { aclUser.Id };
                            _userRepository.UpdateUserPermissionVersion(users);
                            transaction.Commit();
                        }
                        else
                        {
                            transaction.Rollback();
                            ///WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
                            //this.ScopeResponse.Message = this.MessageResponse.notFoundMessage;
                            //this.ScopeResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;

                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        // return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), "User not found");
                        //this.ScopeResponse.Message = ex.Message;
                        //this.ScopeResponse.StatusCode = ApplicationStatusCodes.GENERAL_FAILURE;
                    }
                }

                return Task.CompletedTask;
            });
            return aclUser;


        }


        public User PrepareInputData(UpdateUserByIdCommand request)
        {
            User? aclUser = _userRepository.Find(request.id);
            var salt = this._cryptography.GenerateSalt();
            if (_userRepository.IsAclUserEmailExist(request.email, aclUser.Id))
            {
                throw new InvalidOperationException("Email already exist");
            }
            aclUser.FirstName = request.first_name;
            aclUser.LastName = request.last_name;
            aclUser.Email = request.email;
            aclUser.Password = aclUser.Password;
            aclUser.Avatar = request.avatar;
            aclUser.Dob = request.dob;
            aclUser.Gender = request.gender;
            aclUser.Address = request.address;
            aclUser.City = request.city;
            aclUser.Country = (uint)request.country;
            aclUser.Phone = request.phone;
            aclUser.Language = "en-US";
            aclUser.UserName = request.user_name;
            aclUser.ImgPath = request.img_path;
            aclUser.Status = (sbyte)request.status;
            aclUser.UpdatedAt = DateTime.Now;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8629 // Possible null reference argument.
            aclUser.CompanyId = (uint)AppAuth.GetAuthInfo().CompanyId;
            aclUser.UserType = (uint)AppAuth.GetAuthInfo().UserType;
            aclUser.Salt = aclUser.Salt;
           // aclUser.Claims = aclUser.Claims;
            return aclUser;
        }

        /// <inheritdoc/>
        public UserUsergroup[] PrepareDataForUserUserGroups(UpdateUserByIdCommand request)
        {
            IList<UserUsergroup> res = new List<UserUsergroup>();

            foreach (uint user_group in request.user_group)
            {
                UserUsergroup userUserGroup = new UserUsergroup();
                userUserGroup.UserId = request.id;
                userUserGroup.UsergroupId = user_group;
                userUserGroup.CreatedAt = DateTime.Now;
                userUserGroup.UpdatedAt = DateTime.Now;
                res.Add(userUserGroup);
            }
            return res.ToArray();
        }

    }
}
