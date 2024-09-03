using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Application.Interfaces.Services;
using ACL.Business.Domain.Entities;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedKernel.Main.Application.Extensions;
using SharedKernel.Main.Contracts;

namespace ACL.Business.Application.Features.Auth
{
    public record ValidateJwtTokenCommand(
        string Token,
        object Payload
    ) : IRequest<ErrorOr<User>>;

    public class ValidateJwtTokenCommandValidator : AbstractValidator<ValidateJwtTokenCommand>
    {
        public ValidateJwtTokenCommandValidator()
        {
        }
    }

    public class ValidateJwtTokenCommandHandler(ILogger<ValidateJwtTokenCommandHandler> logger, IIdentity identity, IUserRepository userRepo, IUserSettingRepository userSettingRepo) : IRequestHandler<ValidateJwtTokenCommand, ErrorOr<User>>
    {
        public async Task<ErrorOr<User>> Handle(ValidateJwtTokenCommand command, CancellationToken cancellationToken)
        {
            uint userId = identity.GetNameId(command.Token).ToUIntOrDefault();
            User? user = await userRepo.GetByIdAsync(userId, cancellationToken);
            if (user is null)
                return Error.NotFound(code : ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), description:"User not found");
            UserSetting? setting = await userSettingRepo.GetByIdAsync(user.Id, cancellationToken);
            if(setting is null)
                return Error.NotFound(code : ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), description:"User setting not found");
            var isValid = identity.ValidateJwtTokenWithSymmetricKey(command.Token, setting.AppSecret, command.Payload.Minify());
            return isValid;
        }
    }
}