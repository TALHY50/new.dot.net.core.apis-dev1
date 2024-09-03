using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Application.Interfaces.Services;
using ACL.Business.Domain.Entities;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedKernel.Main.Contracts;

namespace ACL.Business.Application.Features.Auth
{
    public abstract record CreateJwtTokenCommand(
        uint userId
    ) : IRequest<ErrorOr<string>>;

    public class CreateJwtTokenCommandValidator : AbstractValidator<CreateJwtTokenCommand>
    {
        public CreateJwtTokenCommandValidator()
        {
        }
    }

    public class CreateJwtTokenCommandHandler(ILogger<CreateJwtTokenCommandHandler> logger, IIdentity identity, IUserRepository userRepo, IUserSettingRepository userSettingRepo) : IRequestHandler<CreateJwtTokenCommand, ErrorOr<string>>
    {
        public async Task<ErrorOr<string>> Handle(CreateJwtTokenCommand command, CancellationToken cancellationToken)
        {
            User? user = userRepo.FindByIdAsync(command.userId);
            if (user is null)
                return Error.NotFound(code : ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), description:"User not found");
            UserSetting? setting = await userSettingRepo.GetByIdAsync(user.Id, cancellationToken);
            if(setting is null)
                return Error.NotFound(code : ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), description:"User setting not found");
            

            
            return "GeneratedToken"; // Placeholder for the generated token
        }
    }
}