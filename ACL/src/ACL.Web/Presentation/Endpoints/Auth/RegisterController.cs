using ACL.Business.Application.Features.Users;
using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ACL.Business.Infrastructure.Auth.Auth;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace ACL.Web.Presentation.Endpoints.Auth;

public class RegisterController : AuthBaseController
{
    private readonly IUserRepository _userRepository;
    private readonly UserManager<User> _userManager;
    private readonly IUserEmailStore<User> _emailStore;
    private readonly ICryptography _cryptography;
    private readonly IUserUserGroupRepository _userUserGroupRepository;

    public RegisterController(
        ILogger<RegisterController> logger,
        ICurrentUser currentUser,
        IServiceProvider serviceProvider,
        TimeProvider timeProvider,
        IOptionsMonitor<BearerTokenOptions> bearerTokenOptions,
        IEmailSender<User> emailSender,
        LinkGenerator linkGenerator,
        IHttpContextAccessor context,
        IUserRepository userRepository,
        ICryptography cryptography,
        IUserUserGroupRepository userUserGroupRepository
    ) : base(logger, currentUser, serviceProvider, timeProvider, bearerTokenOptions, emailSender, linkGenerator, context)
    {
        _userManager = serviceProvider.GetRequiredService<UserManager<User>>()
            ?? throw new ArgumentNullException(nameof(UserManager<User>));

        if (!_userManager.SupportsUserEmail)
        {
            throw new NotSupportedException($"{nameof(RegisterController)} requires a user store with email support.");
        }

        var userStore = serviceProvider.GetRequiredService<IUserStore<User>>()
            ?? throw new ArgumentNullException(nameof(IUserStore<User>));

        _emailStore = userStore as IUserEmailStore<User>
            ?? throw new InvalidCastException($"{nameof(RegisterController)} requires a user store that supports email.");

        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _cryptography = cryptography ?? throw new ArgumentNullException(nameof(cryptography));
        _userUserGroupRepository = userUserGroupRepository ?? throw new ArgumentNullException(nameof(userUserGroupRepository));
    }

    [Tags("Auth")]
    [HttpPost(AuthRoutes.RegisterTemplate, Name = AuthRoutes.RegisterName)]
    public async Task<ActionResult<Response>> Register([FromBody] CreateUserCommand command)
    {
        if (_userRepository.IsAclUserEmailExist(command.email))
        {
            return BadRequest(SharedKernel.Main.Contracts.Response.Failure("Email already exists."));
        }

        var salt = _cryptography.GenerateSalt();

        var user = new User
        {
            FirstName = command.first_name,
            LastName = command.last_name,
            Email = command.email,
            UserName = command.user_name,
            PasswordHash = _cryptography.HashPassword(command.password, salt),
            Avatar = command.avatar,
            Dob = command.dob,
            Gender = command.gender,
            Address = command.address,
            City = command.city,
            Country = command.country ?? 0,
            PhoneNumber = command.phone,
            Language = command.language,
            ImgPath = command.img_path,
            Status = (sbyte)command.status,
            Salt = salt,
            CompanyId = (uint)AppAuth.GetAuthInfo().CompanyId,
            UserType = ((uint)AppAuth.GetAuthInfo().CompanyId == 0) ? (uint)1 : (uint)2, // Admin or User
            EmailConfirmed = false,
            SecurityStamp = salt,
            ConcurrencyStamp = salt,
            TwoFactorEnabled = false,
            LockoutEnabled = false,
            AccessFailedCount = 0,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        var result = await _userManager.CreateAsync(user, command.password);
        if (!result.Succeeded)
        {
            return BadRequest(CreateFailureResponse(result));
        }

        if (command.user_group != null && command.user_group.Length > 0)
        {
            var userUserGroups = PrepareDataForUserUserGroups(command, user.Id);
            await _userUserGroupRepository.AddRangeAsync(userUserGroups);
        }

        var response = new DataResponse<User>
        {
            Data = user,
            IsSuccess = true
        };

        return Ok(response);
    }

    private Response CreateFailureResponse(IdentityResult result)
    {
        var errorMessage = string.Join("; ", result.Errors.Select(e => e.Description));
        return SharedKernel.Main.Contracts.Response.Failure(errorMessage);
    }

    private ActionResult CreateValidationProblem(IdentityResult result)
    {
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }
        return ValidationProblem(ModelState);
    }

    private UserUsergroup[] PrepareDataForUserUserGroups(CreateUserCommand command, uint? userId)
    {
        if (userId == null)
        {
            throw new ArgumentNullException(nameof(userId));
        }

        return command.user_group.Select(userGroup => new UserUsergroup
        {
            UserId = userId.Value,
            UsergroupId = userGroup,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        }).ToArray();
    }
}