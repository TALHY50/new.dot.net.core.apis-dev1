using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Admin.Weblication.Features.Countries;
using SharedBusiness.Main.Common.Application.Features.TransactionTypes;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Weblication.Features.TransactionTypes
{
    public record GetTransactionTypeByIdQuery(uint id) : IRequest<ErrorOr<TransactionType>>;
    public class GetTransactionTypeByIdQueryValidator : AbstractValidator<GetTransactionTypeByIdQuery>
    {
        public GetTransactionTypeByIdQueryValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("TransactionType ID is required");
        }
    }

    public class GetTransactionTypeByIdQueryHandler : TransactionTypeBaseCommand, IRequestHandler<GetTransactionTypeByIdQuery, ErrorOr<TransactionType>>
    {
        private readonly ITransactionTypeRepository _repository;

        public GetTransactionTypeByIdQueryHandler(ITransactionTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<TransactionType>> Handle(GetTransactionTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var transactionType = await _repository.GetByIdAsync(request.id, cancellationToken);

            if (transactionType == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }

            return transactionType;
        }
    }
}
