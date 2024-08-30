
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.TransactionLimits;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SRoutes = SharedKernel.Main.Application.Common.Constants.Routes.Routes;
namespace Admin.App.Presentation.Endpoints.TransactionLimits
{
    public class CreateTransactionLimitController : ApiControllerBase
    {
        [Tags("Transaction Limit")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(SRoutes.CreateTransactionLimitUrl, Name = SRoutes.CreateTransactionLimitName)]
        public async Task<IActionResult> Create(CreateTransactionLimitCommand command)
        {
            var result = await Mediator.Send(command).ConfigureAwait(false);

            return result.Match(reminder => Ok(result.Value),Problem);
        }
    }

}
