﻿using Admin.Web.Presentation.Routes;
using Admin.Web.Presentation.Routes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.MttPaymentSpeeds;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.MttPaymentSpeeds
{
    public class GetMttPaymentSpeedByIdController(ILogger<GetMttPaymentSpeedByIdController> logger, ICurrentUser currentUser)
        : MttPaymentSpeedBaseController(logger, currentUser)
    {
        [Tags("MttPaymentSpeed")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(MttPaymentSpeedRoutes.GetMttPaymentSpeedByIdTemplate, Name = MttPaymentSpeedRoutes.GetMttPaymentSpeedByIdName)]

        public async Task<IActionResult> GetById(uint id, CancellationToken cancellationToken)
        {
            var query = new GetMttPaymentSpeedByIdQuery(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-mttPaymentSpeed-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(GetMttPaymentSpeedByIdQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                mttPaymentSpeed => Ok(ToSuccess(Mapper.Map<MttPaymentSpeedDto>(mttPaymentSpeed))),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-mttPaymentSpeed-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);

            return response;
        }
    }
}
