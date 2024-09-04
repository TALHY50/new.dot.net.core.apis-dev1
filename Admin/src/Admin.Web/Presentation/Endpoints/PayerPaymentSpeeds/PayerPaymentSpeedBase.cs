using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace Admin.Web.Presentation.Endpoints.PayerPaymentSpeeds
{
    public class PayerPaymentSpeedBase : ApiControllerBase
    {
        protected PayerPaymentSpeedBase(ILogger<PayerPaymentSpeedBase> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }
    }
}
