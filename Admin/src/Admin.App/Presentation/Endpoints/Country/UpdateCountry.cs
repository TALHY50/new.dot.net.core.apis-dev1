using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Country.Countries;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;

namespace Admin.App.Presentation.Endpoints.Country;

public class UpdateCountry : ApiControllerBase
{
    [Tags("Country")]
    //[Authorize(Policy = "HasPermission")]
    [HttpPut(Routes.UpdateCountryUrl, Name = Routes.UpdateCountryName)]

    public async Task<IActionResult> Update(uint Id, UpdateCountryCommand command)
    {
        var commandWithId = command with { Id = Id };
        var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
        return result.Match(
            reminder => Ok(result.Value),
            Problem);
    }

}