using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace Admin.Web.Presentation.Endpoints.BusinessHourAndWeekend;

public class BusinessHourAndWeekendBase : ApiControllerBase
{
    protected BusinessHourAndWeekendBase(ILogger<BusinessHourAndWeekendBase> logger, ICurrentUser currentUser) : base(logger, currentUser)
    {
    }
}