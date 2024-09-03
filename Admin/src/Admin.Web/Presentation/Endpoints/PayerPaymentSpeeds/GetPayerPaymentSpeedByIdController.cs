using Admin.App.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.PayerPaymentSpeeds;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.App.Presentation.Endpoints.PayerPaymentSpeeds
{
    public class GetPayerPaymentSpeedByIdController(ILogger<GetPayerPaymentSpeedByIdController> logger, ICurrentUser currentUser)
        : PayerPaymentSpeedBase(logger, currentUser)
    {
        [Tags("PayerPaymentSpeeds")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(PayerPaymentSpeedRoutes.GetPayerPaymentSpeedByIdTemplate, Name = PayerPaymentSpeedRoutes.GetPayerPaymentSpeedByIdName)]
        public async Task<IActionResult> GetById(uint id, CancellationToken cancellationToken)
        {
            var query = new GetPayerPaymentSpeedByIdQuery(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-payer-payment-speed-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(GetPayerPaymentSpeedByIdQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                payerPaymentSpeed => Ok(ToSuccess(Mapper.Map<PayerPaymentSpeedDto>(payerPaymentSpeed))),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-payer-payment-speed-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);

            return response;
        }
    }
}
