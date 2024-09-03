using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Features.Banks;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.Banks
{
    public record DeleteBankByIdCommand(uint id) : IRequest<ErrorOr<bool>>;
    public class DeleteBankByIdCommandValidator : AbstractValidator<DeleteBankByIdCommand>
    {
        public DeleteBankByIdCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }

    public class DeleteBankByIdCommandHandler : BankBase, IRequestHandler<DeleteBankByIdCommand, ErrorOr<bool>>
    {
        private readonly IBankRepository _repository;

        public DeleteBankByIdCommandHandler(IBankRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteBankByIdCommand command, CancellationToken cancellationToken)
        {
            if (command.id > 0)
            {
                var bank = await _repository.GetByIdAsync(command.id);

                if (bank == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
                }

                await _repository.DeleteAsync(bank, cancellationToken);

            }

            return true;
        }
    }
}
