using Admin.Web.Presentation.Endpoints.PayerPaymentSpeeds;
using Admin.Web.Presentation.Routes;
using Admin.Web.Application.Features.PayerPaymentSpeeds;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.PayerPaymentSpeeds;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.PayerPaymentSpeeds
{
    public class CreatePayerPaymentSpeedController(ILogger<CreatePayerPaymentSpeedController> logger, ICurrentUser currentUser)
        : PayerPaymentSpeedBase(logger, currentUser)
    {
        [Tags("PayerPaymentSpeeds")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(PayerPaymentSpeedRoutes.CreatePayerPaymentSpeedTemplate, Name = PayerPaymentSpeedRoutes.CreatePayerPaymentSpeedName)]

        public async Task<IActionResult> Create(CreatePayerPaymentSpeedCommand command, CancellationToken cancellationToken)
        {
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-payer-payment-speed-request: {Name} {@UserId} {@Request}",
                    nameof(CreatePayerPaymentSpeedCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                payerPaymentSpeed => Ok(ToSuccess(Mapper.Map<PayerPaymentSpeedDto>(payerPaymentSpeed))),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-payer-payment-speed-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
