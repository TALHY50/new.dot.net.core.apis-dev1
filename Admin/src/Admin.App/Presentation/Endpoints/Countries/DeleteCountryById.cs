using Admin.App.Presentation.Routes;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Constants.Routes;

namespace Admin.App.Presentation.Endpoints.Country;

public class DeleteCountryById : CountryBase
{
    [Tags("Countries")]
    //[Authorize(Policy = "HasPermission")]
    [HttpDelete(CountryRoutes.DeleteCountryTemplate, Name = CountryRoutes.DeleteCountryName)]

    public async Task<IActionResult> Delete(uint Id)
    {
        var result = await Mediator.Send(new DeleteCountryByIdCommand(Id)).ConfigureAwait(false);

        return result.Match(
            isSuccess => Ok(ToSuccess(result.Value)),
            Problem);
    }
}