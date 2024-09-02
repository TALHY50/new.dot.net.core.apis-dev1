using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.CreateCurrencyConversionRates;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Presentation;

namespace Admin.App.Presentation.Endpoints.CreateCurrencyConversionRates;

public class CreateCurrencyConversionRateController : ApiControllerBase
{
    [Tags("CurrencyConversionRate")]
    // [Authorize(Policy = "HasPermission")]
    [HttpPost(SharedKernel.Main.Presentation.Routes.Routes.CreateCurrencyConversionRateUrl, Name = SharedKernel.Main.Presentation.Routes.Routes.CreateCurrencyConversionRateName)]

    public async Task<ActionResult<ErrorOr<CurrencyConversionRate>>> Create(CreateCurrencyConversionRateCommand command)
    {
        var result = await Mediator.Send(command).ConfigureAwait(false);

        return result.Match(
            reminder => Ok(result.Value),
            Problem);
    }
}