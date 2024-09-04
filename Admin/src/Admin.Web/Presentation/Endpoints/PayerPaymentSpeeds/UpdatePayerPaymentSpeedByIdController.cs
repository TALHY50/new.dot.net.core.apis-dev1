using Admin.Web.Presentation.Endpoints.PayerPaymentSpeeds;
using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.PayerPaymentSpeeds;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.PayerPaymentSpeeds
{
    public class UpdatePayerPaymentSpeedByIdController : PayerPaymentSpeedBase
    {
        public UpdatePayerPaymentSpeedByIdController(ILogger<PayerPaymentSpeedBase> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }

        [Tags("PayerPaymentSpeeds")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(PayerPaymentSpeedRoutes.UpdatePayerPaymentSpeedTemplate, Name = PayerPaymentSpeedRoutes.UpdatePayerPaymentSpeedName)]
        [HttpPatch(PayerPaymentSpeedRoutes.UpdatePayerPaymentSpeedTemplate, Name = PayerPaymentSpeedRoutes.UpdatePayerPaymentSpeedName)]

        public async Task<IActionResult> Update(uint id, UpdatePayerPaymentSpeedCommand command, CancellationToken cancellationToken)
        {
            var commandWithId = command with { id = id };
            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-payer-payment-speed-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(commandWithId),
                    CurrentUser.UserId,
                    commandWithId),
                cancellationToken);
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
            var response = result.Match(
                payerPaymentSpeed => Ok(ToSuccess(Mapper.Map<PayerPaymentSpeedDto>(payerPaymentSpeed))),
                Problem);

            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-payer-payment-speed-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }

    }
}
