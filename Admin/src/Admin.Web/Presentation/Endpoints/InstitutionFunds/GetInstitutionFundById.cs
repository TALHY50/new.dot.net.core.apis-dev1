using Admin.App.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.InstitutionFunds;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.App.Presentation.Endpoints.InstitutionFunds
{
    public class GetInstitutionFundById(ILogger<GetInstitutionFundById> logger, ICurrentUser currentUser)
        : InstitutionFundBase(logger, currentUser)
    {
        [Tags("InstitutionFunds")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(InstitutionFundRoutes.GetInstitutionFundByIdTemplate, Name = InstitutionFundRoutes.GetInstitutionFundByIdName)]
        public async Task<IActionResult> GetById(uint id, CancellationToken cancellationToken)
        {
            var query = new GetInstitutionFundByIdQuery(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-institution-fund-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(GetInstitutionFundByIdQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                institutionFund => Ok(ToSuccess(Mapper.Map<InstitutionFundDto>(institutionFund))),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-institution-fund-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);

            return response;
        }
    }
}
