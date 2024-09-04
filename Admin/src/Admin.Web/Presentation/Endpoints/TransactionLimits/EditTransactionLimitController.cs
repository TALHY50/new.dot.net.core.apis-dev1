using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.TransactionLimits;
using SharedBusiness.Main.IMT.Contracts.Contracts.Responses;
using SharedKernel.Main.Application.Interfaces.Services;


namespace Admin.Web.Presentation.Endpoints.TransactionLimits
{
    public class EditTransactionLimitController(ILogger<EditTransactionLimitController> logger, ICurrentUser currentUser) : TransactionLimitBaseController(logger, currentUser)
    {
        [Tags("Transaction Limit")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(TransactionLimitRoutes.UpdateTransactionLimitTemplate, Name = TransactionLimitRoutes.UpdateTransactionLimitName)]
        public async Task<IActionResult> Update(uint id, UpdateTransactionLimitCommand command, CancellationToken cancellationToken)
        {
            var commandWithId = command with { id = id };
            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-transactionlimit-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(commandWithId),
                    CurrentUser.UserId,
                    commandWithId),
                cancellationToken);
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
            var response = result.Match(
                transactionLimit => Ok(ToSuccess(Mapper.Map<TransactionLimitDto>(transactionLimit))),
                Problem);

            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-transactionlimit-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }


   
}

