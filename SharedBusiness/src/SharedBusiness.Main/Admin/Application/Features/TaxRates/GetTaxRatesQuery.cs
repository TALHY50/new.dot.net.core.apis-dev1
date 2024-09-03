using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.TaxRates
{
    public record GetTaxRatesQuery(int PageNumber = 0, int PageSize = 0) : IRequest<ErrorOr<List<TaxRate>>>;

    public class GetTaxRatesQueryValidator : AbstractValidator<GetTaxRatesQuery>
    {
        public GetTaxRatesQueryValidator()
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

    public class GetTaxRatesQueryHandler
        : TaxRateBase, IRequestHandler<GetTaxRatesQuery, ErrorOr<List<TaxRate>>>
    {
        private readonly ITaxRateRepository _repository;

        public GetTaxRatesQueryHandler(ITaxRateRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<List<TaxRate>>> Handle(GetTaxRatesQuery request, CancellationToken cancellationToken)
        {
            List<TaxRate>? taxRates;

            if (request.PageNumber > 0 && request.PageSize > 0)
            {
                taxRates = await _repository.ListPaginatedAsync(request.PageNumber, request.PageSize, cancellationToken);

            }
            else
            {
                taxRates = await _repository.ListAsync(cancellationToken);

            }

            if (taxRates == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }

            return taxRates;
        }
    }

}
