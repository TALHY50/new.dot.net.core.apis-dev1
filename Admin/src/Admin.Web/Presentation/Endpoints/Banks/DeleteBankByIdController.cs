using Admin.App.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Banks;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.App.Presentation.Endpoints.Banks
{
    public class DeleteBankByIdController(ILogger<DeleteBankByIdController> logger, ICurrentUser currentUser)
    : BankBaseController(logger, currentUser)
    {
        [Tags("Banks")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(BankRoutes.DeleteBankTemplate, Name = BankRoutes.DeleteBankName)]

        public async Task<IActionResult> Delete(uint id, CancellationToken cancellationToken)
        {
            var command = new DeleteBankByIdCommand(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-bank-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(DeleteBankByIdCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                isSuccess => Ok(ToSuccess(result.Value)),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-bank-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
