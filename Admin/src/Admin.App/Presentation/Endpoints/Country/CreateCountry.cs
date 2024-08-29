using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Country.Countries;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;

namespace Admin.App.Presentation.Endpoints.Country;

public class CreateCountry : ApiControllerBase
{
    [Tags("Country")]
    // [Authorize(Policy = "HasPermission")]
    [HttpPost(Routes.CreateCountryUrl, Name = Routes.CreateCountryName)]

    public async Task<IActionResult> Create(CreateCountryCommand command)
    {
        var result = await Mediator.Send(command).ConfigureAwait(false);

        return result.Match(
            reminder => Ok(result.Value),
            Problem);
    }
}