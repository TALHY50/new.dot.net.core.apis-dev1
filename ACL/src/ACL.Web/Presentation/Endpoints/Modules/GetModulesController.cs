
using ACL.Business.Application.Features.Modules;
using ACL.Business.Contracts.Responses;
using ACL.Web.Presentation.Routes;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace ACL.Web.Presentation.Endpoints.Modules
{
    public class GetModulesController(ILogger<GetModulesController> logger, ICurrentUser currentUser) : ModuleBaseController(logger, currentUser)
    {
        [Tags("Modules")]
        // [Authorize(Policy = "HasPermission")]
        [HttpGet(ModuleRoutes.GetModuleTemplate, Name = ModuleRoutes.GetModuleName)]
        public async Task<IActionResult> Get([FromQuery] PaginatorRequest pageRequest, CancellationToken cancellationToken)
        {
            var query = new GetModuleQuery(PageNumber: pageRequest.page_number, PageSize: pageRequest.page_size);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-modules: {Name} {@UserId} {@Request}",
                    nameof(GetModuleQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                     modules => Ok(ToSuccess(modules.Select(module => module.Adapt<ModuleDto>()).ToList())),
                     Problem
                 );
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-module-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }

    }
}
