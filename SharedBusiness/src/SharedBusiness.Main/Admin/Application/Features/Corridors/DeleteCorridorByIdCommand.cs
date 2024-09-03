using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Features.Currencies;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.Corridors
{
    public record DeleteCorridorByIdCommand(uint id) : IRequest<ErrorOr<bool>>;

    public class DeleteCorridorByIdCommandValidator : AbstractValidator<DeleteCorridorByIdCommand>
    {
        public DeleteCorridorByIdCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }

    public class DeleteCorridorByIdCommandHandler : CorridorBase, IRequestHandler<DeleteCorridorByIdCommand, ErrorOr<bool>>
    {
        private readonly ICorridorRepository _repository;

        public DeleteCorridorByIdCommandHandler(ICorridorRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteCorridorByIdCommand command, CancellationToken cancellationToken)
        {
            if (command.id > 0)
            {
                var corridor = await _repository.GetByIdAsync(command.id);

                if (corridor == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), "corridor not found");
                }

                await _repository.DeleteAsync(corridor, cancellationToken);

            }

            return true;
        }
    }
}
