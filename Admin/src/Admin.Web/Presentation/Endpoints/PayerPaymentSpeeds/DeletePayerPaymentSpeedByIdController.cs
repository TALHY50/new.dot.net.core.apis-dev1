using Admin.App.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.PayerPaymentSpeeds;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.App.Presentation.Endpoints.PayerPaymentSpeeds
{
    public class DeletePayerPaymentSpeedByIdController(ILogger<DeletePayerPaymentSpeedByIdController> logger, ICurrentUser currentUser)
        : PayerPaymentSpeedBase(logger, currentUser)
    {
        [Tags("PayerPaymentSpeeds")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(PayerPaymentSpeedRoutes.DeletePayerPaymentSpeedTemplate, Name = PayerPaymentSpeedRoutes.DeletePayerPaymentSpeedName)]

        public async Task<IActionResult> Delete(uint id, CancellationToken cancellationToken)
        {
            var command = new DeletePayerPaymentSpeedCommand(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-payer-payment-speed-request: {Name} {@UserId} {@Request}",
                    nameof(DeletePayerPaymentSpeedCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                isSuccess => Ok(ToSuccess(result.Value)),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-payer-payment-speed-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
