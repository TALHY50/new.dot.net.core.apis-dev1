using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Contracts.Contracts.Responses;
using SharedKernel.Main.Application.Interfaces.Services;

using SharedBusiness.Main.Admin.Weblication.Features.BusinessHourAndWeekends;
using SharedBusiness.Main.Common.Domain.Entities;

namespace Admin.Web.Presentation.Endpoints.BusinessHourAndWeekend;

public class CreateBusinessHourAndWeekend(ILogger<CreateBusinessHourAndWeekend> logger, ICurrentUser currentUser)
    : BusinessHourAndWeekendBase(logger, currentUser)
{
    [Tags("BusinessHourAndWeekends")]
    //[Authorize(Policy = "HasPermission")]
    [HttpPost(BusinessHourAndWeekendRoutes.CreateBusinessHourAndWeekendTemplate, Name = BusinessHourAndWeekendRoutes.CreateBusinessHourAndWeekendName)]

    public async Task<IActionResult> Create(CreateBusinessHourAndWeekendCommand command, CancellationToken cancellationToken)
    {
        _ = Task.Run(
            () => _logger.LogInformation(
                "create-business-hours-and-weekend-request: {Name} {@UserId} {@Request}",
                nameof(CreateBusinessHourAndWeekendCommand),
                CurrentUser.UserId,
                command),
            cancellationToken);
        var result = await Mediator.Send(command).ConfigureAwait(false);
        var response = result.Match(
            businessHoursAndWeekend => Ok(ToSuccess(Mapper.Map<BusinessHoursAndWeekendDto>(businessHoursAndWeekend))),
            Problem);
        _ = Task.Run(
            () => _logger.LogInformation(
                "create-business-hours-and-weekend-response: {Name} {@UserId} {@Response}",
                nameof(response),
                CurrentUser.UserId,
                response),
            cancellationToken);
        return response;
    }
}