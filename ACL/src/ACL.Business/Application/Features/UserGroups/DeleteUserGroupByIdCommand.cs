using ACL.Business.Application.Interfaces.Repositories;
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedKernel.Main.Contracts;

namespace ACL.Business.Application.Features.UserGroups
{
    //[Authorize]
    public record DeleteUserGroupByIdCommand(uint id) : IRequest<ErrorOr<bool>>;

    public class DeleteUserGroupByIdCommandValidator : AbstractValidator<DeleteUserGroupByIdCommand>
    {
        public DeleteUserGroupByIdCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }


    public class DeleteUserGroupByIdCommandHandler : UserGroupBase, IRequestHandler<DeleteUserGroupByIdCommand, ErrorOr<bool>>
    {
        private readonly IUserGroupRepository _repository;

        public DeleteUserGroupByIdCommandHandler(IUserGroupRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteUserGroupByIdCommand command, CancellationToken cancellationToken)
        {
            if (command.id > 0)
            {
                var userGroup = await _repository.GetByIdAsync(command.id);

                if (userGroup == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
                }

                await _repository.DeleteAsync(userGroup, cancellationToken);

            }

            return true;
        }
    }
}
