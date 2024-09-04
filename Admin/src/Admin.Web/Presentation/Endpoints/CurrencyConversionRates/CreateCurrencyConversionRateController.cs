using Admin.Web.Presentation.Routes;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.CurrencyConversionRates;
using SharedBusiness.Main.Common.Contracts;
using SharedBusiness.Main.Common.Domain.Entities;

using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.CurrencyConversionRates;

public class CreateCurrencyConversionRateController(ILogger<CreateCurrencyConversionRateController> logger, ICurrentUser currentUser)
    : CurrencyConversionRateBase(logger, currentUser)
{
    [Tags("CurrencyConversionRates")]
    // [Authorize(Policy = "HasPermission")]
    [HttpPost(CurrencyConversionRateRoutes.CreateCurrencyConversionRateTemplate, Name = CurrencyConversionRateRoutes.CreateCurrencyConversionRateName)]

    public async Task<IActionResult> Create(CreateCurrencyConversionRateCommand command, CancellationToken cancellationToken)
    {
        _ = Task.Run(
            () => _logger.LogInformation(
                "create-currency-conversion-rate-request: {Name} {@UserId} {@Request}",
                nameof(CreateCurrencyConversionRateCommand),
                CurrentUser.UserId,
                command),
            cancellationToken);
        var result = await Mediator.Send(command).ConfigureAwait(false);
        var response = result.Match(
            currencyConversionRate => Ok(ToSuccess(Mapper.Map<CurrencyConversionRateDto>(currencyConversionRate))),
            Problem);
        _ = Task.Run(
            () => _logger.LogInformation(
                "create-currency-conversion-rate-response: {Name} {@UserId} {@Response}",
                nameof(response),
                CurrentUser.UserId,
                response),
            cancellationToken);
        return response;
    }
}