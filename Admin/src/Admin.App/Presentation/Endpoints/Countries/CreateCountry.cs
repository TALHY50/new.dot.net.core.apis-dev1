using Admin.App.Presentation.Routes;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.IMT.Contracts.Contracts.Responses;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Constants.Routes;

namespace Admin.App.Presentation.Endpoints.Country;

public class CreateCountry : CountryBase
{
    [Tags("Countries")]
    [Authorize(Policy = "HasPermission")]
    [HttpPost(CountryRoutes.CreateCountryTemplate, Name = CountryRoutes.CreateCountryName)]

    public async Task<IActionResult> Create(CreateCountryCommand command)
    {
        var result = await Mediator.Send(command).ConfigureAwait(false);

        return result.Match(
            country => Ok(ToSuccess(Mapper.Map<CountryDto>(country))),
            Problem);
    }
}