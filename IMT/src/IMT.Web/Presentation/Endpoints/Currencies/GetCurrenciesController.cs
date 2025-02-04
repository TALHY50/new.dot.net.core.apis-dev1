﻿using IMT.App.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;
using SharedBusiness.Main.Common.Contracts;
using SharedBusiness.Main.Common.Application.Features.Currencies;
using Mapster;

namespace IMT.App.Presentation.Endpoints.Currencies
{
    public class GetCurrenciesController(ILogger<GetCurrenciesController> logger, ICurrentUser currentUser)
    : CurrencyBase(logger, currentUser)
    {
        [Tags("Currencies")]
        // [Authorize(Policy = "HasPermission")]
        [HttpGet(CurrencyRoutes.GetCurrencyTemplate, Name = CurrencyRoutes.GetCurrencyName)]
        public async Task<IActionResult> Get([FromQuery] PaginatorRequest pageRequest, CancellationToken cancellationToken)
        {
            var query = new GetCurrenciesQuery(PageNumber: pageRequest.page_number, PageSize: pageRequest.page_size);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-Currencies: {Name} {@UserId} {@Request}",
                    nameof(GetCurrenciesController),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                Currencies => Ok(ToSuccess(Currencies.Select(currency => currency.Adapt<CurrencyDto>()).ToList())),
                Problem
            );
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-Currencies-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
