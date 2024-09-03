using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Weblication.Features.Currencies;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.Currencies
{
    public class UpdateCurrencyById : CurrencyBase
    {
        public UpdateCurrencyById(ILogger<UpdateCurrencyById> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }

        [Tags("Currencies")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(CurrencyRoutes.UpdateCurrencyTemplate, Name = CurrencyRoutes.UpdateCurrencyName)]
        [HttpPatch(CurrencyRoutes.UpdateCurrencyTemplate, Name = CurrencyRoutes.UpdateCurrencyName)]

        public async Task<IActionResult> Update(uint id, UpdateCurrencyByIdCommand command, CancellationToken cancellationToken)
        {
            var commandWithId = command with { id = id };
            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-currency-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(commandWithId),
                    CurrentUser.UserId,
                    commandWithId),
                cancellationToken);
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
            var response = result.Match(
                currency => Ok(ToSuccess(Mapper.Map<CurrencyDto>(currency))),
                Problem);

            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-currency-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
