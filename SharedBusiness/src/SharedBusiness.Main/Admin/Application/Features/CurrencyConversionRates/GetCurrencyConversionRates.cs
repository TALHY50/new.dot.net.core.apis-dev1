using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Admin.Weblication.Features.Countries;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedBusiness.Main.Admin.Weblication.Features.CurrencyConversionRates
{
    public record GetCurrencyConversionRateQuery(int PageNumber = 0, int PageSize = 0) : IRequest<ErrorOr<List<CurrencyConversionRate>>>;

    public class GetCurrencyConversionRateQueryValidator : AbstractValidator<GetCurrencyConversionRateQuery>
    {
        public GetCurrencyConversionRateQueryValidator()
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

    public class GetCurrencyConversionRateQueryHandler
        : CurrencyConversionRateBase, IRequestHandler<GetCurrencyConversionRateQuery, ErrorOr<List<CurrencyConversionRate>>>
    {
        private readonly ICurrencyConversionRateRepository _repository;

        public GetCurrencyConversionRateQueryHandler(ICurrencyConversionRateRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<List<CurrencyConversionRate>>> Handle(GetCurrencyConversionRateQuery request, CancellationToken cancellationToken)
        {
            List<CurrencyConversionRate>? currencyConversionRates;

            if (request.PageNumber > 0 && request.PageSize > 0)
            {
                currencyConversionRates = await _repository.ListPaginatedAsync(request.PageNumber, request.PageSize, cancellationToken);

            }
            else
            {
                currencyConversionRates = await _repository.ListAsync(cancellationToken);

            }

            if (currencyConversionRates == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), description: "CurrencyConversionRate not found!");
            }

            return currencyConversionRates;
        }
    }
}
