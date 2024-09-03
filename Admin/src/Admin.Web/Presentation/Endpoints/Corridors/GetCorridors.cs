using Admin.Web.Presentation.Routes;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Corridors;
using SharedBusiness.Main.Common.Contracts.Responses;
using SharedBusiness.Main.IMT.Contracts.Contracts.Responses;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace Admin.Web.Presentation.Endpoints.Corridors
{
    public class GetCorridors(ILogger<GetCorridors> logger, ICurrentUser currentUser)
    : CorridorBaseController(logger, currentUser)
    {
        [Tags("Corridors")]
        // [Authorize(Policy = "HasPermission")]
        [HttpGet(CorridorsRoutes.GetCorridorTemplate, Name = CorridorsRoutes.GetCorridorName)]
        public async Task<IActionResult> Get([FromQuery] PaginatorRequest pageRequest, CancellationToken cancellationToken)
        {
            var query = new GetCorridorsQuery(PageNumber: pageRequest.page_number, PageSize: pageRequest.page_size);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-corridors: {Name} {@UserId} {@Request}",
                    nameof(GetCorridorsQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                corridors => Ok(ToSuccess(corridors.Select(country => country.Adapt<CorridorDto>()).ToList())),
                Problem
            );
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-corridors-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
