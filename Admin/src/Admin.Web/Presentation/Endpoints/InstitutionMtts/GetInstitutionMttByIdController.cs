
using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedBusiness.Main.Common.Contracts;
using SharedBusiness.Main.Admin.Application.Features.InstitutionMtts;
namespace Admin.Web.Presentation.Endpoints.InstitutionMtts
{
    public class GetInstitutionMttByIdController(ILogger<GetInstitutionMttByIdController> logger, ICurrentUser currentUser)
    : InstitutionMttBaseController(logger, currentUser)
    {
        [Tags("InstitutionMtts")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(InstitutionMttRoutes.GetInstitutionMttByIdTemplate, Name = InstitutionMttRoutes.GetInstitutionMttByIdName)]
        public async Task<IActionResult> GetById(uint id, CancellationToken cancellationToken)
        {
            var query = new GetInstitutionMttByIdQuery(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-InstitutionMtt-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(GetInstitutionMttByIdQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                institutionMtt => Ok(ToSuccess(Mapper.Map<InstitutionMttDto>(institutionMtt))),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-InstitutionMtt-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);

            return response;
        }
    }
}
