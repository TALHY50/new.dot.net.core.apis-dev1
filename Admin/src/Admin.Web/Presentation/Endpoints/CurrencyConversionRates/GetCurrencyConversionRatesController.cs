using Admin.Web.Presentation.Routes;
using ErrorOr;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.Admin.Application.Features.CurrencyConversionRates;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Contracts.Contracts.Responses;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace Admin.Web.Presentation.Endpoints.CurrencyConversionRates
{
    public class GetCurrencyConversionRatesController(ILogger<GetCurrencyConversionRatesController> logger, ICurrentUser currentUser)
        : CurrencyConversionRateBase(logger, currentUser)
    {
        [Tags("CurrencyConversionRates")]
        // [Authorize(Policy = "HasPermission")]
        [HttpGet(CurrencyConversionRateRoutes.GetCurrencyConversionRateTemplate, Name = CurrencyConversionRateRoutes.GetCurrencyConversionRateName)]
        public async Task<IActionResult> Get([FromQuery] PaginatorRequest pageRequest, CancellationToken cancellationToken)
        {
            var query = new GetCurrencyConversionRateQuery(PageNumber: pageRequest.page_number, PageSize: pageRequest.page_size);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-currency-conversion-rates: {Name} {@UserId} {@Request}",
                    nameof(GetCurrencyConversionRateQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                currencyConversionRates => Ok(ToSuccess(currencyConversionRates.Select(currencyConversionRate => currencyConversionRate.Adapt<CurrencyConversionRateDto>()).ToList())),
                Problem
            );
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-currency-conversion-rates-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
