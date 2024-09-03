using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;


namespace SharedBusiness.Main.Admin.Weblication.Features.TransactionLimits
{
    public record GetTransactionLimitQuery(int PageNumber = 0, int PageSize = 0) : IRequest<ErrorOr<List<TransactionLimit>>>;

    public class GetCountriesQueryValidator : AbstractValidator<GetTransactionLimitQuery>
    {
        public GetCountriesQueryValidator()
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


    public class GetTransactionLimitHandler
       :  IRequestHandler<GetTransactionLimitQuery, ErrorOr<List<TransactionLimit>>>
    {
        private readonly ITransactionLimitRepository _repository;

        public GetTransactionLimitHandler(ITransactionLimitRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<List<TransactionLimit>>> Handle(GetTransactionLimitQuery request, CancellationToken cancellationToken)
        {
            List<TransactionLimit>? transactionLimits;

            if (request.PageNumber > 0 && request.PageSize > 0)
            {
                transactionLimits = await _repository.ListPaginatedAsync(request.PageNumber, request.PageSize, cancellationToken);

            }
            else
            {
                transactionLimits = await _repository.ListAsync(cancellationToken);

            }

            if (transactionLimits == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), description: "Transaction Limit not found!");
            }

            return transactionLimits;
        }
    }

}
