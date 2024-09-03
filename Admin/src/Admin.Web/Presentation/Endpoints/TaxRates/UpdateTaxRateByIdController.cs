using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.TaxRates;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.TaxRates
{
    public class UpdateTaxRateByIdController : TaxRateBase
    {
        public UpdateTaxRateByIdController(ILogger<TaxRateBase> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }
        [Tags("TaxRates")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(TaxRateRoutes.UpdateTaxRateTemplate, Name = TaxRateRoutes.UpdateTaxRateName)]
        [HttpPatch(TaxRateRoutes.UpdateTaxRateTemplate, Name = TaxRateRoutes.UpdateTaxRateName)]

        public async Task<IActionResult> Update(uint id, UpdateTaxRateByIdCommand command, CancellationToken cancellationToken)
        {
            var commandWithId = command with { id = id };
            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-tax-rate-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(commandWithId),
                    CurrentUser.UserId,
                    commandWithId),
                cancellationToken);
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
            var response = result.Match(
                taxRate => Ok(ToSuccess(Mapper.Map<TaxRateDto>(taxRate))),
                Problem);

            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-tx-rate-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
