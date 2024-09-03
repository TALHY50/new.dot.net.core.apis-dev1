using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Common.Application.Features.ServiceMethods
{
    public record GetServiceMethodQuery(int PageNumber = 0, int PageSize = 0) : IRequest<ErrorOr<List<ServiceMethod>>>;

    public class GetServiceMethodQueryValidator : AbstractValidator<GetServiceMethodQuery>
    {
        public GetServiceMethodQueryValidator()
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

    public class GetServiceMethodQueryHandler
        : ServiceMethodBase, IRequestHandler<GetServiceMethodQuery, ErrorOr<List<ServiceMethod>>>
    {
        private readonly IServiceMethodRepository _repository;

        public GetServiceMethodQueryHandler(IServiceMethodRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<List<ServiceMethod>>> Handle(GetServiceMethodQuery request, CancellationToken cancellationToken)
        {
            List<ServiceMethod>? serviceMethod;

            if (request.PageNumber > 0 && request.PageSize > 0)
            {
                serviceMethod = await _repository.ListPaginatedAsync(request.PageNumber, request.PageSize, cancellationToken);

            }
            else
            {
                serviceMethod = await _repository.ListAsync(cancellationToken);

            }

            if (serviceMethod == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }

            return serviceMethod;
        }
    }
}
