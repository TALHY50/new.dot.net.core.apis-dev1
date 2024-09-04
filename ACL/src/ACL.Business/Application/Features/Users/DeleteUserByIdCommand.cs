using ACL.Business.Application.Interfaces.Repositories;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Contracts;

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
    public class DeleteUserByIdCommandHandler :  IRequestHandler<DeleteUserByIdCommand, ErrorOr<bool>>
    {
        private readonly IUserRepository _repository;

        public DeleteUserByIdCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteUserByIdCommand command, CancellationToken cancellationToken)
        {
            if (command.id > 0)
            {
                var entity = await _repository.GetByIdAsync(command.id);

                if (entity == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), "Mtt not found");
                }

                await _repository.DeleteAsync(entity, cancellationToken);

            }

            return true;
        }
    }
}
