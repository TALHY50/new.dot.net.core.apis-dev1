using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Constants.Routes;
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
            private readonly ITransactionTypeRepository _transactionTypeRepository;
            public GetTransactionTypeHandler(ITransactionTypeRepository transactionTypeRepository)
            {
                _transactionTypeRepository = transactionTypeRepository;
            }
            public async Task<ErrorOr<List<TransactionType>>> Handle(GetTransactionTypeQuery request, CancellationToken cancellationToken)
            {
                return _transactionTypeRepository.GetAll().ToList();
            }
        }
    }
}
