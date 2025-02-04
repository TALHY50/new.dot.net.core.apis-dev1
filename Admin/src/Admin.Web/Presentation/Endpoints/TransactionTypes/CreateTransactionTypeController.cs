﻿using Admin.Web.Presentation.Routes;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Admin.Application.Features.Countries;
using SharedBusiness.Main.Admin.Application.Features.TransactionTypes;
using SharedBusiness.Main.Common.Contracts;
using SharedKernel.Main.Application.Interfaces.Services;

namespace Admin.Web.Presentation.Endpoints.TransactionTypes
{
    public class CreateTransactionTypeController(ILogger<CreateTransactionTypeController> logger, ICurrentUser currentUser)
    : TransactionTypeBaseController(logger, currentUser)
    {
        [Tags("TransactionTypes")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(TransactionTypeRoutes.CreateTransactionTypeTemplate, Name = TransactionTypeRoutes.CreateTransactionTypeName)]

        public async Task<IActionResult> Create(CreateTransactionTypeCommand command, CancellationToken cancellationToken)
        {
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-transactionType-request: {Name} {@UserId} {@Request}",
                    nameof(CreateTransactionTypeCommand),
                    CurrentUser.UserId,
                    command),
                cancellationToken);
            var result = await Mediator.Send(command).ConfigureAwait(false);
            var response = result.Match(
                transactionType => Ok(ToSuccess(Mapper.Map<TransactionTypeDto>(transactionType))),
                Problem);
            _ = Task.Run(
                () => _logger.LogInformation(
                    "create-transactionType-response: {Name} {@UserId} {@Response}",
                    nameof(response),
                    CurrentUser.UserId,
                    response),
                cancellationToken);
            return response;
        }
    }
}
