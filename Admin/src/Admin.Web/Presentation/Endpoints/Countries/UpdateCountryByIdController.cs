using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.Country;

public class UpdateCountryByIdController : CountryBase
{
    public UpdateCountryByIdController(ILogger<UpdateCountryByIdController> logger, ICurrentUser currentUser) : base(logger, currentUser)
    {
    }

    [Tags("Countries")]
    //[Authorize(Policy = "HasPermission")]
    [HttpPut(CountryRoutes.UpdateCountryTemplate, Name = CountryRoutes.UpdateCountryName)]
    [HttpPatch(CountryRoutes.UpdateCountryTemplate, Name = CountryRoutes.UpdateCountryName)]

    public async Task<IActionResult> Update(uint Id, UpdateCountryByIdCommand command, CancellationToken cancellationToken)
    {
        var commandWithId = command with { id = Id };
        _ = Task.Run(
            () => _logger.LogInformation(
                "update-country-by-id-request: {Name} {@UserId} {@Request}",
                nameof(commandWithId),
                CurrentUser.UserId,
                commandWithId),
            cancellationToken);
        var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
        var response = result.Match(
            country => Ok(ToSuccess(Mapper.Map<CountryDto>(country))),
            Problem);
        
        _ = Task.Run(
            () => _logger.LogInformation(
                "update-country-by-id-response: {Name} {@UserId} {@Response}",
                nameof(response),
                CurrentUser.UserId,
                response),
            cancellationToken);
        return response;
    }
}