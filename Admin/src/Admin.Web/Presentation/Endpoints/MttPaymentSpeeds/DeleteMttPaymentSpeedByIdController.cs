using Admin.App.Presentation.Routes;
using Admin.Web.Presentation.Routes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.MttPaymentSpeeds;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.MttPaymentSpeeds
{
    public class DeleteMttPaymentSpeedByIdController(ILogger<DeleteMttPaymentSpeedByIdController> logger, ICurrentUser currentUser)
        : MttPaymentSpeedBaseController(logger, currentUser)
    {
        [Tags("MttPaymentSpeeds")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(MttPaymentSpeedRoutes.DeleteMttPaymentSpeedTemplate, Name = MttPaymentSpeedRoutes.DeleteMttPaymentSpeedName)]

        public async Task<IActionResult> Delete(uint id, CancellationToken cancellationToken)
        {
            var command = new DeleteMttPaymentSpeedByIdCommand(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-mttPaymentSpeed-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(DeleteMttPaymentSpeedByIdCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                isSuccess => Ok(ToSuccess(result.Value)),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-mttPaymentSpeed-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
