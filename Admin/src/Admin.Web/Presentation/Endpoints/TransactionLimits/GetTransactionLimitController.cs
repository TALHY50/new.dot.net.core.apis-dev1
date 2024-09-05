
using Admin.Web.Presentation.Routes;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.TransactionLimits;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace Admin.Web.Presentation.Endpoints.TransactionLimits
{
   
    public class GetTransactionLimitController(ILogger<GetTransactionLimitController> logger, ICurrentUser currentUser)
    : TransactionLimitBaseController(logger, currentUser)
    {
        [Tags("TransactionLimits")]
        // [Authorize(Policy = "HasPermission")]
        [HttpGet(TransactionLimitRoutes.GetTransactionLimitTemplate, Name = TransactionLimitRoutes.GetTransactionLimitName)]
        public async Task<IActionResult> Get([FromQuery] PaginatorRequest pageRequest, CancellationToken cancellationToken)
        {
            var query = new GetTransactionLimitQuery(PageNumber: pageRequest.page_number, PageSize: pageRequest.page_size);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-countries: {Name} {@UserId} {@Request}",
                    nameof(GetTransactionLimitQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                countries => Ok(ToSuccess(countries.Select(transactionLimit => transactionLimit.Adapt<TransactionLimitDto>()).ToList())),
                Problem
            );
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-countries-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
