
using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.TransactionLimits;
using SharedKernel.Main.Application.Interfaces.Services;


namespace Admin.Web.Presentation.Endpoints.TransactionLimits
{
    public class DeleteTransactionLimitController(ILogger<DeleteTransactionLimitController> logger, ICurrentUser currentUser):TransactionLimitBaseController(logger, currentUser)
    {
        [Tags("TransactionLimits")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(TransactionLimitRoutes.DeleteTransactionLimitTemplate, Name = TransactionLimitRoutes.DeleteTransactionLimitName)]

        public async Task<IActionResult> Delete(uint id, CancellationToken cancellationToken)
        {
            var command = new DeleteTransactionLimitCommand(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-transactionlimit-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(DeleteTransactionLimitCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                isSuccess => Ok(ToSuccess(result.Value)),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-transactionlimit-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }

    }

}
