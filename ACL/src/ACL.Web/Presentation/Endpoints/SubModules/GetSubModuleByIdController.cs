
using ACL.Business.Application.Features.SubModules;
using ACL.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;

namespace ACL.Web.Presentation.Endpoints.SubModules
{
    public class GetSubModuleByIdController(ILogger<GetSubModuleByIdController> logger, ICurrentUser currentUser) : SubModuleBaseController(logger, currentUser)
    {
        [Tags("SubModule")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(SubModuleRoutes.GetSubModuleByIdTemplate, Name = SubModuleRoutes.GetSubModuleByIdName)]
        public async Task<IActionResult> GetById(uint id, CancellationToken cancellationToken)
        {
            var query = new FindSubModuleByIdQuery(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-submodule-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(FindSubModuleByIdQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                        isSuccess => Ok(ToSuccess(result.Value)),
                        Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-submodule-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);

            return response;
        }
     
    }
}
