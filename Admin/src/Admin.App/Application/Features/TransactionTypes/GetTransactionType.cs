using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Admin.App.Application.Features.TransactionTypes
{
    public class GetTransactionTypeController : ApiControllerBase
    {
        [Tags("TransactionTypes")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetTransactionTypeUrl, Name = Routes.GetTransactionTypeName)]
        public async Task<ActionResult<ErrorOr<List<TransactionType>>>> Get()
        {
            var result = await Mediator.Send(new GetTransactionTypeQuery()).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }

        public record GetTransactionTypeQuery() : IRequest<ErrorOr<List<TransactionType>>>;

        public class GetTransactionTypeHandler
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
