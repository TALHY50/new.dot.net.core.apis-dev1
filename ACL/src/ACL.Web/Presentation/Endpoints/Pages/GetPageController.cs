
using ACL.Business.Application.Features.Pages;
using ACL.Business.Contracts.Responses;
using ACL.Web.Presentation.Routes;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace ACL.Web.Presentation.Endpoints.Pages
{
    public class GetPageController(ILogger<GetPageController> logger, ICurrentUser currentUser) : PageBaseController(logger, currentUser)
    {
        [Tags("Pages")]
        // [Authorize(Policy = "HasPermission")]
        [HttpGet(PageRoutes.GetPageTemplate, Name = PageRoutes.GetPageName)]
        public async Task<IActionResult> Get([FromQuery] PaginatorRequest pageRequest, CancellationToken cancellationToken)
        {
            var query = new GetPageQuery(PageNumber: pageRequest.page_number, PageSize: pageRequest.page_size);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-pages: {Name} {@UserId} {@Request}",
                    nameof(GetPageQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                     pages => Ok(ToSuccess(pages.Select(page => page.Adapt<PageDto>()).ToList())),
                     Problem
                 );
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-page-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }

    }
}
