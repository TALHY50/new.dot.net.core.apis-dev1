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
        [Tags("TransactionTypes")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetTransactionTypeUrl, Name = Routes.GetTransactionTypeName)]
        public async Task<ActionResult<ErrorOr<List<TransactionType>>>> Get()
        {
            return await Mediator.Send(new GetTransactionTypeQuery()).ConfigureAwait(false);
        }

        public record GetTransactionTypeQuery() : IRequest<ErrorOr<List<TransactionType>>>;

        internal sealed class GetTransactionTypeHandler
            : IRequestHandler<GetTransactionTypeQuery, ErrorOr<List<TransactionType>>>
        {
            private readonly IImtTransactionTypeRepository _transactionTypeRepository;
            public GetTransactionTypeHandler(IImtTransactionTypeRepository transactionTypeRepository)
            {
                _transactionTypeRepository = transactionTypeRepository;
            }
            public async Task<ErrorOr<List<TransactionType>>> Handle(GetTransactionTypeQuery request, CancellationToken cancellationToken)
            {
                return _transactionTypeRepository.All().ToList();
            }
        }
    }
}
