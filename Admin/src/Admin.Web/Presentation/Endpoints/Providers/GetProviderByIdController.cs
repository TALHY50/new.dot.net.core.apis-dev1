using Admin.Web.Presentation.Endpoints.Providers;
using Admin.Web.Presentation.Routes;
using Admin.Web.Presentation.Routes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Providers;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.Providers
{
    public class GetProviderByIdController(ILogger<GetProviderByIdController> logger, ICurrentUser currentUser)
        : ProviderBaseController(logger, currentUser)
    {
        [Tags("Providers")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(ProviderRoutes.GetProviderByIdTemplate, Name = ProviderRoutes.GetProviderByIdName)]

        public async Task<IActionResult> GetById(uint id, CancellationToken cancellationToken)
        {
            var query = new GetProviderByIdQuery(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-provider-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(GetProviderByIdQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                provider => Ok(ToSuccess(Mapper.Map<ProviderDto>(provider))),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-provider-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);

            return response;
        }
    }
}
