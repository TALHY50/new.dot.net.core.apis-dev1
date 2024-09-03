using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Admin.Application.Features.Payers;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;


namespace SharedBusiness.Main.Admin.Application.Features.Payers
{
    public record GetPayerByIdQuery(uint id) : IRequest<ErrorOr<Payer>>;

    public class GetPayerByIdQueryValidator : AbstractValidator<GetPayerByIdQuery>
    {
        public GetPayerByIdQueryValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Payer ID is required");
        }
    }

    public class GetPayerByIdQueryHandler
        : PayerBase, IRequestHandler<GetPayerByIdQuery, ErrorOr<Payer>>
    {
        private readonly IPayerRepository _repository;

        public GetPayerByIdQueryHandler(IPayerRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<Payer>> Handle(GetPayerByIdQuery request, CancellationToken cancellationToken)
        {
            var payer = await _repository.GetByIdAsync(request.id, cancellationToken);

            if (payer == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }

            return payer;
        }
    }
}
