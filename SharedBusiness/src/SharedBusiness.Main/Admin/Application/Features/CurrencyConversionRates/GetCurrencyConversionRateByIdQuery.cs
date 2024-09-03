using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.CurrencyConversionRates
{
    public record GetCurrencyConversionRateByIdQuery(uint id) : IRequest<ErrorOr<CurrencyConversionRate>>;

    public class GetCurrencyConversionRateByIdQueryValidator : AbstractValidator<GetCurrencyConversionRateByIdQuery>
    {
        public GetCurrencyConversionRateByIdQueryValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("CurrencyConversionRate ID is required");
        }
    }

    public class GetCurrencyConversionRateByIdQueryHandler : CurrencyConversionRateBase, IRequestHandler<GetCurrencyConversionRateByIdQuery, ErrorOr<CurrencyConversionRate>>
    {
        private readonly ICurrencyConversionRateRepository _repository;

        public GetCurrencyConversionRateByIdQueryHandler(ICurrencyConversionRateRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<CurrencyConversionRate>> Handle(GetCurrencyConversionRateByIdQuery request, CancellationToken cancellationToken)
        {
            var currencyConversionRate = await _repository.GetByIdAsync(request.id, cancellationToken);

            if (currencyConversionRate == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }

            return currencyConversionRate;
        }
    }
}
