﻿using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.CurrencyConversionRates;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.CurrencyConversionRates
{
    public class UpdateCurrencyConversionRateByIdController : CurrencyConversionRateBase
    {
        public UpdateCurrencyConversionRateByIdController(ILogger<UpdateCurrencyConversionRateByIdController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }

        [Tags("CurrencyConversionRates")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(CurrencyConversionRateRoutes.UpdateCurrencyConversionRateTemplate, Name = CurrencyConversionRateRoutes.UpdateCurrencyConversionRateName)]
        [HttpPatch(CurrencyConversionRateRoutes.UpdateCurrencyConversionRateTemplate, Name = CurrencyConversionRateRoutes.UpdateCurrencyConversionRateName)]

        public async Task<IActionResult> Update(uint id, UpdateCurrencyConversionRateByIdCommand command, CancellationToken cancellationToken)
        {
            var commandWithId = command with { id = id };
            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-currency-conversion-rate-request: {Name} {@UserId} {@Request}",
                    nameof(commandWithId),
                    CurrentUser.UserId,
                    commandWithId),
                cancellationToken);
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
            var response = result.Match(
                currencyConversionRates => Ok(ToSuccess(Mapper.Map<CurrencyConversionRateDto>(currencyConversionRates))),
                Problem);

            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-currency-conversion-rate-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
