using Admin.App.Presentation.Routes;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.Admin.Application.Features.HolidaySettings;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.App.Presentation.Endpoints.HolidaySetting;

public class UpdateHolidaySettingById : HolidaySettingBase
{
    public UpdateHolidaySettingById(ILogger<UpdateHolidaySettingById> logger, ICurrentUser currentUser) : base(logger, currentUser)
    {
    }

    [Tags("HolidaySettings")]
    //[Authorize(Policy = "HasPermission")]
    [HttpPut(HolidaySettingRoutes.UpdateHolidaySettingTemplate, Name = HolidaySettingRoutes.UpdateHolidaySettingName)]
    [HttpPatch(HolidaySettingRoutes.UpdateHolidaySettingTemplate, Name = HolidaySettingRoutes.UpdateHolidaySettingName)]

    public async Task<IActionResult> Update(uint id, UpdateHolidaySettingByIdCommand command, CancellationToken cancellationToken)
    {
        var commandWithId = command with { id = id };
        _ = Task.Run(
            () => _logger.LogInformation(
                "update-holiday-setting-by-id-request: {Name} {@UserId} {@Request}",
                nameof(commandWithId),
                CurrentUser.UserId,
                commandWithId),
            cancellationToken);
        var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
        var response = result.Match(
            holidaySetting => Ok(ToSuccess(Mapper.Map<HolidaySettingDto>(holidaySetting))),
            Problem);

        _ = Task.Run(
            () => _logger.LogInformation(
                "update-holiday-setting-by-id-response: {Name} {@UserId} {@Response}",
                nameof(response),
                CurrentUser.UserId,
                response),
            cancellationToken);
        return response;
    }
}