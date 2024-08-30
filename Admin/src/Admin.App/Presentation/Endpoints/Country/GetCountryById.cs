using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Country.Countries;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;

namespace Admin.App.Presentation.Endpoints.Country;

public class GetCountryById : ApiControllerBase
{
    [Tags("Country")]
    //[Authorize(Policy = "HasPermission")]
    [HttpGet(Routes.GetCountryByIdUrl, Name = Routes.GetCountryByIdName)]
    public async Task<IActionResult> GetById(uint Id)
    {
        var result = await Mediator.Send(new GetCountryByIdQuery(Id)).ConfigureAwait(false);
        return result.Match(
            reminder => Ok(result.Value),
            Problem);
    }
}