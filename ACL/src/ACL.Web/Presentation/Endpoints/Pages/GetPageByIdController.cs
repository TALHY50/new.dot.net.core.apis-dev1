
using ACL.Business.Application.Features.Pages;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;

namespace ACL.Web.Presentation.Endpoints.Pages
{
    public class GetPageByIdController(ILogger<GetPageByIdController> logger, ICurrentUser currentUser) : PageBaseController(logger, currentUser)
    {
        [Tags("Pages")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(PageRoutes.GetPageByIdTemplate, Name = PageRoutes.GetPageByIdName)]
        public async Task<IActionResult> GetById(uint id, CancellationToken cancellationToken)
        {
            var query = new FindPageByIdQuery(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-page-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(FindPageByIdQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                        isSuccess => Ok(ToSuccess(result.Value)),
                        Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-page-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);

            return response;
        }
     
    }
}
