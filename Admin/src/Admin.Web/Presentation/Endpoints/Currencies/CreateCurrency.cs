using Admin.App.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Currencies;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.App.Presentation.Endpoints.Currencies
{
    public class CreateCurrency(ILogger<CreateCurrency> logger, ICurrentUser currentUser)
    : CurrencyBase(logger, currentUser)
    {
        [Tags("Currencies")]
        [HttpPost(CurrencyRoutes.CreateCurrencyTemplate, Name = CurrencyRoutes.CreateCurrencyName)]

        public async Task<IActionResult> Create(CreateCurrencyCommand command, CancellationToken cancellationToken)
        {
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-currency-request: {Name} {@UserId} {@Request}",
                    nameof(CreateCurrencyCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                Currency => Ok(ToSuccess(Mapper.Map<CurrencyDto>(Currency))),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-currency-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
