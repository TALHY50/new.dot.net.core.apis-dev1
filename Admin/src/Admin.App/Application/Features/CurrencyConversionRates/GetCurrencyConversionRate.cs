using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;

namespace Admin.App.Application.Features.CurrencyConversionRates
{
    public class GetCurrencyConversionRateController : ApiControllerBase
    {
        [Tags("CurrencyConversionRate")]
        // [Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetCurrencyConversionRateUrl, Name = Routes.GetCurrencyConversionRateName)]
        public async Task<ActionResult<ErrorOr<List<CurrencyConversionRate>>>> Get()
        {
            var result = await Mediator.Send(new GetCurrencyConversionRateQuery()).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }

        public record GetCurrencyConversionRateQuery() : IRequest<ErrorOr<List<CurrencyConversionRate>>>;

        public class GetCurrencyConversionRateQueryHandler
            : IRequestHandler<GetCurrencyConversionRateQuery, ErrorOr<List<CurrencyConversionRate>>>
        {
            private readonly IImtCurrencyConversionRateRepository _repository;

            public GetCurrencyConversionRateQueryHandler(IImtCurrencyConversionRateRepository repository)
            {
                _repository = repository;
            }

            public async Task<ErrorOr<List<CurrencyConversionRate>>> Handle(GetCurrencyConversionRateQuery request, CancellationToken cancellationToken)
            {
                var currencyConversionRates = _repository.ViewAll();

                return currencyConversionRates;
            }
        }
    }
}
