using Admin.App.Presentation.Routes;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Constants.Routes;

namespace Admin.App.Presentation.Endpoints.Country;

public class DeleteCountry : CountryBase
{
    [Tags("Countries")]
    //[Authorize(Policy = "HasPermission")]
    [HttpDelete(CountryRoutes.DeleteCountryTemplate, Name = CountryRoutes.DeleteCountryName)]

    public async Task<IActionResult> Delete(uint Id)
    {
        var result = await Mediator.Send(new DeleteCountryCommand(Id)).ConfigureAwait(false);

        return result.Match(
            reminder => Ok(ToSuccess(result.Value)),
            Problem);
    }
}