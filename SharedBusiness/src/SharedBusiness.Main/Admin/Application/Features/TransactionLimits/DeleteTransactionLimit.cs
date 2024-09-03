
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedKernel.Main.Contracts;


namespace SharedBusiness.Main.Admin.Application.Features.TransactionLimits
{

    public record DeleteTransactionLimitCommand(uint id) : IRequest<ErrorOr<bool>>;

    public class DeleteTransactionLimitCommandValidator : AbstractValidator<DeleteTransactionLimitCommand>
    {
        public DeleteTransactionLimitCommandValidator()
        {
            RuleFor(r => r.id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }

    public class DeleteTransactionLimitCommandHandler : IRequestHandler<DeleteTransactionLimitCommand, ErrorOr<bool>>
    {
        private readonly ITransactionLimitRepository _repository;

        public DeleteTransactionLimitCommandHandler(ITransactionLimitRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteTransactionLimitCommand command, CancellationToken cancellationToken)
        {
            if (command.id > 0)
            {
                var country = await _repository.GetByIdAsync(command.id);

                if (country == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(),Language.GetMessage("Transaction limit not found"));
                }

                await _repository.DeleteAsync(country, cancellationToken);

            }

            return true;
        }
    }


}
