using Admin.App.Presentation.Routes;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.Admin.Application.Features.HolidaySettings;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.App.Presentation.Endpoints.HolidaySetting;

public class GetHolidaySettingById(ILogger<GetHolidaySettingById> logger, ICurrentUser currentUser)
    : HolidaySettingBase(logger, currentUser)
{
    [Tags("HolidaySettings")]
    //[Authorize(Policy = "HasPermission")]
    [HttpGet(HolidaySettingRoutes.GetHolidaySettingByIdTemplate, Name = HolidaySettingRoutes.GetHolidaySettingByIdName)]
    public async Task<IActionResult> GetById(uint id, CancellationToken cancellationToken)
    {
        var query = new GetHolidaySettingByIdQuery(id);
        _ = Task.Run(
            () => _logger.LogInformation(
                "get-holiday-setting-by-id-request: {Name} {@UserId} {@Request}",
                nameof(GetHolidaySettingByIdQuery),
                CurrentUser.UserId,
                query),
            cancellationToken);
        var result = await Mediator.Send(query).ConfigureAwait(false);
        var response = result.Match(
            holidaySetting => Ok(ToSuccess(Mapper.Map<HolidaySettingDto>(holidaySetting))),
            Problem);
        _ = Task.Run(
            () => _logger.LogInformation(
                "get-holiday-setting-by-id-response: {Name} {@UserId} {@Response}",
                nameof(response),
                CurrentUser.UserId,
                response),
            cancellationToken);

        return response;
    }
}