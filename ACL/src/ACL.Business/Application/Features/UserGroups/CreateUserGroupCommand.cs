using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Domain.Entities;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using SharedKernel.Main.Contracts;
using System.ComponentModel.Design;
using System.Security.Principal;

namespace ACL.Business.Application.Features.UserGroups
{
    [Authorize]
    public class CreateUserGroupCommand(
        string group_name,
        sbyte category,
        sbyte status
    ) : IRequest<ErrorOr<string>>;

    public class CreateUserGroupCommandValidator : AbstractValidator<CreateUserGroupCommand>
    {
        public CreateUserGroupCommandValidator()
        {
        }
    }

    public class CreateUserGroupCommandHandler(ILogger<CreateUserGroupCommandHandler> logger, IIdentity identity, IUserRepository userRepo, IUserSettingRepository userSettingRepo) : IRequestHandler<CreateUserGroupCommand, ErrorOr<string>>
    {
        public async Task<ErrorOr<string>> Handle(CreateUserGroupCommand command, CancellationToken cancellationToken)
        {
            Usergroup? result = PrepareInputData(command id);
            Usergroup? user = await userRepo.GetByIdAsync(command.UserId, cancellationToken);
            if (user is null)
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), description: "User not found");
            UserSetting? setting = await userSettingRepo.GetByIdAsync(user.Id, cancellationToken);
            if (setting is null)
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), description: "User setting not found");
            string token = identity.GenerateJwtTokenWithSymmetricKey(command.UserId.ToString(), setting.AppId, setting.AppSecret, command.Payload.ToString(), 3000);
            return token;
        }

        public Usergroup PrepareInputData(AclUserGroupRequest request, Usergroup? aclUserGroup = null)
        {
            Usergroup? aclInstance = aclUserGroup ?? new Usergroup();

            aclInstance.Status = request.Status;
            aclInstance.GroupName = request.GroupName;

            if (CompanyId == 0)
            {
                aclInstance.CompanyId = AppAuth.GetAuthInfo().CompanyId;
            }
            else
            {
                aclInstance.CompanyId = CompanyId;
            }
            if (aclUserGroup == null)
            {
                aclInstance.CreatedAt = DateTime.Now;
            }
            aclInstance.UpdatedAt = DateTime.Now;

            return aclInstance;
        }
    }
}
