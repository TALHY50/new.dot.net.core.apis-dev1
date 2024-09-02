using Admin.App.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.CreateCurrencyConversionRates;
using SharedKernel.Main.Presentation;

namespace Admin.App.Presentation.Endpoints.CreateCurrencyConversionRates;

public class DeleteCurrencyConversionRate : ApiControllerBase
{
    [Tags("CurrencyConversionRates")]
    //[Authorize(Policy = "HasPermission")]
    [HttpDelete(CurrencyConversionRateRoutes.DeleteCurrencyConversionRateTemplate, Name = CurrencyConversionRateRoutes.DeleteCurrencyConversionRateName)]

    public async Task<IActionResult> Delete(uint id, CancellationToken cancellationToken)
    {
        var command = new DeleteCurrencyConversionRateCommand(id);
        _ = Task.Run(
            () => _logger.LogInformation(
                "delete-currency-conversion-rate-request: {Name} {@UserId} {@Request}",
                nameof(DeleteCurrencyConversionRateCommand),
                CurrentUser.UserId,
                command),
            cancellationToken);
        var result = await Mediator.Send(command).ConfigureAwait(false);
        var response = result.Match(
            isSuccess => Ok(ToSuccess(result.Value)),
            Problem);
        _ = Task.Run(
            () => _logger.LogInformation(
                "delete-currency-conversion-rate-response: {Name} {@UserId} {@Response}",
                nameof(response),
                CurrentUser.UserId,
                response),
            cancellationToken);
        return response;
    }
}