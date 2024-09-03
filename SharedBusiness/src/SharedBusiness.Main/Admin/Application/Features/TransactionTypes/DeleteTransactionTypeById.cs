using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Admin.Weblication.Features.Countries;
using SharedBusiness.Main.Common.Application.Features.TransactionTypes;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedKernel.Main.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedBusiness.Main.Admin.Weblication.Features.TransactionTypes
{
    public record DeleteTransactionTypeByIdCommand(uint id) : IRequest<ErrorOr<bool>>;
    public class DeleteTransactionTypeByIdCommandValidator : AbstractValidator<DeleteTransactionTypeByIdCommand>
    {
        public DeleteTransactionTypeByIdCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }

    public class DeleteTransactionTypeByIdCommandHandler : TransactionTypeBase, IRequestHandler<DeleteTransactionTypeByIdCommand, ErrorOr<bool>>
    {
        private readonly ITransactionTypeRepository _repository;

        public DeleteTransactionTypeByIdCommandHandler(ITransactionTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteTransactionTypeByIdCommand command, CancellationToken cancellationToken)
        {
            if (command.id > 0)
            {
                var transactionType = await _repository.GetByIdAsync(command.id);

                if (transactionType == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), "TransactionType not found");
                }

                await _repository.DeleteAsync(transactionType, cancellationToken);

            }

            return true;
        }
    }
}
