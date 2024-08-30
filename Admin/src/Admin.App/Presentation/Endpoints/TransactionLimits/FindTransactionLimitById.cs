
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.TransactionLimits;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;


namespace Admin.App.Presentation.Endpoints.TransactionLimits
{
    public class FindTransactionLimitByIdController : ApiControllerBase
    {
        [Tags("Transaction Limit")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.FindTransactionLimitByIdUrl, Name = Routes.FindTransactionLimitByIdName)]
        public async Task<ActionResult> Get(uint id)
        {
            var result = await Mediator.Send(new FindTransactionLimitByIdQuery(id)).ConfigureAwait(false);

            return result.Match(reminder => Ok(result.Value),Problem);
        }
    }

}
