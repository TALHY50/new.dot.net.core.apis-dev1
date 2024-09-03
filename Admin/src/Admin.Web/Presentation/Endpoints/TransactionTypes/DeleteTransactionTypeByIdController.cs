using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.Admin.Application.Features.TransactionTypes;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.TransactionTypes
{
    public class DeleteTransactionTypeByIdController(ILogger<DeleteTransactionTypeByIdController> logger, ICurrentUser currentUser)
    : TransactionTypeBaseController(logger, currentUser)
    {
        [Tags("TransactionTypes")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(TransactionTypeRoutes.DeleteTransactionTypeTemplate, Name = TransactionTypeRoutes.DeleteTransactionTypeName)]

        public async Task<IActionResult> Delete(uint id, CancellationToken cancellationToken)
        {
            var command = new DeleteTransactionTypeByIdCommand(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-transactionType-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(DeleteTransactionTypeByIdCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                isSuccess => Ok(ToSuccess(result.Value)),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-transactionType-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
