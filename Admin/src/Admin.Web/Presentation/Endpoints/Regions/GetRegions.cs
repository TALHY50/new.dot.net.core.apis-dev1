﻿using Admin.Web.Presentation.Endpoints.Country;
using Admin.Web.Presentation.Routes;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Weblication.Features.Regions;
using SharedBusiness.Main.IMT.Contracts.Contracts.Responses;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace Admin.Web.Presentation.Endpoints.Regions
{
    public class GetRegions(ILogger<GetRegions> logger, ICurrentUser currentUser)
        : CountryBase(logger, currentUser)
    {
        [Tags("Regions")]
        // [Authorize(Policy = "HasPermission")]
        [HttpGet(RegionRoutes.GetRegionTemplate, Name = RegionRoutes.GetRegionName)]
        public async Task<IActionResult> Get([FromQuery] PaginatorRequest pageRequest, CancellationToken cancellationToken)
        {
            var query = new GetRegionsQuery(PageNumber: pageRequest.page_number, PageSize: pageRequest.page_size);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-regions: {Name} {@UserId} {@Request}",
                    nameof(GetRegionsQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                regions => Ok(ToSuccess(regions.Select(region => region.Adapt<RegionDto>()).ToList())),
                Problem
            );
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-regions-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
