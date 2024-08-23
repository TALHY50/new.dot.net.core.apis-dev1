using Ardalis.SharedKernel;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.IMT.Entities;

namespace Admin.App.Application.Features.TransactionTypes
{
    public class GetTransactionTypeController : ApiControllerBase
    {
        [Authorize]//(Policy = "HasPermission")]
        [HttpGet(Routes.GetTransactionTypeUrl, Name = Routes.GetTransactionTypeName)]
        public async Task<ActionResult<ErrorOr<TransactionType>>> Get()
        {
            return await Mediator.Send(new GetTransactionTypeQuery()).ConfigureAwait(false);
        }

        public record GetTransactionTypeQuery() : IQuery<ErrorOr<TransactionType>>;

        internal sealed class GetTransactionTypeHandler()
            : IQueryHandler<GetTransactionTypeQuery, ErrorOr<TransactionType>>
        {
            // get all data 
            public Task<ErrorOr<TransactionType>> Handle(GetTransactionTypeQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
