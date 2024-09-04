
using ACL.Business.Application.Interfaces.Repositories;
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedKernel.Main.Contracts;

namespace ACL.Business.Application.Features.Roles
{
    public record DeleteRoleByIdCommand(uint id) : IRequest<ErrorOr<bool>>;

    public class DeleteRoleByIdCommandValidator : AbstractValidator<DeleteRoleByIdCommand>
    {
        public DeleteRoleByIdCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }

    public class DeleteRoleByIdCommandHandler : RoleBase, IRequestHandler<DeleteRoleByIdCommand, ErrorOr<bool>>
    {
        private readonly IRoleRepository _repository;
        private readonly IUserRepository _userRepository;

        public DeleteRoleByIdCommandHandler(IRoleRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteRoleByIdCommand command, CancellationToken cancellationToken)
        {
            var role = await _repository.GetByIdAsync(command.id);

            if (role == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }
            if(role != null && !_repository.RoleIdNotToDelete(command.id))
            {
                await _repository.DeleteAsync(role, cancellationToken);
                List<uint>? userIds = _userRepository.GetUserIdByChangePermission(null, null, null, command.id);
                _userRepository.UpdateUserPermissionVersion(userIds);
                return true;
            }

            return false;
        }
    }
}
