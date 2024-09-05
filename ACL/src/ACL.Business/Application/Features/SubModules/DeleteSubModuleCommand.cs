
using ACL.Business.Application.Interfaces.Repositories;
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedKernel.Main.Contracts;


namespace ACL.Business.Application.Features.SubModules
{

    public record DeleteSubModuleCommand(uint id) : IRequest<ErrorOr<bool>>;

    public class DeleteSubModuleCommandValidator : AbstractValidator<DeleteSubModuleCommand>
    {
        public DeleteSubModuleCommandValidator()
        {
            RuleFor(r => r.id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }

    public class DeleteSubModuleCommandHandler : SubModuleBase, IRequestHandler<DeleteSubModuleCommand, ErrorOr<bool>>
    {
        private readonly ISubModuleRepository _repository;

        public DeleteSubModuleCommandHandler(ISubModuleRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteSubModuleCommand command, CancellationToken cancellationToken)
        {
            if (command.id > 0)
            {
                var country = await _repository.GetByIdAsync(command.id);

                if (country == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(),Language.GetMessage("SubModule not found"));
                }

                await _repository.DeleteAsync(country, cancellationToken);

            }

            return true;
        }
    }


}
