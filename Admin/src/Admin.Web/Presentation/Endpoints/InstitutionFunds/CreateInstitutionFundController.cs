using Admin.App.Presentation.Endpoints.InstitutionFunds;
using Admin.App.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.InstitutionFunds;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.InstitutionFunds
{
    public class CreateInstitutionFundController(ILogger<CreateInstitutionFundController> logger, ICurrentUser currentUser)
        : InstitutionFundBaseController(logger, currentUser)
    {
        [Tags("InstitutionFunds")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(InstitutionFundRoutes.CreateInstitutionFundTemplate, Name = InstitutionFundRoutes.CreateInstitutionFundName)]

        public async Task<IActionResult> Create(CreateInstitutionFundCommand command, CancellationToken cancellationToken)
        {
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-institution-fund-request: {Name} {@UserId} {@Request}",
                    nameof(CreateInstitutionFundCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                institutionFund => Ok(ToSuccess(Mapper.Map<InstitutionFundDto>(institutionFund))),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-institution-fund-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
