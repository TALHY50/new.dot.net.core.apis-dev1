using ACL.Business.Application.Features.Auth;
using ACL.Business.Application.Interfaces.Services;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Entities;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace ACL.Web.Presentation.Endpoints.Auth
{
    public class AccessTokenController : AuthBaseController
    {
        private readonly ITokenService _tokenService;
        private readonly IIdentity _identity;
        private readonly UserManager<User> _userManager;
        private readonly CreateJwtTokenCommandHandler _tokenHandler;
        private readonly IRefreshTokenService _refreshTokenValidator;
        private readonly IRefreshTokenUseCase _refreshTokenUseCase;
        private readonly IClientStore _clientStore;

        public AccessTokenController(
            ILogger<AccessTokenController> logger,
            ICurrentUser currentUser,
            IServiceProvider serviceProvider,
            TimeProvider timeProvider,
            IOptionsMonitor<BearerTokenOptions> bearerTokenOptions,
            IEmailSender<User> emailSender,
            LinkGenerator linkGenerator,
            IHttpContextAccessor context,
            ITokenService tokenService,
            IIdentity identity,
            UserManager<User> userManager,
            CreateJwtTokenCommandHandler tokenHandler,
            IRefreshTokenService refreshTokenValidator,
            IRefreshTokenUseCase refreshTokenUseCase,
            IClientStore clientStore
        ) : base(logger, currentUser, serviceProvider, timeProvider, bearerTokenOptions, emailSender, linkGenerator, context)
        {
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            _identity = identity ?? throw new ArgumentNullException(nameof(identity));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _tokenHandler = tokenHandler ?? throw new ArgumentNullException(nameof(tokenHandler));
            _refreshTokenValidator = refreshTokenValidator ?? throw new ArgumentNullException(nameof(refreshTokenValidator));
            _refreshTokenUseCase = refreshTokenUseCase ?? throw new ArgumentNullException(nameof(refreshTokenUseCase));
            _clientStore = clientStore ?? throw new ArgumentNullException(nameof(clientStore));
        }

        [Tags("Auth")]
        [HttpPost("refresh-token")]
        public async Task<ActionResult<Response>> RefreshToken([FromBody] RefreshAccessTokenRequest request, CancellationToken cancellationToken)
        {
            var client = await _clientStore.FindClientByIdAsync(request.ClientId);
            if (client == null)
            {
                return BadRequest(SharedKernel.Main.Contracts.Response.Failure("Invalid client ID."));
            }

            var validationResult = await _refreshTokenValidator.ValidateRefreshTokenAsync(request.RefreshToken, client);
            if (validationResult.IsError)
            {
                return BadRequest(SharedKernel.Main.Contracts.Response.Failure(validationResult.Error));
            }

            var userId = await _identity.GetUserIdFromToken(request.RefreshToken);
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest(SharedKernel.Main.Contracts.Response.Failure("Invalid user associated with the token."));
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return BadRequest(SharedKernel.Main.Contracts.Response.Failure("User not found."));
            }

            var createTokenCommand = new CreateJwtTokenCommand(user.Id, new { });
            var tokenResult = await _tokenHandler.Handle(createTokenCommand, cancellationToken);

            var refreshTokenResult = await _refreshTokenUseCase.Execute(new RefreshTokenRequest { AccessToken = tokenResult.Value });
            if (!refreshTokenResult.IsSuccess)
            {
                return BadRequest(SharedKernel.Main.Contracts.Response.Failure(refreshTokenResult.ErrorMessage));
            }

            var response = new DataResponse<LoginResultDto>
            {
                IsSuccess = true,
                Data = new LoginResultDto
                {
                    token_type = "Bearer",
                    access_token = refreshTokenResult.AccessToken,
                    expires_in = client.AccessTokenLifetime,
                    refresh_token = refreshTokenResult.RefreshToken
                }
            };

            return Ok(response);
        }
    }
}