using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Country.Countries;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;

namespace Admin.App.Presentation.Endpoints.Country;

public class DeleteCountry : ApiControllerBase
{
    [Tags("Country")]
    //[Authorize(Policy = "HasPermission")]
    [HttpDelete(Routes.DeleteCountryUrl, Name = Routes.DeleteCountryName)]

    public async Task<IActionResult> Delete(uint Id)
    {
        var result = await Mediator.Send(new DeleteCountryCommand(Id)).ConfigureAwait(false);

        return result.Match(
            reminder => Ok(result.Value),
            Problem);
    }
}