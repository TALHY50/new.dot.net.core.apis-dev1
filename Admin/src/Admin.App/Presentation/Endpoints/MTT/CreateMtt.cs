using Ardalis.Specification;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using ACL.Business.Application.Interfaces.Services;
using Admin.App.Presentation.Routes;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.IMT.Contracts.Contracts.Responses;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Infrastructure.Attributes;
using SharedKernel.Main.Presentation.Routes;
using SharedBusiness.Main.Admin.Application.Features.Mtts;
using SharedBusiness.Main.Admin.Contracts.Contracts.Responses;

namespace Admin.App.Application.Features.Mtts
{
    public class CreateMtt(ILogger<CreateMtt> logger, ICurrentUser currentUser)
    : MttBase(logger, currentUser)
    {
        [Tags("Mtt")]
        [HttpPost(AdminRoute.CreateMttsRouteUrl, Name = AdminRoute.CreateMttsRouteName)]

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