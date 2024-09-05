using Admin.Web.Presentation.Endpoints.PayerPaymentSpeeds;
using Admin.Web.Presentation.Routes;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.PayerPaymentSpeeds;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace Admin.Web.Presentation.Endpoints.PayerPaymentSpeeds
{
    public class GetPayerPaymentSpeedsController(ILogger<GetPayerPaymentSpeedsController> logger, ICurrentUser currentuser)
        : PayerPaymentSpeedBase(logger, currentuser)
    {
        [Tags("PayersPaymentSpeeds")]
        // [Authorize(Policy = "HasPermission")]
        [HttpGet(PayerPaymentSpeedRoutes.GetPayerPaymentSpeedTemplate, Name = PayerPaymentSpeedRoutes.GetPayerPaymentSpeedName)]
        public async Task<IActionResult> Get([FromQuery] PaginatorRequest pageRequest, CancellationToken cancellationToken)
        {
            var query = new GetPayerPaymentSpeedsQuery(PageNumber: pageRequest.page_number, PageSize: pageRequest.page_size);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-payer-payment-speeds: {Name} {@UserId} {@Request}",
                    nameof(GetPayerPaymentSpeedsQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                payerPaymentSpeeds => Ok(ToSuccess(payerPaymentSpeeds.Select(payerPaymentSpeed => payerPaymentSpeed.Adapt<PayerPaymentSpeedDto>()).ToList())),
                Problem
            );
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-payer-payment-speeds-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
