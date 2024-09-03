using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Admin.Weblication.Features.Countries;
using SharedBusiness.Main.Common.Application.Features.TransactionTypes;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Enums;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Application.Rules;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Weblication.Features.TransactionTypes
{
    public record UpdateTransactionTypeByIdCommand(
        uint id,
        string name,
        byte? status) : IRequest<ErrorOr<TransactionType>>;

    public class UpdateTransactionTypeByIdCommandValidator : AbstractValidator<UpdateTransactionTypeByIdCommand>
    {
        public UpdateTransactionTypeByIdCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("TransactionType ID is required");
            RuleFor(v => v.name).MaximumLength(50).TransactionTypeName();
        }
    }

    public class UpdateTransactionTypeByIdCommandHandler : TransactionTypeBase, IRequestHandler<UpdateTransactionTypeByIdCommand, ErrorOr<TransactionType>>
    {
        private readonly ITransactionTypeRepository _repository;
        private readonly IGuardAgainstNullUpdate _guard;

        public UpdateTransactionTypeByIdCommandHandler(ITransactionTypeRepository repository, IGuardAgainstNullUpdate guard)
        {
            _repository = repository;
            _guard = guard;
        }

        public async Task<ErrorOr<TransactionType>> Handle(UpdateTransactionTypeByIdCommand command, CancellationToken cancellationToken)
        {
            TransactionType? transactionType = await _repository.GetByIdAsync(command.id, cancellationToken);
            if (transactionType == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }


            // Update properties conditionally using the helper function
            _guard.UpdateIfNotNullOrEmpty(value => transactionType.Name = value, command.name);
            _guard.UpdateIfNotNullOrEmpty(value => transactionType.Status = value, command.status);

            transactionType.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(transactionType, cancellationToken);

            return transactionType;


        }

    }
}
