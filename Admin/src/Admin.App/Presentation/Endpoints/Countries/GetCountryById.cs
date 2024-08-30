using Admin.App.Presentation.Routes;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Constants.Routes;

namespace Admin.App.Presentation.Endpoints.Country;

public class GetCountryById : CountryBase
{
    [Tags("Country")]
    //[Authorize(Policy = "HasPermission")]
    [HttpGet(CountryRoutes.GetCountryByIdTemplate, Name = CountryRoutes.GetCountryByIdName)]
    public async Task<IActionResult> GetById(uint Id)
    {
        var result = await Mediator.Send(new GetCountryByIdQuery(Id)).ConfigureAwait(false);
        return result.Match(
            reminder => Ok(ToSuccess(result.Value)),
            Problem);
    }
}