using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.PayerPaymentSpeeds
{
    public record GetPayerPaymentSpeedsQuery(int PageNumber = 0, int PageSize = 0) : IRequest<ErrorOr<List<PayerPaymentSpeed>>>;

    public class GetPayerPaymentSpeedsQueryValidator : AbstractValidator<GetPayerPaymentSpeedsQuery>
    {
        public GetPayerPaymentSpeedsQueryValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1)
                .When(x => x.PageNumber != 0)
                .WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1)
                .When(x => x.PageNumber > 0)
                .When(x => x.PageSize != 0)
                .WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }

    public class GetPayerPaymentSpeedsQueryHandler
        : PayerPaymentSpeedBase, IRequestHandler<GetPayerPaymentSpeedsQuery, ErrorOr<List<PayerPaymentSpeed>>>
    {
        private readonly IPayerPaymentSpeedRepository _repository;

        public GetPayerPaymentSpeedsQueryHandler(IPayerPaymentSpeedRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<List<PayerPaymentSpeed>>> Handle(GetPayerPaymentSpeedsQuery request, CancellationToken cancellationToken)
        {
            List<PayerPaymentSpeed>? payerPaymentSpeeds;

            if (request.PageNumber > 0 && request.PageSize > 0)
            {
                payerPaymentSpeeds = await _repository.ListPaginatedAsync(request.PageNumber, request.PageSize, cancellationToken);

            }
            else
            {
                payerPaymentSpeeds = await _repository.ListAsync(cancellationToken);

            }

            if (payerPaymentSpeeds == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }

            return payerPaymentSpeeds;
        }
    }
}
