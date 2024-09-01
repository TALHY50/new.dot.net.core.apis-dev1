using Admin.App.Presentation.Routes;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Constants.Routes;
using SharedKernel.Main.Application.Common.Interfaces.Services;

namespace Admin.App.Presentation.Endpoints.Country;

public class DeleteCountryById : CountryBase
{
    public DeleteCountryById(ILogger<DeleteCountryById> logger, ICurrentUserService currentUserService) : base(logger, currentUserService)
    {
    }

    [Tags("Countries")]
    //[Authorize(Policy = "HasPermission")]
    [HttpDelete(CountryRoutes.DeleteCountryTemplate, Name = CountryRoutes.DeleteCountryName)]

    public async Task<IActionResult> Delete(uint Id, CancellationToken cancellationToken)
    {
        var command = new DeleteCountryByIdCommand(Id);
        Task.Run(
            () => _logger.LogInformation(
                "delete-country-by-id-request: {Name} {@UserId} {@Request}",
                nameof(DeleteCountryByIdCommand),
                _currentUserService.UserId,
                command),
            cancellationToken);
        var result = await Mediator.Send(command).ConfigureAwait(false);
        var response = result.Match(
            isSuccess => Ok(ToSuccess(result.Value)),
            Problem);
        Task.Run(
            () => _logger.LogInformation(
                "delete-country-by-id-response: {Name} {@UserId} {@Response}",
                nameof(response),
                _currentUserService.UserId,
                response),
            cancellationToken);
        return response;
    }

 
}