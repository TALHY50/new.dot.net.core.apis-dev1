using IMT.App.Presentation.Routes;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Features.Banks;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace IMT.App.Presentation.Endpoints.Banks
{
    public class GetBanks(ILogger<GetBanks> logger, ICurrentUser currentUser)
    : BankBase(logger, currentUser)
    {
        [Tags("Banks")]
        // [Authorize(Policy = "HasPermission")]
        [HttpGet(BankRoutes.GetBankTemplate, Name = BankRoutes.GetBankName)]
        public async Task<IActionResult> Get([FromQuery] PaginatorRequest pageRequest, CancellationToken cancellationToken)
        {
            var query = new GetBanksQuery(PageNumber: pageRequest.page_number, PageSize: pageRequest.page_size);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-banks: {Name} {@UserId} {@Request}",
                    nameof(GetBanksQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                banks => Ok(ToSuccess(banks.Select(bank => bank.Adapt<BankDto>()).ToList())),
                Problem
            );
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-banks-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
