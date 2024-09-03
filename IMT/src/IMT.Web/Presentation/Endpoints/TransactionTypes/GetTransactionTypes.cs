using IMT.App.Presentation.Routes;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Features.TransactionTypes;
using SharedBusiness.Main.IMT.Contracts.Contracts.Responses;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace IMT.App.Presentation.Endpoints.TransactionTypes
{
    public class GetTransactionTypes(ILogger<GetTransactionTypes> logger, ICurrentUser currentUser)
    : TransactionTypeBase(logger, currentUser)
    {
        [Tags("TransactionTypes")]
        // [Authorize(Policy = "HasPermission")]
        [HttpGet(TransactionTypeRoutes.GetTransactionTypeTemplate, Name = TransactionTypeRoutes.GetTransactionTypeName)]

        public async Task<IActionResult> Get([FromQuery] PaginatorRequest pageRequest, CancellationToken cancellationToken)
        {
            var query = new GetTransactionTypesQuery(PageNumber: pageRequest.page_number, PageSize: pageRequest.page_size);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-transactionTypes: {Name} {@UserId} {@Request}",
                    nameof(GetTransactionTypesQuery),
                    CurrentUser.UserId,
                    query),
                cancellationToken);
            var result = await Mediator.Send(query).ConfigureAwait(false);
            var response = result.Match(
                transactionTypes => Ok(ToSuccess(transactionTypes.Select(transactionTypes => transactionTypes.Adapt<TransactionTypeDto>()).ToList())),
                Problem
            );
            _ = Task.Run(
                () => _logger.LogInformation(
                    "get-transactionTypes-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
