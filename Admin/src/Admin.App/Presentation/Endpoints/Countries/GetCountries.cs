using Admin.App.Presentation.Routes;
using ErrorOr;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.IMT.Contracts.Contracts.Responses;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Constants.Routes;
using SharedKernel.Main.Contracts.Common;

namespace Admin.App.Presentation.Endpoints.Country;

public class GetCountries : CountryBase
{
    [Tags("Countries")]
    // [Authorize(Policy = "HasPermission")]
    [HttpGet(CountryRoutes.GetCountryTemplate, Name = CountryRoutes.GetCountryName)]
    public async Task<IActionResult> Get([FromQuery] PaginatorRequest pageRequest)
    {
        var result = await Mediator.Send(new GetCountriesQuery(PageNumber: pageRequest.page_number, PageSize: pageRequest.page_size)).ConfigureAwait(false);

        return result.Match(
            countries => Ok(ToSuccess(countries.Select(country => country.Adapt<CountryDto>()).ToList())),
            Problem
        );

    }
}