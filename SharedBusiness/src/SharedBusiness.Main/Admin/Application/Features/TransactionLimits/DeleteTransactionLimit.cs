
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;


namespace SharedBusiness.Main.Admin.Application.Features.TransactionLimits
{
    
        public record DeleteTransactionLimitCommand(uint id) : IRequest<ErrorOr<bool>>;

        public class DeleteTransactionLimitCommandValidator : AbstractValidator<DeleteTransactionLimitCommand>
        {
            public DeleteTransactionLimitCommandValidator()
            {
                RuleFor(r => r.id).NotEmpty();
            }
        }

        public class DeleteTransactionLimitCommandHandler: IRequestHandler<DeleteTransactionLimitCommand, ErrorOr<bool>>
        {
            private readonly ITransactionLimitRepository _repository;

            public DeleteTransactionLimitCommandHandler(ITransactionLimitRepository repository)
            {
                _repository = repository;
            }

            public async Task<ErrorOr<bool>> Handle(DeleteTransactionLimitCommand request, CancellationToken cancellationToken)
            {
                return  _repository.DeleteById(request.id);
            }
        }
    

}
