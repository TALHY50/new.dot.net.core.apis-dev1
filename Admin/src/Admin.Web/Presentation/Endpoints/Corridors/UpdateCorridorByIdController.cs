using Admin.Web.Presentation.Endpoints.Corridors;
using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Corridors;
using SharedBusiness.Main.Common.Contracts.Responses;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Contracts.Contracts.Responses;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.App.Presentation.Endpoints.Corridors
{
    public class UpdateCorridorByIdController : CorridorBaseController
    {
        public UpdateCorridorByIdController(ILogger<UpdateCorridorByIdController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }

        [Tags("Corridors")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(CorridorsRoutes.UpdateCorridorTemplate, Name = CorridorsRoutes.UpdateCorridorName)]
        [HttpPatch(CorridorsRoutes.UpdateCorridorTemplate, Name = CorridorsRoutes.UpdateCorridorName)]

        public async Task<IActionResult> Update(uint id, UpdateCorridorByIdCommand command, CancellationToken cancellationToken)
        {
            var commandWithId = command with { id = id };
            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-corridor-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(commandWithId),
                    CurrentUser.UserId,
                    commandWithId),
                cancellationToken);
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
            var response = result.Match(
                corridor => Ok(ToSuccess(Mapper.Map<CorridorDto>(corridor))),
                Problem);

            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-Corridor-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
