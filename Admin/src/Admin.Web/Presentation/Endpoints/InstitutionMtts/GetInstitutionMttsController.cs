using Admin.Web.Presentation.Endpoints.InstitutionMtts;
using Admin.Web.Presentation.Routes;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.InstitutionMtts;
using SharedBusiness.Main.Admin.Application.Features.Payers;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace Admin.Web.Presentation.Endpoints.InstitutionMtts
{
    public class GetInstitutionMttsController(ILogger<GetInstitutionMttsController> logger, ICurrentUser currentUser)
    : InstitutionMttBaseController(logger, currentUser)
    {
        [Tags("InstitutionMtts")]
        // [Authorize(Policy = "HasPermission")]
        [HttpGet(InstitutionMttRoutes.GetInstitutionMttTemplate, Name = InstitutionMttRoutes.GetInstitutionMttName)]
        public async Task<IActionResult> Get([FromQuery] PaginatorRequest pageRequest, CancellationToken cancellationToken)
        {
            var query = new GetInstitutionMttsQuery(PageNumber: pageRequest.page_number, PageSize: pageRequest.page_size);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-InstitutionMtts: {Name} {@UserId} {@Request}",
                    nameof(GetInstitutionMttsQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                institutionMtts => Ok(ToSuccess(institutionMtts.Select(institutionMtt => institutionMtt.Adapt<InstitutionMttDto>()).ToList())),
                Problem
            );
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-InstitutionMtts-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
