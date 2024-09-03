using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Currencies;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.Currencies
{
    public class DeleteCurrencyByIdController(ILogger<DeleteCurrencyByIdController> logger, ICurrentUser currentUser)
    : CurrencyBaseController(logger, currentUser)
    {
        [Tags("Currencies")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(CurrencyRoutes.DeleteCurrencyTemplate, Name = CurrencyRoutes.DeleteCurrencyName)]

        public async Task<IActionResult> Delete(uint id, CancellationToken cancellationToken)
        {
            var command = new DeleteCurrencyByIdCommand(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-currency-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(DeleteCurrencyByIdCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                isSuccess => Ok(ToSuccess(result.Value)),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-currency-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
