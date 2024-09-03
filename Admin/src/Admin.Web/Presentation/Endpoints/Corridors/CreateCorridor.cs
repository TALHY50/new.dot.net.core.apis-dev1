using Admin.Web.Presentation.Routes;
using SharedKernel.Main.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Corridors;
using SharedBusiness.Main.IMT.Contracts.Contracts.Responses;
using SharedBusiness.Main.Common.Contracts.Responses;
namespace Admin.Web.Presentation.Endpoints.Corridors
{
    public class CreateCorridor(ILogger<CreateCorridor> logger, ICurrentUser currentUser)
    : CorridorBaseController(logger, currentUser)
    {
        [Tags("Corridors")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(CorridorsRoutes.CreateCorridorTemplate, Name = CorridorsRoutes.CreateCorridorName)]
        public async Task<IActionResult> Create(CreateCorridorCommand command, CancellationToken cancellationToken)
        {
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-corridor-request: {Name} {@UserId} {@Response}",
                    nameof(CreateCorridorCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                corridor => Ok(ToSuccess(Mapper.Map<CorridorDto>(corridor))),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-corridor-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response), cancellationToken);
            return response;
        }
    }
}
