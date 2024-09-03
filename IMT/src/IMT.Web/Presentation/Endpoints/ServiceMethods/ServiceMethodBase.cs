using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace IMT.App.Presentation.Endpoints.ServiceMethods
{
    public class ServiceMethodBase : ApiControllerBase
    {
        protected ServiceMethodBase(ILogger<ServiceMethodBase> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }
    }
}
