
using ACL.Business.Application.Features.Modules;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;

namespace ACL.Web.Presentation.Endpoints.Modules
{
    public class CreateModuleController(ILogger<CreateModuleController> logger, ICurrentUser currentUser): ModuleBaseController(logger, currentUser)
    {
        [Tags("Modules")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(ModuleRoutes.CreateModuleTemplate, Name = ModuleRoutes.CreateModuleName)]

        public async Task<IActionResult> Create(CreateModuleCommand command, CancellationToken cancellationToken)
        {
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-module-request: {Name} {@UserId} {@Request}",
                    nameof(CreateModuleCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
           
            var response = result.Match(
                        isSuccess => Ok(ToSuccess(result.Value)),
                        Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-module-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }


    }
}
