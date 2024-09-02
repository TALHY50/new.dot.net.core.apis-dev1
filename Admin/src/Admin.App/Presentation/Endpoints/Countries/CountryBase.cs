using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace Admin.App.Presentation.Endpoints.Country;

public class CountryBase : ApiControllerBase
{
    protected CountryBase(ILogger<CountryBase> logger, ICurrentUser currentUser) : base(logger, currentUser)
    {
    }
}