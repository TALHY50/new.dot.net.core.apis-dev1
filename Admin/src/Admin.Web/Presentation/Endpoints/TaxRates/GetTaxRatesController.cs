using Admin.Web.Presentation.Routes;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.TaxRates;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace Admin.Web.Presentation.Endpoints.TaxRates
{
    public class GetTaxRatesController(ILogger<GetTaxRatesController> logger, ICurrentUser currentUser)
        : TaxRateBase(logger, currentUser)
    {
        [Tags("TaxRates")]
        // [Authorize(Policy = "HasPermission")]
        [HttpGet(TaxRateRoutes.GetTaxRateTemplate, Name = TaxRateRoutes.GetTaxRateName)]
        public async Task<IActionResult> Get([FromQuery] PaginatorRequest pageRequest, CancellationToken cancellationToken)
        {
            var query = new GetTaxRatesQuery(PageNumber: pageRequest.page_number, PageSize: pageRequest.page_size);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-tax-rates: {Name} {@UserId} {@Request}",
                    nameof(GetTaxRatesQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                taxRates => Ok(ToSuccess(taxRates.Select(taxRate => taxRate.Adapt<TaxRateDto>()).ToList())),
                Problem
            );
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-tax-rates-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
