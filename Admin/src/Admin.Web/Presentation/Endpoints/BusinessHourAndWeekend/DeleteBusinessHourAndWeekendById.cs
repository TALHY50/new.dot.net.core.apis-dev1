using Admin.App.Presentation.Routes;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.BusinessHourAndWeekends;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.App.Presentation.Endpoints.BusinessHourAndWeekend;

public class DeleteBusinessHourAndWeekendById(ILogger<DeleteBusinessHourAndWeekendById> logger, ICurrentUser currentUser)
    : BusinessHourAndWeekendBase(logger, currentUser)
{
    [Tags("BusinessHourAndWeekends")]
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