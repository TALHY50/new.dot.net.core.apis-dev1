using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.PayerPaymentSpeeds
{
    public record GetPayerPaymentSpeedByIdQuery(uint id) : IRequest<ErrorOr<PayerPaymentSpeed>>;

    public class GetPayerPaymentSpeedByIdQueryValidator : AbstractValidator<GetPayerPaymentSpeedByIdQuery>
    {
        public GetPayerPaymentSpeedByIdQueryValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("PayerPaymentSpeed ID is required");
        }
    }

    public class GetPayerPaymentSpeedByIdQueryHandler : PayerPaymentSpeedBase, IRequestHandler<GetPayerPaymentSpeedByIdQuery, ErrorOr<PayerPaymentSpeed>>
    {
        private readonly IPayerPaymentSpeedRepository _repository;

        public GetPayerPaymentSpeedByIdQueryHandler(IPayerPaymentSpeedRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<PayerPaymentSpeed>> Handle(GetPayerPaymentSpeedByIdQuery request, CancellationToken cancellationToken)
        {
            var payerPaymentSpeed = await _repository.GetByIdAsync(request.id, cancellationToken);

            if (payerPaymentSpeed == null)
            {
                return Error.NotFound(description: "PayerPaymentSpeed not found!", code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }

            return payerPaymentSpeed;
        }
    }
}
