using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.MttPaymentSpeeds
{
    public record GetMttPaymentSpeedsQuery(int PageNumber = 0, int PageSize = 0) : IRequest<ErrorOr<List<MttPaymentSpeed>>>;

    public class GetMttPaymentSpeedsQueryValidator : AbstractValidator<GetMttPaymentSpeedsQuery>
    {
        public GetMttPaymentSpeedsQueryValidator()
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


    public class GetMttPaymentSpeedsQueryHandler
        : MttPaymentSpeedBaseCommand, IRequestHandler<GetMttPaymentSpeedsQuery, ErrorOr<List<MttPaymentSpeed>>>
    {
        private readonly IMTTPaymentSpeedRepository _repository;

        public GetMttPaymentSpeedsQueryHandler(IMTTPaymentSpeedRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<List<MttPaymentSpeed>>> Handle(GetMttPaymentSpeedsQuery request, CancellationToken cancellationToken)
        {
            List<MttPaymentSpeed>? mttPaymentSpeeds;

            if (request.PageNumber > 0 && request.PageSize > 0)
            {
                mttPaymentSpeeds = await _repository.ListPaginatedAsync(request.PageNumber, request.PageSize, cancellationToken);

            }
            else
            {
                mttPaymentSpeeds = await _repository.ListAsync(cancellationToken);

            }

            if (mttPaymentSpeeds == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("MttPaymentSpeed not found"));
            }

            return mttPaymentSpeeds;
        }
    }
}
