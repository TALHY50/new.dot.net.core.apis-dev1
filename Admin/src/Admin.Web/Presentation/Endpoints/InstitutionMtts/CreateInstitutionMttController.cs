
using Admin.Web.Presentation.Routes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.InstitutionMtts;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.InstitutionMtts
{
    public class CreateInstitutionMttController(ILogger<CreateInstitutionMttController> logger, ICurrentUser currentUser)
    : InstitutionMttBaseController(logger, currentUser)
    {
        [Tags("InstitutionMtts")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(InstitutionMttRoutes.CreateInstitutionMttTemplate, Name = InstitutionMttRoutes.CreateInstitutionMttName)]
        public async Task<IActionResult> Create(CreateInstitutionMttCommand command, CancellationToken cancellationToken)
        {
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-InstitutionMtt-request: {Name} {@UserId} {@Response}",
                    nameof(CreateInstitutionMttCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                InstitutionMtt => Ok(ToSuccess(Mapper.Map<InstitutionMttDto>(InstitutionMtt))),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-InstitutionMtt-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response), cancellationToken);
            return response;
        }
    }
}
