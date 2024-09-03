using Admin.Web.Presentation.Endpoints.Payers;
using Admin.Web.Presentation.Routes;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Payers;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace Admin.Web.Presentation.Endpoints.Payers
{
    public class GetPayersController(ILogger<GetPayersController> logger, ICurrentUser currentUser)
    : PayerBaseController(logger, currentUser)
    {
        [Tags("Payers")]
        // [Authorize(Policy = "HasPermission")]
        [HttpGet(PayerRoutes.GetPayerTemplate, Name = PayerRoutes.GetPayerName)]
        public async Task<IActionResult> Get([FromQuery] PaginatorRequest pageRequest, CancellationToken cancellationToken)
        {
            var query = new GetPayersQuery(PageNumber: pageRequest.page_number, PageSize: pageRequest.page_size);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-payers: {Name} {@UserId} {@Request}",
                    nameof(GetPayersQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                payers => Ok(ToSuccess(payers.Select(payer => payer.Adapt<PayerDto>()).ToList())),
                Problem
            );
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-payers-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
