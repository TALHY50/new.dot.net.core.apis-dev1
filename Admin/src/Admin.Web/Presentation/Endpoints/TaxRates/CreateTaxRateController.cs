using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.TaxRates;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.TaxRates
{
    public class CreateTaxRateController(ILogger<CreateTaxRateController> logger, ICurrentUser currentUser)
        : TaxRateBase(logger, currentUser)
    {
        [Tags("TaxRates")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(TaxRateRoutes.CreateTaxRateTemplate, Name = TaxRateRoutes.CreateTaxRateName)]

        public async Task<IActionResult> Create(CreateTaxRateCommand command, CancellationToken cancellationToken)
        {
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-tax-rate-request: {Name} {@UserId} {@Request}",
                    nameof(CreateTaxRateCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                taxRate => Ok(ToSuccess(Mapper.Map<TaxRateDto>(taxRate))),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-tax-rate-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
