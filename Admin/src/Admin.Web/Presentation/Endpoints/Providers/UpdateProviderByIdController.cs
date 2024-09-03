using Admin.App.Presentation.Endpoints.Providers;
using Admin.App.Presentation.Routes;
using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Providers;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.Providers
{
    public class UpdateProviderByIdController : ProviderBaseController
    {
        public UpdateProviderByIdController(ILogger<UpdateProviderByIdController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }

        [Tags("Providers")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(ProviderRoutes.UpdateProviderTemplate, Name = ProviderRoutes.UpdateProviderName)]
        [HttpPatch(ProviderRoutes.UpdateProviderTemplate, Name = ProviderRoutes.UpdateProviderName)]

        public async Task<IActionResult> Update(uint id, UpdateProviderByIdCommand command, CancellationToken cancellationToken)
        {
            var commandWithId = command with { id = id };
            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-provider-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(commandWithId),
                    CurrentUser.UserId,
                    commandWithId),
                cancellationToken);
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
            var response = result.Match(
                provider => Ok(ToSuccess(Mapper.Map<ProviderDto>(provider))),
                Problem);

            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-provider-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
