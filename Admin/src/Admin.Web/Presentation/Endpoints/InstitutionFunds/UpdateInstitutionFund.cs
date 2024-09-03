using Admin.App.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.InstitutionFunds;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.App.Presentation.Endpoints.InstitutionFunds
{
    public class UpdateInstitutionFund : InstitutionFundBase
    {
        public UpdateInstitutionFund(ILogger<InstitutionFundBase> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }
        [Tags("InstitutionFunds")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(InstitutionFundRoutes.UpdateInstitutionFundTemplate, Name = InstitutionFundRoutes.UpdateInstitutionFundName)]
        [HttpPatch(InstitutionFundRoutes.UpdateInstitutionFundTemplate, Name = InstitutionFundRoutes.UpdateInstitutionFundName)]

        public async Task<IActionResult> Update(uint id, UpdateInstitutionFundCommand command, CancellationToken cancellationToken)
        {
            var commandWithId = command with { id = id };
            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-institution-fund-request: {Name} {@UserId} {@Request}",
                    nameof(commandWithId),
                    CurrentUser.UserId,
                    commandWithId),
                cancellationToken);
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
            var response = result.Match(
                institutionFund => Ok(ToSuccess(Mapper.Map<InstitutionFundDto>(institutionFund))),
                Problem);

            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-institution-fund-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
