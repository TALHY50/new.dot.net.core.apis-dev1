using Admin.Web.Presentation.Routes;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.Admin.Application.Features.Mtts;
using SharedBusiness.Main.Admin.Contracts.Contracts.Responses;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Contracts.Contracts.Responses;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

namespace Admin.Web.Presentation.Endpoints.Mtts
{
    public class EndpointUpdateMttById(ILogger<EndpointUpdateMttById> logger, ICurrentUser currentUser)
       : MttBase(logger, currentUser)
    {
        [Tags("Mtt")]
        [HttpPut(MttRoutes.EditMttsRouteUrl, Name = MttRoutes.EditMttsRouteName)]
        public async Task<IActionResult> Update(uint id, UpdateMttByIdCommand command, CancellationToken cancellationToken)
        {
            var commandWithId = command with { id = id };
            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-mtt-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(commandWithId),
                    CurrentUser.UserId,
                    commandWithId),
                cancellationToken);
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
            var response = result.Match(
                country => Ok(ToSuccess(Mapper.Map<MttDto>(country))),
                Problem);

            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-mtt-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
