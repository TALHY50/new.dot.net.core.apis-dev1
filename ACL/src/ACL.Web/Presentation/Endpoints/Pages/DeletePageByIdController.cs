

using ACL.Business.Application.Features.Pages;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;

namespace ACL.Web.Presentation.Endpoints.Pages
{
    public class DeletePageByIdController(ILogger<DeletePageByIdController> logger, ICurrentUser currentUser): PageBaseController(logger, currentUser)
    {
        [Tags("Pages")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(PageRoutes.DeletePageTemplate, Name = PageRoutes.DeletePageName)]

        public async Task<IActionResult> Delete(uint id, CancellationToken cancellationToken)
        {
            var command = new DeletePageCommand(id)
;
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-page-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(DeletePageCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                isSuccess => Ok(ToSuccess(result.Value)),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-page-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}