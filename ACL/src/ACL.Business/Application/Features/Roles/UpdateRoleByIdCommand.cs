using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Requests;
using ACL.Business.Domain.Entities;
using ACL.Business.Infrastructure.Auth.Auth;
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace ACL.Business.Application.Features.Roles
{
    public record UpdateRoleByIdCommand(
        uint id,
        string? name,
        string? title,
        sbyte status) : IRequest<ErrorOr<Role>>;

    public class UpdateRoleByIdCommandValidator : AbstractValidator<UpdateRoleByIdCommand>
    {
        public UpdateRoleByIdCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Id is required");
        }
    }

    public class UpdateRoleByIdCommandHandler : RoleBase, IRequestHandler<UpdateRoleByIdCommand, ErrorOr<Role>>
    {
        private readonly IRoleRepository _repository;
        private readonly IGuardAgainstNullUpdate _guard;
        private readonly IUserRepository _userRepository;

        public UpdateRoleByIdCommandHandler(IRoleRepository repository, 
            IGuardAgainstNullUpdate guard,
            IUserRepository userRepository)
        {
            _repository = repository;
            _guard = guard;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<Role>> Handle(UpdateRoleByIdCommand command, CancellationToken cancellationToken)
        {
            Role? role = _repository.Find(command.id);
            if (role == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }


            // Update properties conditionally using the helper function
            _guard.UpdateIfNotNullOrEmpty(value => role.Name = value, command.name);
            _guard.UpdateIfNotNullOrEmpty(value => role.Title = value, command.title);
            _guard.UpdateIfNotNullOrEmpty(value => role.Status = value, command.status);

            role = PrepareInputData(command, role);

            List<uint>? userIds = _userRepository?.GetUserIdByChangePermission(null, null, null, command.id);
            if (userIds.Count() > 0)
            {
                _userRepository.UpdateUserPermissionVersion(userIds);
            }

            await _repository.UpdateAsync(role, cancellationToken);

            return role;


        }
        private Role PrepareInputData(UpdateRoleByIdCommand request, Role? aclRole = null)
        {
            if (aclRole == null)
            {
                aclRole = new Role();
                aclRole.CreatedById = AppAuth.GetAuthInfo().UserId;
                aclRole.CreatedAt = DateTime.Now;
            }
            aclRole.Title = _repository.ExistByTitle(aclRole.Id, request.title);
            aclRole.Name = _repository.ExistByName(aclRole.Id, request.name);
            aclRole.Status = request.status;
            aclRole.CompanyId = AppAuth.GetAuthInfo().CompanyId;
            aclRole.UpdatedById = AppAuth.GetAuthInfo().UserId;
            aclRole.UpdatedAt = DateTime.Now;

            return aclRole;
        }
    }
}
