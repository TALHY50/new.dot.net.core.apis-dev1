using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Common.Application.Features.TransactionTypes
{

    public record GetTransactionTypesQuery(int PageNumber = 0, int PageSize = 0) : IRequest<ErrorOr<List<TransactionType>>>;
    public class GetTransactionTypesQueryValidator : AbstractValidator<GetTransactionTypesQuery>
    {
        public GetTransactionTypesQueryValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1)
                .When(x => x.PageNumber != 0)
                .WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1)
                .When(x => x.PageNumber > 0)
                .When(x => x.PageSize != 0)
                .WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }

    public class GetTransactionTypesQueryHandler
        : TransactionTypeBase, IRequestHandler<GetTransactionTypesQuery, ErrorOr<List<TransactionType>>>
    {
        private readonly ITransactionTypeRepository _repository;

        public GetTransactionTypesQueryHandler(ITransactionTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<List<TransactionType>>> Handle(GetTransactionTypesQuery request, CancellationToken cancellationToken)
        {
            List<TransactionType>? transactionTypes;

            if (request.PageNumber > 0 && request.PageSize > 0)
            {
                transactionTypes = await _repository.ListPaginatedAsync(request.PageNumber, request.PageSize, cancellationToken);

            }
            else
            {
                transactionTypes = await _repository.ListAsync(cancellationToken);

            }

            if (transactionTypes == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }

            return transactionTypes;
        }
    }
}
