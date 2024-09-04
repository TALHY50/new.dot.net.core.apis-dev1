using ACL.Business.Application.Features.Users;
using ACL.Business.Application.Interfaces.Repositories;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Contracts;

namespace ACL.Business.Application.Features.UserSettings
{
    [Authorize]
    public record DeleteUserSettingByIdCommand(ulong id) : IRequest<ErrorOr<bool>>;

    public class DeleteUserSettingByIdCommandValidator : AbstractValidator<DeleteUserSettingByIdCommand>
    {
        public DeleteUserSettingByIdCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public class DeleteMttByIdCommandHandler : IRequestHandler<DeleteUserSettingByIdCommand, ErrorOr<bool>>
    {
        private readonly IUserSettingRepository _repository;

        public DeleteMttByIdCommandHandler(IUserSettingRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteUserSettingByIdCommand command, CancellationToken cancellationToken)
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
