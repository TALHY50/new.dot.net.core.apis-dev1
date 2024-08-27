using Ardalis.SharedKernel;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Domain.IMT.Entities;

namespace Admin.App.Application.Features.TransactionTypes
{
    public class GetTransactionTypeController : ApiControllerBase
    {
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetTransactionTypeUrl, Name = Routes.GetTransactionTypeName)]
        public async Task<ActionResult<ErrorOr<List<TransactionType>>>> Get()
        {
            return await Mediator.Send(new GetTransactionTypeQuery()).ConfigureAwait(false);
        }

        public record GetTransactionTypeQuery() : IQuery<ErrorOr<List<TransactionType>>>;

        internal sealed class GetTransactionTypeHandler
            : IQueryHandler<GetTransactionTypeQuery, ErrorOr<List<TransactionType>>>
        {
            private readonly IImtTransactionTypeRepository _transactionTypeRepository;
            public GetTransactionTypeHandler(IImtTransactionTypeRepository transactionTypeRepository)
            {
                _transactionTypeRepository = transactionTypeRepository;
            }
            public Task<ErrorOr<List<TransactionType>>> Handle(GetTransactionTypeQuery request, CancellationToken cancellationToken)
            {
                var transactionTypes = _transactionTypeRepository.All().ToList();
                return Task.FromResult<ErrorOr<List<TransactionType>>>(transactionTypes);
            }
        }
    }
}
