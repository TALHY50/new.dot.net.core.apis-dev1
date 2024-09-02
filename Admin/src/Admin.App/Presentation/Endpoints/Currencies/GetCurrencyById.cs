using Admin.App.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Currencies;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.App.Presentation.Endpoints.Currencies
{
    public class GetCurrencyById(ILogger<GetCurrencyById> logger, ICurrentUser currentUser)
    : CurrencyBase(logger, currentUser)
    {
        [Tags("Currencies")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(CurrencyRoutes.GetCurrencyByIdTemplate, Name = CurrencyRoutes.GetCurrencyByIdName)]
        public async Task<IActionResult> GetById(uint id, CancellationToken cancellationToken)
        {
            var query = new GetCurrencyByIdQuery(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-Currency-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(GetCurrencyByIdQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                Currency => Ok(ToSuccess(Mapper.Map<CurrencyDto>(Currency))),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-Currency-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);

            return response;
        }
    }
}
