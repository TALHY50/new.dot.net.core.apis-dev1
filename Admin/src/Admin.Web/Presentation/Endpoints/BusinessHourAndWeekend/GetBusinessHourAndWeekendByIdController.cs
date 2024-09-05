using Admin.Web.Presentation.Routes;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.BusinessHourAndWeekends;
using SharedBusiness.Main.Common.Contracts;
using SharedBusiness.Main.Common.Domain.Entities;

using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.BusinessHourAndWeekend;

public class GetBusinessHourAndWeekendByIdController(ILogger<GetBusinessHourAndWeekendByIdController> logger, ICurrentUser currentUser)
    : BusinessHourAndWeekendBaseController(logger, currentUser)
{
    [Tags("BusinessHoursAndWeekends")]
    //[Authorize(Policy = "HasPermission")]
    [HttpGet(BusinessHourAndWeekendRoutes.GetBusinessHourAndWeekendByIdTemplate, Name = BusinessHourAndWeekendRoutes.GetBusinessHourAndWeekendByIdName)]
    public async Task<IActionResult> GetById(uint id, CancellationToken cancellationToken)
    {
        var query = new GetBusinessHoursAndWeekendByIdQuery(id);
        _ = Task.Run(
            () => _logger.LogInformation(
                "get-business-hours-and-weekend-by-id-request: {Name} {@UserId} {@Request}",
                nameof(GetBusinessHoursAndWeekendByIdQuery),
                CurrentUser.UserId,
                query),
            cancellationToken);
        var result = await Mediator.Send(query).ConfigureAwait(false);
        var response = result.Match(
            businessHoursAndWeekend => Ok(ToSuccess(Mapper.Map<BusinessHoursAndWeekendDto>(businessHoursAndWeekend))),
            Problem);
        _ = Task.Run(
            () => _logger.LogInformation(
                "get-business-hours-and-weekend-by-id-response: {Name} {@UserId} {@Response}",
                nameof(response),
                CurrentUser.UserId,
                response),
            cancellationToken);

        return response;
    }
}