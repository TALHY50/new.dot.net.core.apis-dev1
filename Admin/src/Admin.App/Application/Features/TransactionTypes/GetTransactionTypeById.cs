using Ardalis.SharedKernel;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.IMT.Entities;

namespace Admin.App.Application.Features.TransactionTypes
{
    public class GetTransactionTypeByIdController : ApiControllerBase
    {
        [Authorize]//(Policy = "HasPermission")]
        [HttpGet(Routes.GetTransactionTypeByIdUrl, Name = Routes.GetTransactionTypeByIdName)]
        public async Task<ActionResult<ErrorOr<TransactionType>>> Get(int id)
        {
            return await Mediator.Send(new GetTransactionTypeByIdQuery(id)).ConfigureAwait(false);
        }

        public record GetTransactionTypeByIdQuery(int Id) : IRequest<ErrorOr<TransactionType>>;


        internal sealed class GetTransactionTypeByIdQueryHandler()
            : IRequestHandler<GetTransactionTypeByIdQuery, ErrorOr<TransactionType>>
        {
            // get all data 
            public Task<ErrorOr<TransactionType>> Handle(GetTransactionTypeByIdQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }

}
