using ACL.Business.Application.Interfaces.Services;
using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Mtts;
using SharedBusiness.Main.Admin.Contracts.Contracts.Responses;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation.Routes;

namespace Admin.Web.Application.Features.Mtts
{
    public class EndpointCreateMtt(ILogger<EndpointCreateMtt> logger, ICurrentUser currentUser)
    : MttBase(logger, currentUser)
    {
        [Tags("Mtt")]
        [HttpPost(MttRoutes.CreateMttsRouteUrl, Name = MttRoutes.CreateMttsRouteName)]

        public async Task<IActionResult> Create(CreateMttCommand command, CancellationToken cancellationToken)
        {
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-mtt-request: {Name} {@UserId} {@Request}",
                    nameof(CreateMttCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                country => Ok(ToSuccess(Mapper.Map<MttDto>(country))),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-mtt-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}