using ACL.Business.Application.Features.SubModules;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;

namespace ACL.Web.Presentation.Endpoints.SubModules
{
    public class UpdateSubModuleByIdController : SubModuleBaseController
    {
        public UpdateSubModuleByIdController(ILogger<UpdateSubModuleByIdController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }

        [Tags("SubModules")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(SubModuleRoutes.UpdateSubModuleTemplate, Name = SubModuleRoutes.UpdateSubModuleName)]
        [HttpPatch(SubModuleRoutes.UpdateSubModuleTemplate, Name = SubModuleRoutes.UpdateSubModuleName)]

        public async Task<IActionResult> Update( uint id, UpdateSubModuleCommand command, CancellationToken cancellationToken)
        {
            var commandWithId = command with { id = id };
            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-submodule-request: {Name} {@UserId} {@Request}",
                    nameof(command),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);

            var response = result.Match(isSuccess => Ok(ToSuccess(result.Value)),Problem);

            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-submodule-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
       
    }
}
