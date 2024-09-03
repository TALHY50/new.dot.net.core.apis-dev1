using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace Admin.Web.Presentation.Endpoints.HolidaySetting;

public class HolidaySettingBaseController : ApiControllerBase
{
    protected HolidaySettingBaseController(ILogger<HolidaySettingBaseController> logger, ICurrentUser currentUser) : base(logger, currentUser)
    {
    }
}