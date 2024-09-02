using Admin.App.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;
using CountryBase = IMT.App.Presentation.Endpoints.Countries.CountryBase;

namespace IMT.App.Presentation.Endpoints.Countries;

public class CreateCountry(ILogger<CreateCountry> logger, ICurrentUser currentUser)
    : CountryBase(logger, currentUser)
{
    [Tags("Countries")]
    //[Authorize(Policy = "HasPermission")]
    [HttpPost(CountryRoutes.CreateCountryTemplate, Name = CountryRoutes.CreateCountryName)]
  
    public async Task<IActionResult> Create(CreateCountryCommand command, CancellationToken cancellationToken)
    { 
        _ = Task.Run(
            () => _logger.LogInformation(
                "create-country-request: {Name} {@UserId} {@Request}",
                nameof(CreateCountryCommand),
                CurrentUser.UserId,
                command),
            cancellationToken);
        var result = await Mediator.Send(command).ConfigureAwait(false);
        var c = result.Value;
        var response = result.Match(
            country => Ok(ToSuccess(Mapper.Map<CountryDto>(country))),
            Problem);
        _ = Task.Run(
            () => _logger.LogInformation(
                "create-country-response: {Name} {@UserId} {@Response}",
                nameof(response),
                CurrentUser.UserId,
                response),
            cancellationToken);
        return response;
    }
}