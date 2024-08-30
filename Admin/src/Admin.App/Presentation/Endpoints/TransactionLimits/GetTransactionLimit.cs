
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.TransactionLimits;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;


namespace Admin.App.Presentation.Endpoints.TransactionLimits
{
    public class GetTransactionLimitController : ApiControllerBase
    {
        [Tags("Transaction Limit")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetTransactionLimitUrl, Name = Routes.GetTransactionLimitName)]
        public async Task<ActionResult> Get()
        {
            var result = await Mediator.Send(new GetTransactionLimitQuery()).ConfigureAwait(false);

            return result.Match(reminder => Ok(result.Value),Problem);
        }
    }
}
