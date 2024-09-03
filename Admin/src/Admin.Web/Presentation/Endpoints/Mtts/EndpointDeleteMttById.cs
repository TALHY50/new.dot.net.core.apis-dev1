using Admin.Web.Presentation.Routes;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.Admin.Application.Features.Mtts;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

namespace Admin.Web.Presentation.Endpoints.Mtts
{
    public class EndpointDeleteMttById(ILogger<EndpointDeleteMttById> logger, ICurrentUser currentUser)
    : MttBase(logger, currentUser)
    {
        [Tags("Mtt")]
        [HttpDelete(MttRoutes.DeleteMttsRouteUrl, Name = MttRoutes.DeleteMttsRouteName)]
        public async Task<IActionResult> Delete(uint id, CancellationToken cancellationToken)
        {
            var command = new DeleteMttByIdCommand(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-mtt-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(DeleteMttByIdCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                isSuccess => Ok(ToSuccess(result.Value)),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "delete-mtt-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
