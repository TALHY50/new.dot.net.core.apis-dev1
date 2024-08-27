using Ardalis.SharedKernel;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Domain.IMT.Entities;
using static Admin.App.Application.Features.Mtts.MttView;

namespace Admin.App.Application.Features.TransactionTypes
{
    public class GetTransactionTypeByIdController : ApiControllerBase
    {
        [Tags("TransactionTypes")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetTransactionTypeByIdUrl, Name = Routes.GetTransactionTypeByIdName)]
        public async Task<ActionResult<ErrorOr<TransactionType>>> Get(uint id)
        {
            return await Mediator.Send(new GetTransactionTypeByIdQuery(id)).ConfigureAwait(false);
        }

        public record GetTransactionTypeByIdQuery(uint id) : IRequest<ErrorOr<TransactionType>>;

        internal sealed class GetTransactionTypeByIdQueryValidator : AbstractValidator<GetTransactionTypeByIdQuery>
        {
            public GetTransactionTypeByIdQueryValidator()
            {
                RuleFor(x => x.id).NotEmpty().WithMessage("TransactionType ID is required");
            }
        }

        internal sealed class GetTransactionTypeByIdQueryHandler
            : IRequestHandler<GetTransactionTypeByIdQuery, ErrorOr<TransactionType>>
        {
            private readonly IImtTransactionTypeRepository _transactionTypeRepository;

            public GetTransactionTypeByIdQueryHandler(IImtTransactionTypeRepository transactionTypeRepository)
            {
                _transactionTypeRepository = transactionTypeRepository;
            }
            public async Task<ErrorOr<TransactionType>> Handle(GetTransactionTypeByIdQuery request, CancellationToken cancellationToken)
            {
                return _transactionTypeRepository.GetByUintId(request.id);
            }
        }
    }

}
