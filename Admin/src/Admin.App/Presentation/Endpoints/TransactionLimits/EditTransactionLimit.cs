using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.TransactionLimits;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SRoutes = SharedKernel.Main.Application.Common.Constants.Routes.Routes;

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

