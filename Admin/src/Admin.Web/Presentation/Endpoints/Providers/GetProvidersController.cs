using Admin.App.Presentation.Endpoints.Providers;
using Admin.App.Presentation.Routes;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Providers;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace Admin.Web.Presentation.Endpoints.Providers
{
    public class GetProvidersController(ILogger<GetProvidersController> logger, ICurrentUser currentUser)
        : ProviderBaseController(logger, currentUser)
    {
        [Tags("Providers")]
        // [Authorize(Policy = "HasPermission")]
        [HttpGet(ProviderRoutes.GetProviderTemplate, Name = ProviderRoutes.GetProviderName)]
        public async Task<IActionResult> Get([FromQuery] PaginatorRequest pageRequest, CancellationToken cancellationToken)
        {
            var query = new GetProvidersQuery(PageNumber: pageRequest.page_number, PageSize: pageRequest.page_size);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-providers: {Name} {@UserId} {@Request}",
                    nameof(GetProvidersQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                providers => Ok(ToSuccess(providers.Select(provider => provider.Adapt<ProviderDto>()).ToList())),
                Problem
            );
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-providers-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
