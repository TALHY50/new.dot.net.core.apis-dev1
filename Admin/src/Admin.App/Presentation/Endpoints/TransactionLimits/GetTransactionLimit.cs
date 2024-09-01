
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.TransactionLimits;
using SharedKernel.Main.Presentation;
using SRoutes = SharedKernel.Main.Presentation.Routes.Routes;
namespace Admin.App.Presentation.Endpoints.TransactionLimits
{
    public class GetTransactionLimitController : ApiControllerBase
    {
        [Tags("Transaction Limit")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(SRoutes.GetTransactionLimitUrl, Name = SRoutes.GetTransactionLimitName)]
        public async Task<ActionResult> Get()
        {
            var result = await Mediator.Send(new GetTransactionLimitQuery()).ConfigureAwait(false);

            return result.Match(reminder => Ok(result.Value),Problem);
        }
    }
}
