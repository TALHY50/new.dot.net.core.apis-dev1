using Admin.Web.Presentation.Routes;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.BusinessHourAndWeekends;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.BusinessHourAndWeekend;

public class DeleteBusinessHourAndWeekendByIdController(ILogger<DeleteBusinessHourAndWeekendByIdController> logger, ICurrentUser currentUser)
    : BusinessHourAndWeekendBaseController(logger, currentUser)
{
    [Tags("BusinessHoursAndWeekends")]
    //[Authorize(Policy = "HasPermission")]
    [HttpDelete(BusinessHourAndWeekendRoutes.DeleteBusinessHourAndWeekendTemplate, Name = BusinessHourAndWeekendRoutes.DeleteBusinessHourAndWeekendName)]

    public async Task<IActionResult> Delete(uint id, CancellationToken cancellationToken)
    {

        var command = new DeleteBusinessHoursAndWeekendByIdCommand(id);
        _ = Task.Run(
            () => _logger.LogInformation(
                "delete-business-hours-and-weekend-by-id-request: {Name} {@UserId} {@Request}",
                nameof(DeleteBusinessHoursAndWeekendByIdCommand),
                CurrentUser.UserId,
                command),
            cancellationToken);
        var result = await Mediator.Send(command).ConfigureAwait(false);
        var response = result.Match(
            isSuccess => Ok(ToSuccess(result.Value)),
            Problem);
        _ = Task.Run(
            () => _logger.LogInformation(
                "delete-business-hours-and-weekend-by-id-response: {Name} {@UserId} {@Response}",
                nameof(response),
                CurrentUser.UserId,
                response),
            cancellationToken);
        return response;
    }


}