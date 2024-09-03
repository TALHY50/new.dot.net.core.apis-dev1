using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Repositories;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.MttPaymentSpeeds
{
    public record GetMttPaymentSpeedByIdQuery(uint id) : IRequest<ErrorOr<MttPaymentSpeed>>;

    public class GetMttPaymentSpeedByIdQueryValidator : AbstractValidator<GetMttPaymentSpeedByIdQuery>
    {
        public GetMttPaymentSpeedByIdQueryValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("MttPaymentSpeed ID is required");
        }
    }


    public class GetMttPaymentSpeedByIdQueryHandler : MttPaymentSpeedBaseCommand, IRequestHandler<GetMttPaymentSpeedByIdQuery, ErrorOr<MttPaymentSpeed>>
    {
        private readonly IMTTPaymentSpeedRepository _repository;

        public GetMttPaymentSpeedByIdQueryHandler(IMTTPaymentSpeedRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<MttPaymentSpeed>> Handle(GetMttPaymentSpeedByIdQuery request, CancellationToken cancellationToken)
        {
            var mttPaymentSpeed = await _repository.GetByIdAsync(request.id, cancellationToken);

            if (mttPaymentSpeed == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }

            return mttPaymentSpeed;
        }
    }
}
