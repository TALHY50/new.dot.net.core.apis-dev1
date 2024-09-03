using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace Admin.Web.Presentation.Endpoints.BusinessHourAndWeekend;

public class BusinessHourAndWeekendBaseController : ApiControllerBase
{
    protected BusinessHourAndWeekendBaseController(ILogger<BusinessHourAndWeekendBaseController> logger, ICurrentUser currentUser) : base(logger, currentUser)
    {
    }
}