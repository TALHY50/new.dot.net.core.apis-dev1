using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.ServiceMethods;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.ServiceMethods
{
    public class DeleteServiceMethodByIdController(ILogger<DeleteServiceMethodByIdController> logger, ICurrentUser currentUser)
        : ServiceMethodBase(logger, currentUser)
    {
        [Tags("ServiceMethods")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(ServiceMethodRoutes.DeleteServiceMethodTemplate, Name = ServiceMethodRoutes.DeleteServiceMethodName)]

        public async Task<IActionResult> Delete(uint id, CancellationToken cancellationToken)
        {
            var command = new DeleteServiceMethodByIdCommand(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-service-method-request: {Name} {@UserId} {@Request}",
                    nameof(DeleteServiceMethodByIdCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                isSuccess => Ok(ToSuccess(result.Value)),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-service-method-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
