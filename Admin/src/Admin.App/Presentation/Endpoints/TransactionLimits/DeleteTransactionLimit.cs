
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.TransactionLimits;
using SharedKernel.Main.Presentation;
using SRoutes = SharedKernel.Main.Presentation.Routes.Routes;

namespace Admin.App.Presentation.Endpoints.TransactionLimits
{
    public class DeleteTransactionLimitController : ApiControllerBase
    {
        [Tags("Transaction Limit")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(SRoutes.DeleteTransactionLimitUrl, Name = SRoutes.DeleteTransactionLimitName)]
        public async Task<ActionResult> Delete(uint id)
        {
            var result = await Mediator.Send(new DeleteTransactionLimitCommand(id)).ConfigureAwait(false);

            return result.Match(reminder => Ok(result.Value),Problem);
        }

    }

}
