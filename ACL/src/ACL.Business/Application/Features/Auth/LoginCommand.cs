using ACL.Business.Application.Features.Users;
using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Application.Interfaces.Services;
using ACL.Business.Contracts.Requests;
using ACL.Business.Contracts.Responses;
using ACL.Business.Infrastructure.Jwt;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SharedKernel.Main.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Claim = System.Security.Claims.Claim;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace ACL.Business.Application.Features.Auth
{


    public record LoginCommand(string Email, string Password) : IRequest<DataResponse<LoginResultDto>>;


    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            /*RuleFor(x => x.app_id).NotEmpty().WithMessage("App Id should not be empty!").WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
            RuleFor(x => x.app_secret).NotEmpty().WithMessage("App Secret should not be empty!").WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());*/
        }
    }


    public class LoginCommandHandler : IRequestHandler<LoginCommand, DataResponse<LoginResultDto>>
    {
        private readonly ILogger<LoginCommandHandler> _logger;
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserRepository _userRepository;
        private readonly IUserSettingRepository _userSettingRepository;
        private readonly IIdentity _identity;
        private readonly IRefreshTokenUseCase _refreshTokenUseCase;
        private readonly CreateJwtTokenCommandHandler _tokenHandler;

        public LoginCommandHandler(
            ILogger<LoginCommandHandler> logger,
            IAuthenticationService authenticationService,
            IUserRepository userRepository,
            IUserSettingRepository userSettingRepository,
            IIdentity identity,
            IRefreshTokenUseCase refreshTokenUseCase,
            CreateJwtTokenCommandHandler tokenHandler)
        {
            _logger = logger;
            _authenticationService = authenticationService;
            _userRepository = userRepository;
            _userSettingRepository = userSettingRepository;
            _identity = identity;
            _refreshTokenUseCase = refreshTokenUseCase;
            _tokenHandler = tokenHandler;
        }

        public async Task<DataResponse<LoginResultDto>> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var user =  _userRepository.FindByEmail(command.Email);
                if (user == null)
                {
                    return new DataResponse<LoginResultDto>
                    {
                        IsSuccess = false,
                        ErrorMessage = "User not found."
                    };
                }

                var setting = await _userRepository.GetByIdAsync(user.Id);
                if (setting == null)
                {
                    return new DataResponse<LoginResultDto>
                    {
                        IsSuccess = false,
                        ErrorMessage = "User settings not found."
                    };
                }

                var createTokenCommand = new CreateJwtTokenCommand(user.Id, new { });
                var tokenResult = await _tokenHandler.Handle(createTokenCommand, cancellationToken);
                if (tokenResult.IsError)
                {
                    // Assuming Errors is a list or there's a method to convert errors to a string
                    var errorMessage = string.Join(", ", tokenResult.Errors.Select(e => e.ToString()));
                    return new DataResponse<LoginResultDto>
                    {
                        IsSuccess = false,
                        ErrorMessage = errorMessage,
                    };
                }

                // Assuming refreshTokenUseCase provides a method Execute that returns a type of RefreshTokenResponse
                var refreshTokenResult = await _refreshTokenUseCase.Execute(new RefreshTokenRequest { AccessToken = tokenResult.Value });

                if (!refreshTokenResult.IsSuccess)
                {
                    return new DataResponse<LoginResultDto>
                    {
                        IsSuccess = false,
                        ErrorMessage = refreshTokenResult.ErrorMessage
                    };
                }

                return new DataResponse<LoginResultDto>
                {
                    IsSuccess = true,
                    Data = new LoginResultDto
                    {
                        token_type = "Bearer",
                        access_token = refreshTokenResult.AccessToken,
                        expires_in = 3600,
                        refresh_token = refreshTokenResult.RefreshToken
                    }
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during login");
                return new DataResponse<LoginResultDto>
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }

        }

            public async Task<SignInResult> PasswordLogInAsync(string userName, string password)
            {
                // Hardcoded credentials for testing
                var staticUserName = "testuser@example.com";
                var staticPassword = "TestPassword123";

                // Simulate a delay for asynchronous operation
                await Task.Delay(100);

                if (userName == staticUserName && password == staticPassword)
                {
                    return SignInResult.Success;
                }
                return SignInResult.Failed;
            }

            private string GenerateRefreshToken()
            {
                var uuid = Guid.NewGuid().ToString();
                var randomNumber = new byte[64];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(randomNumber);
                    var base64Token = Convert.ToBase64String(randomNumber);
                    return $"{uuid}-{base64Token}"; // Concatenate UUID with the Base64 random string
                }
            }

        }
    }

