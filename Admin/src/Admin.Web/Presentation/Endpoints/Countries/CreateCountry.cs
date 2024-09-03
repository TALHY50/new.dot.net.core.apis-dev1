using ACL.Business.Application.Interfaces.Services;
using Admin.App.Presentation.Routes;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Infrastructure.Attributes;

namespace Admin.App.Presentation.Endpoints.Country;

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