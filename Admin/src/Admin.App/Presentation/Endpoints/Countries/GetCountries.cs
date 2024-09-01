using Admin.App.Presentation.Routes;
using ErrorOr;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.IMT.Contracts.Contracts.Responses;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Constants.Routes;
using SharedKernel.Main.Application.Common.Interfaces.Services;
using SharedKernel.Main.Contracts.Common;

namespace Admin.App.Presentation.Endpoints.Country;

public class GetCountries : CountryBase
{
    public GetCountries(ILogger<GetCountries> logger, ICurrentUserService currentUserService) : base(logger, currentUserService)
    {
    }

    [Tags("Countries")]
    // [Authorize(Policy = "HasPermission")]
    [HttpGet(CountryRoutes.GetCountryTemplate, Name = CountryRoutes.GetCountryName)]
    public async Task<IActionResult> Get([FromQuery] PaginatorRequest pageRequest, CancellationToken cancellationToken)
    {
        var query = new GetCountriesQuery(PageNumber: pageRequest.page_number, PageSize: pageRequest.page_size);
        Task.Run(
            () => _logger.LogInformation(
                "get-countries: {Name} {@UserId} {@Request}",
                nameof(GetCountriesQuery),
                _currentUserService.UserId,
                query),
            cancellationToken);
        var result = await Mediator.Send(query).ConfigureAwait(false);

        var response = result.Match(
            countries => Ok(ToSuccess(countries.Select(country => country.Adapt<CountryDto>()).ToList())),
            Problem
        );
        
        Task.Run(
            () => _logger.LogInformation(
                "get-countries-response: {Name} {@UserId} {@Response}",
                nameof(response),
                _currentUserService.UserId,
                response),
            cancellationToken);

        return response;

    }

   
}