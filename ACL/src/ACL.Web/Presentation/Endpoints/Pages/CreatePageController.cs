
using ACL.Business.Application.Features.Pages;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;

namespace ACL.Web.Presentation.Endpoints.Pages
{
    public class CreatePageController(ILogger<CreatePageController> logger, ICurrentUser currentUser): PageBaseController(logger, currentUser)
    {
        [Tags("Pages")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(PageRoutes.CreatePageTemplate, Name = PageRoutes.CreatePageName)]

        public async Task<IActionResult> Create(CreatePageCommand command, CancellationToken cancellationToken)
        {
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-page-request: {Name} {@UserId} {@Request}",
                    nameof(CreatePageCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
           
            var response = result.Match(
                        isSuccess => Ok(ToSuccess(result.Value)),
                        Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-page-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }


    }
}
