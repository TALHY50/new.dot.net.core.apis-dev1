using Admin.Web.Presentation.Endpoints.Banks;
using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Banks;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.Banks
{
    public class GetBankByIdController(ILogger<GetBankByIdController> logger, ICurrentUser currentUser)
    : BankBaseController(logger, currentUser)
    {
        [Tags("Banks")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(BankRoutes.GetBankByIdTemplate, Name = BankRoutes.GetBankByIdName)]
        public async Task<IActionResult> GetById(uint id, CancellationToken cancellationToken)
        {
            var query = new GetBankByIdQuery(id);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-bank-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(GetBankByIdQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                bank => Ok(ToSuccess(Mapper.Map<BankDto>(bank))),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-bank-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);

            return response;
        }
    }
}
