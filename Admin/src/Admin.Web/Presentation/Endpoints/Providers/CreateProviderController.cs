using Admin.App.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Providers;
using SharedBusiness.Main.Common.Contracts;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.App.Presentation.Endpoints.Providers
{
    public class CreateProviderController(ILogger<CreateProviderController> logger, ICurrentUser currentUser)
        : ProviderBaseController(logger, currentUser)
    {
        [Tags("Providers")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(ProviderRoutes.CreateProviderTemplate, Name = ProviderRoutes.CreateProviderName)]


        public async Task<IActionResult> Create(CreateProviderCommand command, CancellationToken cancellationToken)
        {
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-provider-request: {Name} {@UserId} {@Request}",
                    nameof(CreateProviderCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                provider => Ok(ToSuccess(Mapper.Map<ProviderDto>(provider))),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-provider-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
