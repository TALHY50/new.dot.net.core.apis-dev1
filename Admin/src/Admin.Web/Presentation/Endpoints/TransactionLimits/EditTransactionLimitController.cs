﻿using Admin.App.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.TransactionLimits;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;
using SRoutes = SharedKernel.Main.Presentation.Routes.Routes;

namespace Admin.App.Presentation.Endpoints.TransactionLimits
{
    public class EditTransactionLimitController(ILogger<EditTransactionLimitController> logger, ICurrentUser currentUser) : TransactionLimitBaseController(logger, currentUser)
    {
        [Tags("Transaction Limit")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPut(TransactionLimitRoutes.UpdateTransactionLimitTemplate, Name = CountryRoutes.UpdateCountryName)]
        public async Task<IActionResult> Update(uint Id, UpdateTransactionLimitCommand command, CancellationToken cancellationToken)
        {
            var commandWithId = command with { id = Id };
            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-transactionlimit-by-id-request: {Name} {@UserId} {@Request}",
                    nameof(commandWithId),
                    CurrentUser.UserId,
                    commandWithId),
                cancellationToken);
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
            var response = result.Match(
                country => Ok(ToSuccess(Mapper.Map<CountryDto>(country))),
                Problem);

            _ = Task.Run(
                () => _logger.LogInformation(
                    "update-transactionlimit-by-id-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }


   
}
