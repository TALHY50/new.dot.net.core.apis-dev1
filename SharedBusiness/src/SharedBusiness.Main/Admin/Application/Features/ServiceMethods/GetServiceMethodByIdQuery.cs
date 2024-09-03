using ErrorOr;
using FluentValidation;
using MediatR;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;

namespace SharedBusiness.Main.Admin.Application.Features.ServiceMethods
{
    public record GetServiceMethodByIdQuery(uint id) : IRequest<ErrorOr<ServiceMethod>>;

    public class GetServiceMethodByIdQueryValidator : AbstractValidator<GetServiceMethodByIdQuery>
    {
        public GetServiceMethodByIdQueryValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("ServiceMethod ID is required");
        }
    }

    public class GetServiceMethodByIdQueryHandler : ServiceMethodBase, IRequestHandler<GetServiceMethodByIdQuery, ErrorOr<ServiceMethod>>
    {
        private readonly IServiceMethodRepository _repository;

        public GetServiceMethodByIdQueryHandler(IServiceMethodRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<ServiceMethod>> Handle(GetServiceMethodByIdQuery request, CancellationToken cancellationToken)
        {
            var serviceMethod = await _repository.GetByIdAsync(request.id, cancellationToken);

            if (serviceMethod == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Record not found"));
            }

            return serviceMethod;
        }
    }
}
