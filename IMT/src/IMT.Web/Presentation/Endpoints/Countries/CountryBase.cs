using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace IMT.App.Presentation.Endpoints.Countries;

public class CountryBase : ApiControllerBase
{
    protected CountryBase(ILogger<CountryBase> logger, ICurrentUser currentUser) : base(logger, currentUser)
    {
    }
}