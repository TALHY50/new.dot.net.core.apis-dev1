using ACL.Business.Application.Features.Modules;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;

namespace ACL.Web.Presentation.Endpoints.Modules
{
    public class UpdateModuleByIdController : ModuleBaseController
    {
        public UpdateModuleByIdController(ILogger<UpdateModuleByIdController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }

        [Tags("Module")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(ModuleRoutes.UpdateModuleTemplate, Name = ModuleRoutes.UpdateModuleName)]
        [HttpPatch(ModuleRoutes.UpdateModuleTemplate, Name = ModuleRoutes.UpdateModuleName)]

        public async Task<IActionResult> Update(UpdateModuleCommand command, CancellationToken cancellationToken)
        {
            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-module-request: {Name} {@UserId} {@Request}",
                    nameof(command),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);

            var response = result.Match(isSuccess => Ok(ToSuccess(result.Value)),Problem);

            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-module-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
       
    }
}
