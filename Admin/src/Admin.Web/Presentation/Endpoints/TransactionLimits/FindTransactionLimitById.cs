
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.TransactionLimits;
using SharedKernel.Main.Presentation;
using SRoutes = SharedKernel.Main.Presentation.Routes.Routes;
namespace Admin.Web.Presentation.Endpoints.TransactionLimits
{
    public class FindTransactionLimitByIdController : ApiControllerBase
    {
        [Tags("Transaction Limit")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(SRoutes.FindTransactionLimitByIdUrl, Name = SRoutes.FindTransactionLimitByIdName)]
        public async Task<ActionResult> Get(uint id)
        {
            var result = await Mediator.Send(new FindTransactionLimitByIdQuery(id)).ConfigureAwait(false);

            return result.Match(reminder => Ok(result.Value),Problem);
        }
    }

}
