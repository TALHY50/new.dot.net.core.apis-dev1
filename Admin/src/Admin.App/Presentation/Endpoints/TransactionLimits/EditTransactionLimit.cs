using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.TransactionLimits;
using SharedKernel.Main.Presentation;
using SRoutes = SharedKernel.Main.Presentation.Routes.Routes;

namespace Admin.App.Presentation.Endpoints.TransactionLimits
{
    public class EditTransactionLimitController : ApiControllerBase
    {
        [Tags("Transaction Limit")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(SRoutes.UpdateTransactionLimitUrl, Name = SRoutes.UpdateTransactionLimitName)]
        public async Task<ActionResult> Update(uint id, UpdateTransactionLimitCommand command)
        {
            var commandWithId = command with { id = id };
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);

            return result.Match(reminder => Ok(result.Value),Problem);
        }

    }
}

