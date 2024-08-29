
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;



namespace Admin.App.Application.Features.TransactionLimits
{
    public class FindTransactionLimitByIdController : ApiControllerBase
    {
        [Tags("Transaction Limit")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.FindTransactionLimitByIdUrl, Name = Routes.FindTransactionLimitByIdName)]
        public async Task<ActionResult<ErrorOr<TransactionLimit>>> Get(uint id)
        {
            var result = await Mediator.Send(new FindTransactionLimitByIdQuery(id)).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }

        public record FindTransactionLimitByIdQuery(uint id) : IRequest<ErrorOr<TransactionLimit>>;

        public class FindTransactionLimitByIdQueryValidator : AbstractValidator<FindTransactionLimitByIdQuery>
        {
            public FindTransactionLimitByIdQueryValidator()
            {
                RuleFor(x => x.id)
                    .NotEmpty()
                    .WithMessage("ID is required");
            }
        }

        public class FindTransactionLimitByIdQueryHandler
            : IRequestHandler<FindTransactionLimitByIdQuery, ErrorOr<TransactionLimit>>
        {
            private readonly IImtTransactionLimitRepository _transactionLimitRepository;

            public FindTransactionLimitByIdQueryHandler(IImtTransactionLimitRepository transactionLimitRepository)
            {
                _transactionLimitRepository = transactionLimitRepository;
            }
            public async Task<ErrorOr<TransactionLimit>> Handle(FindTransactionLimitByIdQuery request, CancellationToken cancellationToken)
            {
                
                    return await _transactionLimitRepository.FindById(request.id);
      
            }
        }
    }
