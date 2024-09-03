
using Admin.App.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.TransactionLimits;
using SharedBusiness.Main.IMT.Contracts.Contracts.Responses;
using SharedKernel.Main.Application.Interfaces.Services;


namespace Admin.App.Presentation.Endpoints.TransactionLimits
{
    public class FindTransactionLimitByIdController(ILogger<EditTransactionLimitController> logger, ICurrentUser currentUser) : TransactionLimitBaseController(logger, currentUser)
    {
        [Tags("Transaction Limit")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(TransactionLimitRoutes.GetTransactionLimitByIdTemplate, Name = TransactionLimitRoutes.GetTransactionLimitByIdName)]
        public async Task<IActionResult> GetById(uint Id, CancellationToken cancellationToken)
        {
            var query = new FindTransactionLimitByIdQuery(Id);
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
