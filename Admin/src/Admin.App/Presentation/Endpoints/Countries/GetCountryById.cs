using Admin.App.Presentation.Routes;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.IMT.Contracts.Contracts.Responses;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Constants.Routes;

namespace Admin.App.Presentation.Endpoints.Country;

public class GetCountryById : CountryBase
{
    [Tags("Countries")]
    //[Authorize(Policy = "HasPermission")]
    [HttpGet(CountryRoutes.GetCountryByIdTemplate, Name = CountryRoutes.GetCountryByIdName)]
    public async Task<IActionResult> GetById(uint Id)
    {
        var result = await Mediator.Send(new GetCountryByIdQuery(Id)).ConfigureAwait(false);
        return result.Match(
            country => Ok(ToSuccess(Mapper.Map<CountryDto>(country))),
            Problem);
    }
}