﻿using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.Admin.Application.Features.CurrencyConversionRates;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.CurrencyConversionRates
{
    public class GetCurrencyConversionRateByIdController(ILogger<GetCurrencyConversionRateByIdController> logger, ICurrentUser currentUser)
        : CurrencyConversionRateBase(logger, currentUser)
    {
        [Tags("CurrencyConversionRates")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(CurrencyConversionRateRoutes.GetCurrencyConversionRateByIdTemplate, Name = CurrencyConversionRateRoutes.GetCurrencyConversionRateByIdName)]
        public async Task<IActionResult> GetById(uint id, CancellationToken cancellationToken)
        {
            var query = new GetCurrencyConversionRateByIdQuery(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-currency-conversion-rate-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(GetCurrencyConversionRateByIdQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);

            var result = await Mediator.Send(query).ConfigureAwait(false);

            var response = result.Match(
                currencyConversionRate => Ok(ToSuccess(Mapper.Map<CurrencyConversionRateDto>(currencyConversionRate))),
                Problem);

            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-currency-conversion-rate-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);

            return response;
        }
    }
}
