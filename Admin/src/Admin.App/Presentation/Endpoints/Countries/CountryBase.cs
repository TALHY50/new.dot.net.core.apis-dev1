using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Interfaces.Services;

namespace Admin.App.Presentation.Endpoints.Country;

public class CountryBase : ApiControllerBase
{
    protected CountryBase(ILogger<CountryBase> logger, ICurrentUserService currentUserService) : base(logger, currentUserService)
    {
    }
}