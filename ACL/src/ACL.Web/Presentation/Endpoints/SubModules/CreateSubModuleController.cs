
using ACL.Business.Application.Features.SubModules;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;

namespace ACL.Web.Presentation.Endpoints.SubModules
{
    public class CreateSubModuleController(ILogger<CreateSubModuleController> logger, ICurrentUser currentUser): SubModuleBaseController(logger, currentUser)
    {
        [Tags("SubModule")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(SubModuleRoutes.CreateSubModuleTemplate, Name = SubModuleRoutes.CreateSubModuleName)]

        public async Task<IActionResult> Create(CreateSubModuleCommand command, CancellationToken cancellationToken)
        {
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-submodule-request: {Name} {@UserId} {@Request}",
                    nameof(CreateSubModuleCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
           
            var response = result.Match(
                        isSuccess => Ok(ToSuccess(result.Value)),
                        Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-submodule-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }


    }
}
