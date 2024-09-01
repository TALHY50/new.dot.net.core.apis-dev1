using Admin.App.Presentation.Routes;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.IMT.Contracts.Contracts.Responses;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Constants.Routes;
using SharedKernel.Main.Application.Common.Interfaces.Services;

namespace Admin.App.Presentation.Endpoints.Country;

public class CreateCountry(ILogger<CreateCountry> logger, ICurrentUserService currentUserService)
    : CountryBase(logger, currentUserService)
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
                _currentUserService.UserId,
                command),
            cancellationToken);
        var result = await Mediator.Send(command).ConfigureAwait(false);
        var response = result.Match(
            country => Ok(ToSuccess(Mapper.Map<CountryDto>(country))),
            Problem);
        _ = Task.Run(
            () => _logger.LogInformation(
                "create-country-response: {Name} {@UserId} {@Response}",
                nameof(response),
                _currentUserService.UserId,
                response),
            cancellationToken);
        return response;
    }
}