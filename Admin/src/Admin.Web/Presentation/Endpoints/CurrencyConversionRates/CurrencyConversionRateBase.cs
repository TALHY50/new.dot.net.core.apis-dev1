using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace Admin.Web.Presentation.Endpoints.CurrencyConversionRates
{
    public class CurrencyConversionRateBase : ApiControllerBase
    {
        protected CurrencyConversionRateBase(ILogger<CurrencyConversionRateBase> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }
    }
}
