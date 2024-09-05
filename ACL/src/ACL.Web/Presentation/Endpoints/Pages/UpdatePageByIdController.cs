using ACL.Business.Application.Features.Pages;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;

namespace ACL.Web.Presentation.Endpoints.Pages
{
    public class UpdatePageByIdController : PageBaseController
    {
        public UpdatePageByIdController(ILogger<UpdatePageByIdController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }

        [Tags("Pages")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(PageRoutes.UpdatePageTemplate, Name = PageRoutes.UpdatePageName)]
        [HttpPatch(PageRoutes.UpdatePageTemplate, Name = PageRoutes.UpdatePageName)]

        public async Task<IActionResult> Update( uint id, UpdatePageCommand command, CancellationToken cancellationToken)
        {
            var commandWithId = command with { id = id };
            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-page-request: {Name} {@UserId} {@Request}",
                    nameof(command),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);

            var response = result.Match(isSuccess => Ok(ToSuccess(result.Value)),Problem);

            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-page-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
       
    }
}
