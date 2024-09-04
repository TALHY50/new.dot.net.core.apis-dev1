using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Contracts;
using System.ComponentModel.Design;

namespace ACL.Business.Application.Features.Users
{
    [Authorize]
    public record DeleteUserByIdCommand(uint id) : IRequest<ErrorOr<bool>>;

    public class DeleteUserByIdCommandValidator : AbstractValidator<DeleteUserByIdCommand>
    {
        public DeleteUserByIdCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public class DeleteUserByIdCommandHandler : UserBase, IRequestHandler<DeleteUserByIdCommand, ErrorOr<bool>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserUserGroupRepository _userUserGroupRepository;

        public DeleteUserByIdCommandHandler(IUserRepository userRepository,IUserUserGroupRepository userUserGroupRepository)
        {
            _userRepository = userRepository;
            _userUserGroupRepository = userUserGroupRepository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteUserByIdCommand command, CancellationToken cancellationToken)
        {
             User? aclUser = _userRepository.Find(command.id);
            if (aclUser != null)
            {
                _userRepository.Delete(aclUser);
                // delete all item for user user group
                UserUsergroup[]? userUserGroups = _userUserGroupRepository?.Where(command.id)?.ToArray();
                if (userUserGroups?.Count() > 0)
                {
                    _userUserGroupRepository?.RemoveRange(userUserGroups);
                }
                aclUser.Status = 0;
                _userRepository.Update(aclUser);
                return true;
            }
            else
            {
                 return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), "User not found");
            }

        }
    }
}
