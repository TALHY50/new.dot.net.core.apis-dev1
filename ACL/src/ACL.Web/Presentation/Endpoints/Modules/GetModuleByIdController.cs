
using ACL.Business.Application.Features.Modules;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;

namespace ACL.Web.Presentation.Endpoints.Modules
{
    public class GetModuleByIdController(ILogger<GetModuleByIdController> logger, ICurrentUser currentUser) : ModuleBaseController(logger, currentUser)
    {
        [Tags("Module")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(ModuleRoutes.GetModuleByIdTemplate, Name = ModuleRoutes.GetModuleByIdName)]
        public async Task<IActionResult> GetById(uint id, CancellationToken cancellationToken)
        {
            var query = new FindModuleByIdQuery(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-module-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(FindModuleByIdQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                        isSuccess => Ok(ToSuccess(result.Value)),
                        Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-module-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);

            return response;
        }
     
    }
}
