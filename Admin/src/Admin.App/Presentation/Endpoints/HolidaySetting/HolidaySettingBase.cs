using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace Admin.Web.Presentation.Endpoints.BusinessHourAndWeekend;

public class HolidaySettingBase : ApiControllerBase
{
    protected HolidaySettingBase(ILogger<HolidaySettingBase> logger, ICurrentUser currentUser) : base(logger, currentUser)
    {
    }
}