using Admin.Web.Presentation.Routes;
using Admin.Web.Presentation.Routes;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.MttPaymentSpeeds;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace Admin.Web.Presentation.Endpoints.MttPaymentSpeeds
{
    public class GetMttPaymentSpeedsController(ILogger<GetMttPaymentSpeedsController> logger, ICurrentUser currentUser)
        : MttPaymentSpeedBaseController(logger, currentUser)
    {
        [Tags("MttPaymentSpeed")]
        // [Authorize(Policy = "HasPermission")]
        [HttpGet(MttPaymentSpeedRoutes.GetMttPaymentSpeedTemplate, Name = MttPaymentSpeedRoutes.GetMttPaymentSpeedName)]
        public async Task<IActionResult> Get([FromQuery] PaginatorRequest pageRequest, CancellationToken cancellationToken)
        {
            var query = new GetMttPaymentSpeedsQuery(PageNumber: pageRequest.page_number, PageSize: pageRequest.page_size);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-mttPaymentSpeeds: {Name} {@UserId} {@Request}",
                    nameof(GetMttPaymentSpeedsQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                mttPaymentSpeeds => Ok(ToSuccess(mttPaymentSpeeds.Select(mttPaymentSpeed => mttPaymentSpeed.Adapt<MttPaymentSpeedDto>()).ToList())),
                Problem
            );
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-mttPaymentSpeeds-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
