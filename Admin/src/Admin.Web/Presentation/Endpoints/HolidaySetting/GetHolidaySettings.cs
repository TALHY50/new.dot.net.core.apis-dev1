using Admin.App.Presentation.Routes;
using ErrorOr;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.Admin.Application.Features.HolidaySettings;
using SharedBusiness.Main.Common.Application.Features.Countries;
using SharedBusiness.Main.Common.Contracts;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace Admin.App.Presentation.Endpoints.HolidaySetting;

public class GetHolidaySettings(ILogger<GetHolidaySettings> logger, ICurrentUser currentUser)
    : HolidaySettingBase(logger, currentUser)
{
    [Tags("HolidaySettings")]
    // [Authorize(Policy = "HasPermission")]
    [HttpGet(HolidaySettingRoutes.GetHolidaySettingTemplate, Name = HolidaySettingRoutes.GetHolidaySettingName)]
    public async Task<IActionResult> Get([FromQuery] PaginatorRequest pageRequest, CancellationToken cancellationToken)
    {
        var query = new GetHolidaySettingsQuery(PageNumber: pageRequest.page_number, PageSize: pageRequest.page_size);
        _ = Task.Run(
            () => _logger.LogInformation(
                "get-holiday-setting: {Name} {@UserId} {@Request}",
                nameof(GetHolidaySettingsQuery),
                CurrentUser.UserId,
                query),
            cancellationToken);
        var result = await Mediator.Send(query).ConfigureAwait(false);
        var response = result.Match(
            countries => Ok(ToSuccess(countries.Select(country => country.Adapt<CountryDto>()).ToList())),
            Problem
        );
        _ = Task.Run(
            () => _logger.LogInformation(
                "get-holiday-setting-response: {Name} {@UserId} {@Response}",
                nameof(response),
                CurrentUser.UserId,
                response),
            cancellationToken);
        return response;


    }
}