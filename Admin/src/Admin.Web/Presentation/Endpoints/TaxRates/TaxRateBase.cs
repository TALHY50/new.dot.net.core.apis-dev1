using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace Admin.Web.Presentation.Endpoints.TaxRates
{
    public class TaxRateBase : ApiControllerBase
    {
        protected TaxRateBase(ILogger<TaxRateBase> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }
    }
}
