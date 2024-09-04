using Admin.Web.Presentation.Endpoints.InstitutionFunds;
using Admin.Web.Presentation.Routes;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.InstitutionFunds;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace Admin.Web.Presentation.Endpoints.InstitutionFunds
{
    public class GetInstitutionFundsController(ILogger<GetInstitutionFundsController> logger, ICurrentUser currentUser)
        : InstitutionFundBaseController(logger, currentUser)
    {
        [Tags("InstitutionFunds")]
        // [Authorize(Policy = "HasPermission")]
        [HttpGet(InstitutionFundRoutes.GetInstitutionFundTemplate, Name = InstitutionFundRoutes.GetInstitutionFundName)]
        public async Task<IActionResult> Get([FromQuery] PaginatorRequest pageRequest, CancellationToken cancellationToken)
        {
            var query = new GetInstitutionFundsQuery(PageNumber: pageRequest.page_number, PageSize: pageRequest.page_size);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-institution-fund: {Name} {@UserId} {@Request}",
                    nameof(GetInstitutionFundsQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                institutionFunds => Ok(ToSuccess(institutionFunds.Select(institutionFund => institutionFund.Adapt<InstitutionFundDto>()).ToList())),
                Problem
            );
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-institution-fund-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
