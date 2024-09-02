using Admin.App.Application.Features.CurrencyConversionRates;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.CreateCurrencyConversionRates;
using SharedKernel.Main.Presentation;

namespace Admin.App.Presentation.Endpoints.CreateCurrencyConversionRates;

public class DeleteCurrencyConversionRateController : ApiControllerBase
{
    [Tags("CurrencyConversionRate")]
    //[Authorize(Policy = "HasPermission")]
    [HttpDelete(SharedKernel.Main.Presentation.Routes.Routes.DeleteCurrencyConversionRateUrl, Name = SharedKernel.Main.Presentation.Routes.Routes.DeleteCurrencyConversionRateName)]

    public async Task<ActionResult<ErrorOr<bool>>> Delete(uint Id)
    {
        var result = await Mediator.Send(new DeleteCurrencyConversionRateCommand(Id)).ConfigureAwait(false);

        return result.Match(
            reminder => Ok(result.Value),
            Problem);
    }
}