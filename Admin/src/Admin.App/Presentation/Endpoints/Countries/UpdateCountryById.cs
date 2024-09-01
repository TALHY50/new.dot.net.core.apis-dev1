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

public class UpdateCountryById : CountryBase
{
    public UpdateCountryById(ILogger<UpdateCountryById> logger, ICurrentUserService currentUserService) : base(logger, currentUserService)
    {
    }

    [Tags("Countries")]
    //[Authorize(Policy = "HasPermission")]
    [HttpPut(CountryRoutes.UpdateCountryTemplate, Name = CountryRoutes.UpdateCountryName)]
    [HttpPatch(CountryRoutes.UpdateCountryTemplate, Name = CountryRoutes.UpdateCountryName)]

    public async Task<IActionResult> Update(uint Id, UpdateCountryByIdCommand command, CancellationToken cancellationToken)
    {
        var commandWithId = command with { id = Id };
        Task.Run(
            () => _logger.LogInformation(
                "update-country-by-id-request: {Name} {@UserId} {@Request}",
                nameof(commandWithId),
                _currentUserService.UserId,
                commandWithId),
            cancellationToken);
        var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
        var response = result.Match(
            country => Ok(ToSuccess(Mapper.Map<CountryDto>(country))),
            Problem);
        Task.Run(
            () => _logger.LogInformation(
                "update-country-by-id-response: {Name} {@UserId} {@Response}",
                nameof(response),
                _currentUserService.UserId,
                response),
            cancellationToken);
        return response;
    }

   
}