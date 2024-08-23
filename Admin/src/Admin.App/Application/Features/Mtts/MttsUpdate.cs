using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.IMT.Entities;
using static Admin.App.Application.Features.Mtts.MttsCreate;

namespace Admin.App.Application.Features.Mtts
{
    public class MttsUpdate : ApiControllerBase
    {
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(AdminRoute.EditMttsRouteUrl, Name = AdminRoute.EditMttsRouteName)]
        public async Task<ActionResult<ErrorOr<Mtt>>> Update(CreateMttCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }
    }
}
