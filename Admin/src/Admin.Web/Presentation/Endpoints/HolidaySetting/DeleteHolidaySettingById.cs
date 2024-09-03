using Admin.Web.Presentation.Routes;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.HolidaySettings;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.HolidaySetting;

public class DeleteHolidaySettingById(ILogger<DeleteHolidaySettingById> logger, ICurrentUser currentUser)
    : HolidaySettingBase(logger, currentUser)
{
    [Tags("HolidaySettings")]
    //[Authorize(Policy = "HasPermission")]
    [HttpDelete(HolidaySettingRoutes.DeleteHolidaySettingTemplate, Name = HolidaySettingRoutes.DeleteHolidaySettingName)]

    public async Task<IActionResult> Delete(uint id, CancellationToken cancellationToken)
    {
        var command = new DeleteHolidaySettingByIdCommand(id);
        _ = Task.Run(
            () => _logger.LogInformation(
                "delete-holiday-setting-by-id-request: {Name} {@UserId} {@Request}",
                nameof(DeleteHolidaySettingByIdCommand),
                CurrentUser.UserId,
                command),
            cancellationToken);
        var result = await Mediator.Send(command).ConfigureAwait(false);
        var response = result.Match(
            isSuccess => Ok(ToSuccess(result.Value)),
            Problem);
        _ = Task.Run(
            () => _logger.LogInformation(
                "delete-holiday-setting-by-id-response: {Name} {@UserId} {@Response}",
                nameof(response),
                CurrentUser.UserId,
                response),
            cancellationToken);
        return response;
    }


}