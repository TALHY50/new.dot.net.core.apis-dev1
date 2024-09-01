using Admin.App.Presentation.Routes;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.IMT.Contracts.Contracts.Responses;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Constants.Routes;
using SharedKernel.Main.Application.Common.Interfaces.Services;

namespace Admin.App.Presentation.Endpoints.Country;

public class GetCountryById(ILogger<GetCountryById> logger, ICurrentUserService currentUserService)
    : CountryBase(logger, currentUserService)
{
    [Tags("Countries")]
    //[Authorize(Policy = "HasPermission")]
    [HttpGet(CountryRoutes.GetCountryByIdTemplate, Name = CountryRoutes.GetCountryByIdName)]
    public async Task<IActionResult> GetById(uint Id, CancellationToken cancellationToken)
    {
        var query = new GetCountryByIdQuery(Id);
        _ = Task.Run(
            () => _logger.LogInformation(
                "get-country-by-id-request: {Name} {@UserId} {@Request}",
                nameof(GetCountryByIdQuery),
                _currentUserService.UserId,
                query),
            cancellationToken);
        var result = await Mediator.Send(query).ConfigureAwait(false);
        var response = result.Match(
            country => Ok(ToSuccess(Mapper.Map<CountryDto>(country))),
            Problem);
        _ = Task.Run(
            () => _logger.LogInformation(
                "get-country-by-id-response: {Name} {@UserId} {@Response}",
                nameof(response),
                _currentUserService.UserId,
                response),
            cancellationToken);

        return response;
    }
}