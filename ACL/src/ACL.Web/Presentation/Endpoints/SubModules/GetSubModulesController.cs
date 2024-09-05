
using ACL.Business.Application.Features.SubModules;
using ACL.Business.Contracts.Responses;
using ACL.Web.Presentation.Routes;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace ACL.Web.Presentation.Endpoints.SubModules
{
    public class GetSubModulesController(ILogger<GetSubModulesController> logger, ICurrentUser currentUser) : SubModuleBaseController(logger, currentUser)
    {
        [Tags("SubModules")]
        // [Authorize(Policy = "HasPermission")]
        [HttpGet(SubModuleRoutes.GetSubModuleTemplate, Name = SubModuleRoutes.GetSubModuleName)]
        public async Task<IActionResult> Get([FromQuery] PaginatorRequest pageRequest, CancellationToken cancellationToken)
        {
            var query = new GetSubModuleQuery(PageNumber: pageRequest.page_number, PageSize: pageRequest.page_size);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-submodules: {Name} {@UserId} {@Request}",
                    nameof(GetSubModuleQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                     submodules => Ok(ToSuccess(submodules.Select(submodule => submodule.Adapt<SubModuleDto>()).ToList())),
                     Problem
                 );
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-submodule-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }

    }
}
