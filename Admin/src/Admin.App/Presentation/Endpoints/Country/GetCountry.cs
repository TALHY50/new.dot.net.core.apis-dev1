using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Country.Countries;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;

namespace Admin.App.Presentation.Endpoints.Country;

public class GetCountry : ApiControllerBase
{
    [Tags("Country")]
    // [Authorize(Policy = "HasPermission")]
    [HttpGet(Routes.GetCountryUrl, Name = Routes.GetCountryName)]
    public async Task<IActionResult> Get()
    {
        var result = await Mediator.Send(new GetCountryQuery()).ConfigureAwait(false);

        return result.Match(
            reminder => Ok(result.Value),
            Problem);
    }
}