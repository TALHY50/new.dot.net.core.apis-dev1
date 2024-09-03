using Admin.Web.Presentation.Endpoints.Payers;
using Admin.Web.Presentation.Routes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Payers;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.Payers
{
    public class DeletePayerById(ILogger<DeletePayerById> logger, ICurrentUser currentUser)
    : PayerBaseController(logger, currentUser)
    {
        [Tags("Currencies")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(PayerRoutes.DeletePayerTemplate, Name = PayerRoutes.DeletePayerName)]

        public async Task<IActionResult> Delete(uint id, CancellationToken cancellationToken)
        {
            var command = new DeletePayerByIdCommand(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-payer-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(DeletePayerByIdCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                isSuccess => Ok(ToSuccess(result.Value)),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-payer-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
