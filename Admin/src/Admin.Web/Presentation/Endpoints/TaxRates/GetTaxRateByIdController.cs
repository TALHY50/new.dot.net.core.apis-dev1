using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.TaxRates;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.TaxRates
{
    public class GetTaxRateByIdController(ILogger<GetTaxRateByIdController> logger, ICurrentUser currentUser)
        : TaxRateBase(logger, currentUser)
    {
        [Tags("TaxRates")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(TaxRateRoutes.GetTaxRateByIdTemplate, Name = TaxRateRoutes.GetTaxRateByIdName)]
        public async Task<IActionResult> GetById(uint id, CancellationToken cancellationToken)
        {
            var query = new GetTaxRateByIdQuery(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-tax-rate-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(GetTaxRateByIdQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                taxRate => Ok(ToSuccess(Mapper.Map<TaxRateDto>(taxRate))),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-tax-rate-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);

            return response;
        }
    }
}
