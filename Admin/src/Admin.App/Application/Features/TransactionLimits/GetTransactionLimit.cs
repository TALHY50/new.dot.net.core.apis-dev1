using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;


namespace Admin.App.Application.Features.TransactionLimits
{
    public class GetTransactionLimitController : ApiControllerBase
    {
        [Tags("Transaction Limit")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetTransactionLimitUrl, Name = Routes.GetTransactionLimitName)]
        public async Task<ActionResult<ErrorOr<List<TransactionLimit>>>> Get()
        {
            var result = await Mediator.Send(new GetTransactionLimitQuery()).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }

        public record GetTransactionLimitQuery() : IRequest<ErrorOr<List<TransactionLimit>>>;

        public class GetTransactionLimitHandler
            : IRequestHandler<GetTransactionLimitQuery, ErrorOr<List<TransactionLimit>>>
        {
            private readonly IImtTransactionLimitRepository _transactionLimitRepository;
            public GetTransactionLimitHandler(IImtTransactionLimitRepository transactionLimitRepository)
            {
                _transactionLimitRepository = transactionLimitRepository;
            }
            public async Task<ErrorOr<List<TransactionLimit>>> Handle(GetTransactionLimitQuery request, CancellationToken cancellationToken)
            {
                return await _transactionLimitRepository.All();
            }
        }
    }
}
