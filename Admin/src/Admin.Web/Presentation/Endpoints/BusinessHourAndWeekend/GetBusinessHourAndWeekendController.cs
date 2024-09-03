using Admin.Web.Presentation.Routes;
using ErrorOr;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.BusinessHourAndWeekends;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.IMT.Contracts.Contracts.Responses;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace Admin.Web.Presentation.Endpoints.BusinessHourAndWeekend;

public class GetBusinessHourAndWeekendController(ILogger<GetBusinessHourAndWeekendController> logger, ICurrentUser currentUser)
    : BusinessHourAndWeekendBaseController(logger, currentUser)
{
    [Tags("BusinessHourAndWeekends")]
    // [Authorize(Policy = "HasPermission")]
    [HttpGet(BusinessHourAndWeekendRoutes.GetBusinessHourAndWeekendTemplate, Name = BusinessHourAndWeekendRoutes.GetBusinessHourAndWeekendName)]
    public async Task<IActionResult> Get([FromQuery] PaginatorRequest pageRequest, CancellationToken cancellationToken)
    {
        var query = new GetBusinessHourAndWeekendsQuery(PageNumber: pageRequest.page_number, PageSize: pageRequest.page_size);
        _ = Task.Run(
            () => _logger.LogInformation(
                "get-business-hours-and-weekend: {Name} {@UserId} {@Request}",
                nameof(GetBusinessHourAndWeekendsQuery),
                CurrentUser.UserId,
                query),
            cancellationToken);
        var result = await Mediator.Send(query).ConfigureAwait(false);
        var response = result.Match(
            businessHoursAndWeekends => Ok(ToSuccess(businessHoursAndWeekends.Select(businessHoursAndWeekend => businessHoursAndWeekend.Adapt<BusinessHoursAndWeekendDto>()).ToList())),
            Problem
        );
        _ = Task.Run(
            () => _logger.LogInformation(
                "get-business-hours-and-weekend-response: {Name} {@UserId} {@Response}",
                nameof(response),
                CurrentUser.UserId,
                response),
            cancellationToken);
        return response;
    }
}