using Admin.Web.Presentation.Routes;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.Country;

public class GetCountryByIdController(ILogger<GetCountryByIdController> logger, ICurrentUser currentUser)
    : CountryBase(logger, currentUser)
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
                CurrentUser.UserId,
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
                CurrentUser.UserId,
                response),
            cancellationToken);

        return response;
    }
}