using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace Admin.App.Presentation.Endpoints.InstitutionFunds
{
    public class InstitutionFundBase : ApiControllerBase
    {
        protected InstitutionFundBase(ILogger<InstitutionFundBase> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }
    }
}
