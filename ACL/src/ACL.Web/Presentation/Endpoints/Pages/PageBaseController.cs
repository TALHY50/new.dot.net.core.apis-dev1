using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace ACL.Web.Presentation.Endpoints.Pages
{
    public class PageBaseController : ApiControllerBase
    {
        protected PageBaseController(ILogger<PageBaseController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }
    }
}
