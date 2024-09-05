
using ACL.Business.Application.Interfaces.Repositories;
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedKernel.Main.Contracts;


namespace ACL.Business.Application.Features.Modules
{

    public record DeleteModuleCommand(uint id) : IRequest<ErrorOr<bool>>;

    public class DeleteModuleCommandValidator : AbstractValidator<DeleteModuleCommand>
    {
        public DeleteModuleCommandValidator()
        {
            RuleFor(r => r.id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }

    public class DeleteModuleCommandHandler : IRequestHandler<DeleteModuleCommand, ErrorOr<bool>>
    {
        private readonly IModuleRepository _repository;

        public DeleteModuleCommandHandler(IModuleRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteModuleCommand command, CancellationToken cancellationToken)
        {
            if (command.id > 0)
            {
                var country = await _repository.GetByIdAsync(command.id);

                if (country == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(),Language.GetMessage("Module not found"));
                }

                await _repository.DeleteAsync(country, cancellationToken);

            }

            return true;
        }
    }


}
