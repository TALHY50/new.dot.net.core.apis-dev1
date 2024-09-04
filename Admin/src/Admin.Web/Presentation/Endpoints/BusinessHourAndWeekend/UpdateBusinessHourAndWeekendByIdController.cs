using Admin.Web.Presentation.Routes;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.BusinessHourAndWeekends;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.BusinessHourAndWeekend;

public class UpdateBusinessHourAndWeekendByIdController : BusinessHourAndWeekendBaseController
{
    public UpdateBusinessHourAndWeekendByIdController(ILogger<UpdateBusinessHourAndWeekendByIdController> logger, ICurrentUser currentUser) : base(logger, currentUser)
    {
    }

    [Tags("BusinessHourAndWeekends")]
    //[Authorize(Policy = "HasPermission")]
    [HttpPut(BusinessHourAndWeekendRoutes.UpdateBusinessHourAndWeekendTemplate, Name = BusinessHourAndWeekendRoutes.UpdateBusinessHourAndWeekendName)]
    [HttpPatch(BusinessHourAndWeekendRoutes.UpdateBusinessHourAndWeekendTemplate, Name = BusinessHourAndWeekendRoutes.UpdateBusinessHourAndWeekendName)]

    public async Task<IActionResult> Update(uint id, UpdateBusinessHoursAndWeekendByIdCommand command, CancellationToken cancellationToken)
    {
        var commandWithId = command with { id = id };
        _ = Task.Run(
            () => _logger.LogInformation(
                "update-business-and-weekend-by-id-request: {Name} {@UserId} {@Request}",
                nameof(commandWithId),
                CurrentUser.UserId,
                commandWithId),
            cancellationToken);
        var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
        var response = result.Match(
            businessHoursAndWeekend => Ok(ToSuccess(Mapper.Map<BusinessHoursAndWeekendDto>(businessHoursAndWeekend))),
            Problem);

        _ = Task.Run(
            () => _logger.LogInformation(
                "update-business-and-weekend-by-id-response: {Name} {@UserId} {@Response}",
                nameof(response),
                CurrentUser.UserId,
                response),
            cancellationToken);
        return response;
    }
}