using Admin.Web.Presentation.Routes;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.HolidaySettings;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.HolidaySetting;

public class CreateHolidaySetting(ILogger<CreateHolidaySetting> logger, ICurrentUser currentUser)
    : HolidaySettingBase(logger, currentUser)
{
    [Tags("HolidaySettings")]
    //[Authorize(Policy = "HasPermission")]
    [HttpPost(HolidaySettingRoutes.CreateHolidaySettingTemplate, Name = HolidaySettingRoutes.CreateHolidaySettingName)]

    public async Task<IActionResult> Create(CreateHolidaySettingCommand command, CancellationToken cancellationToken)
    {
        _ = Task.Run(
            () => _logger.LogInformation(
                "create-holiday-setting-request: {Name} {@UserId} {@Request}",
                nameof(CreateHolidaySettingCommand),
                CurrentUser.UserId,
                command),
            cancellationToken);
        var result = await Mediator.Send(command).ConfigureAwait(false);
        var response = result.Match(
            holidaySetting => Ok(ToSuccess(Mapper.Map<HolidaySettingDto>(holidaySetting))),
            Problem);
        _ = Task.Run(
            () => _logger.LogInformation(
                "create-holiday-setting-response: {Name} {@UserId} {@Response}",
                nameof(response),
                CurrentUser.UserId,
                response),
            cancellationToken);
        return response;
    }
}