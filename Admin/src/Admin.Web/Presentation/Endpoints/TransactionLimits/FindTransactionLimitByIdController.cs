
using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.TransactionLimits;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;


namespace Admin.Web.Presentation.Endpoints.TransactionLimits
{
    public class FindTransactionLimitByIdController(ILogger<FindTransactionLimitByIdController> logger, ICurrentUser currentUser) : TransactionLimitBaseController(logger, currentUser)
    {
        [Tags("Transaction Limit")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(TransactionLimitRoutes.GetTransactionLimitByIdTemplate, Name = TransactionLimitRoutes.GetTransactionLimitByIdName)]
        public async Task<IActionResult> GetById(uint id, CancellationToken cancellationToken)
        {
            var query = new FindTransactionLimitByIdQuery(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-transactionlimit-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(FindTransactionLimitByIdQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                country => Ok(ToSuccess(Mapper.Map<TransactionLimitDto>(country))),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-transactionlimit-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);

            return response;
        }
    }

}
