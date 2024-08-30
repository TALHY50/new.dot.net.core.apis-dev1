﻿
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;


namespace SharedBusiness.Main.Admin.Application.Features.TransactionLimits
{
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
        private readonly ITransactionLimitRepository _repository;

        public FindTransactionLimitByIdQueryHandler(ITransactionLimitRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<TransactionLimit>> Handle(FindTransactionLimitByIdQuery request, CancellationToken cancellationToken)
        {

            return  _repository.FindById(request.id);

        }
    }
}
