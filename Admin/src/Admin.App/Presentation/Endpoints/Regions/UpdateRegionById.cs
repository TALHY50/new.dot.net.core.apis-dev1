﻿using Admin.App.Presentation.Endpoints.Country;
using Admin.App.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.Admin.Application.Features.Regions;
using SharedBusiness.Main.IMT.Contracts.Contracts.Responses;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.App.Presentation.Endpoints.Regions
{
    public class UpdateRegionById : RegionBase
    {
        public UpdateRegionById(ILogger<UpdateRegionById> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }

        [Tags("Regions")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(RegionRoutes.UpdateRegionTemplate, Name = RegionRoutes.UpdateRegionName)]
        [HttpPatch(RegionRoutes.UpdateRegionTemplate, Name = RegionRoutes.UpdateRegionName)]

        public async Task<IActionResult> Update(uint id, UpdateRegionByIdCommand command, CancellationToken cancellationToken)
        {
            var commandWithId = command with { id = id };
            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-region-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(commandWithId),
                    CurrentUser.UserId,
                    commandWithId),
                cancellationToken);
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
            var response = result.Match(
                region => Ok(ToSuccess(Mapper.Map<RegionDto>(region))),
                Problem);

            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-region-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}