using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.TaxRates;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.TaxRates
{
    public class DeleteTaxRateByIdController(ILogger<DeleteTaxRateByIdController> logger, ICurrentUser currentUser)
        : TaxRateBase(logger, currentUser)
    {
        [Tags("TaxRates")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(TaxRateRoutes.DeleteTaxRateTemplate, Name = TaxRateRoutes.DeleteTaxRateName)]

        public async Task<IActionResult> Delete(uint id, CancellationToken cancellationToken)
        {
            var command = new DeleteTaxRateByIdCommand(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-tax-rate-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(DeleteTaxRateByIdCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                isSuccess => Ok(ToSuccess(result.Value)),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-tax-rate-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
