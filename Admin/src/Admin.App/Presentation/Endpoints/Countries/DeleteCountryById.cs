using Admin.App.Presentation.Routes;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.App.Presentation.Endpoints.Country;

public class DeleteCountryById(ILogger<DeleteCountryById> logger, ICurrentUser currentUser)
    : CountryBase(logger, currentUser)
{
    [Tags("Countries")]
    //[Authorize(Policy = "HasPermission")]
    [HttpDelete(CountryRoutes.DeleteCountryTemplate, Name = CountryRoutes.DeleteCountryName)]

    public async Task<IActionResult> Delete(uint Id, CancellationToken cancellationToken)
    {
        var command = new DeleteCountryByIdCommand(Id);
        _ = Task.Run(
            () => _logger.LogInformation(
                "delete-country-by-id-request: {Name} {@UserId} {@Request}",
                nameof(DeleteCountryByIdCommand),
                CurrentUser.UserId,
                command),
            cancellationToken);
        var result = await Mediator.Send(command).ConfigureAwait(false);
        var response = result.Match(
            isSuccess => Ok(ToSuccess(result.Value)),
            Problem);
        _ = Task.Run(
            () => _logger.LogInformation(
                "delete-country-by-id-response: {Name} {@UserId} {@Response}",
                nameof(response),
                CurrentUser.UserId,
                response),
            cancellationToken);
        return response;
    }

 
}