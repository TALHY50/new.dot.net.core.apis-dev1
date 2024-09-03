﻿using ErrorOr;
using FluentValidation;
using Mapster;
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
using SharedKernel.Main.Contracts;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

namespace Admin.App.Application.Features.Mtts
{
    public class EndpointGetMtts(ILogger<EndpointGetMtts> logger, ICurrentUser currentUser)
      : MttBase(logger, currentUser)
    {
        [Tags("Mtt")]
        [HttpGet(AdminRoute.AllMttsRouteUrl, Name = AdminRoute.AllMttsRouteName)]
        public async Task<IActionResult> Get([FromQuery] PaginatorRequest pageRequest, CancellationToken cancellationToken)
        {
            var query = new GetMttsQuery(PageNumber: pageRequest.page_number, PageSize: pageRequest.page_size);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-mtts: {Name} {@UserId} {@Request}",
                    nameof(GetMttsQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                entities => Ok(ToSuccess(entities.Select(entity => entity.Adapt<MttDto>()).ToList())),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-mtts-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}