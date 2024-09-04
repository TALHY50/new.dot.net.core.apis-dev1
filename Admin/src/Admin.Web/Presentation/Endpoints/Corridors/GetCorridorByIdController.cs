using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Corridors;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.Corridors
{
    public class GetCorridorByIdController(ILogger<GetCorridorByIdController> logger, ICurrentUser currentUser)
    : CorridorBaseController(logger, currentUser)
    {
        [Tags("Currencies")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(CorridorsRoutes.GetCorridorByIdTemplate, Name = CorridorsRoutes.GetCorridorByIdName)]
        public async Task<IActionResult> GetById(uint id, CancellationToken cancellationToken)
        {
            var query = new GetCorridorByIdQuery(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-Corridor-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(GetCorridorByIdQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                corridor => Ok(ToSuccess(Mapper.Map<CorridorDto>(corridor))),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-Corridor-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);

            return response;
        }
    }
}
