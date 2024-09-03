
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;


namespace SharedBusiness.Main.Admin.Application.Features.TransactionLimits
{
    public record FindTransactionLimitByIdQuery(uint id) : IRequest<ErrorOr<TransactionLimit>>;

    public class FindTransactionLimitByIdQueryValidator : AbstractValidator<FindTransactionLimitByIdQuery>
    {
        public FindTransactionLimitByIdQueryValidator()
        {
            RuleFor(x => x.id).NotEmpty();
        }
    }

    public class FindTransactionLimitByIdQueryHandler
        : IRequestHandler<FindTransactionLimitByIdQuery, ErrorOr<TransactionLimit>>
    {
        private readonly ITransactionLimitRepository _repository;

        public FindTransactionLimitByIdQueryHandler(ITransactionLimitRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<Common.Domain.Entities.TransactionLimit>> Handle(FindTransactionLimitByIdQuery request, CancellationToken cancellationToken)
        {
            var transactionLimit = await _repository.GetByIdAsync(request.id, cancellationToken);

            if (transactionLimit == null)
            {
                return Error.NotFound(description: Language.GetMessage("Trasaction limit not found!"), code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }

            return transactionLimit;
        }
    }
}
