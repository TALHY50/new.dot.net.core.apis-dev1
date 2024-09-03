using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.Providers
{
    public record DeleteProviderByIdCommand(uint id) : IRequest<ErrorOr<bool>>;

    public class DeleteProviderByIdCommandValidator : AbstractValidator<DeleteProviderByIdCommand>
    {
        public DeleteProviderByIdCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }

    public class DeleteProviderByIdCommandHandler : ProviderBaseCommand, IRequestHandler<DeleteProviderByIdCommand, ErrorOr<bool>>
    {
        private readonly IProviderRepository _repository;

        public DeleteProviderByIdCommandHandler(IProviderRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteProviderByIdCommand command, CancellationToken cancellationToken)
        {
            if (command.id > 0)
            {
                var provider = await _repository.GetByIdAsync(command.id);

                if (provider == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Provider not found"));
                }

                await _repository.DeleteAsync(provider, cancellationToken);

            }

            return true;
        }
    }
}
