using Admin.App.Presentation.Routes;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Constants.Routes;

namespace Admin.App.Presentation.Endpoints.Country;

public class UpdateCountry : CountryBase
{
    [Tags("Countries")]
    //[Authorize(Policy = "HasPermission")]
    [HttpPut(CountryRoutes.UpdateCountryTemplate, Name = CountryRoutes.UpdateCountryName)]
    [HttpPatch(CountryRoutes.UpdateCountryTemplate, Name = CountryRoutes.UpdateCountryName)]

    public async Task<IActionResult> Update(uint Id, UpdateCountryCommand command)
    {
        var commandWithId = command with { id = Id };
        var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
        return result.Match(
            reminder => Ok(ToSuccess(result.Value)),
            Problem);
    }

}