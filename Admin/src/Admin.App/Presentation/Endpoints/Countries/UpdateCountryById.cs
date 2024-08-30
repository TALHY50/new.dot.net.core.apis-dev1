using Admin.App.Presentation.Routes;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.IMT.Contracts.Contracts.Responses;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Constants.Routes;

namespace Admin.App.Presentation.Endpoints.Country;

public class UpdateCountryById : CountryBase
{
    [Tags("Countries")]
    //[Authorize(Policy = "HasPermission")]
    [HttpPut(CountryRoutes.UpdateCountryTemplate, Name = CountryRoutes.UpdateCountryName)]
    [HttpPatch(CountryRoutes.UpdateCountryTemplate, Name = CountryRoutes.UpdateCountryName)]

    public async Task<IActionResult> Update(uint Id, UpdateCountryByIdCommand command)
    {
        var commandWithId = command with { id = Id };
        var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
        return result.Match(
            country => Ok(ToSuccess(Mapper.Map<CountryDto>(country))),
            Problem);
    }

}