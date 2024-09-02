
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Common.Application.Features.Currencies
{
    public record GetCurrenciesQuery(int PageNumber = 0, int PageSize = 0) : IRequest<ErrorOr<List<Currency>>>;

    public class GetCurrenciesQueryValidator : AbstractValidator<GetCurrenciesQuery>
    {
        public GetCurrenciesQueryValidator()
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

    public class GetCurrenciesQueryHandler
        : CurrencyBase, IRequestHandler<GetCurrenciesQuery, ErrorOr<List<Currency>>>
    {
        private readonly ICurrencyRepository _repository;

        public GetCurrenciesQueryHandler(ICurrencyRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<List<Currency>>> Handle(GetCurrenciesQuery request, CancellationToken cancellationToken)
        {
            List<Currency>? Currencies;

            if (request.PageNumber > 0 && request.PageSize > 0)
            {
                Currencies = await _repository.ListPaginatedAsync(request.PageNumber, request.PageSize, cancellationToken);

            }
            else
            {
                Currencies = await _repository.ListAsync(cancellationToken);

            }

            if (Currencies == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), description: "Currency not found!");
            }

            return Currencies;
        }
    }

}
