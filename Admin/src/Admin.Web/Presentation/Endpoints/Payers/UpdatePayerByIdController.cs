using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Payers;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.Payers
{
    public class UpdatePayerByIdController : PayerBaseController
    {
        public UpdatePayerByIdController(ILogger<UpdatePayerByIdController> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }

        [Tags("Payers")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(PayerRoutes.UpdatePayerTemplate, Name = PayerRoutes.UpdatePayerName)]
        [HttpPatch(PayerRoutes.UpdatePayerTemplate, Name = PayerRoutes.UpdatePayerName)]

        public async Task<IActionResult> Update(uint id, UpdatePayerByIdCommand command, CancellationToken cancellationToken)
        {
            var commandWithId = command with { id = id };
            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-payer-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(commandWithId),
                    CurrentUser.UserId,
                    commandWithId),
                cancellationToken);
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
            var response = result.Match(
                payer => Ok(ToSuccess(Mapper.Map<PayerDto>(payer))),
                Problem);

            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-payer-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
