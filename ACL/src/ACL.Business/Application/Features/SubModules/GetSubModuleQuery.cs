using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedKernel.Main.Contracts;


namespace ACL.Business.Application.Features.SubModules
{
    public record GetSubModuleQuery(int PageNumber = 0, int PageSize = 0) : IRequest<ErrorOr<List<SubModule>>>;

    public class GetCountriesQueryValidator : AbstractValidator<GetSubModuleQuery>
    {
        public GetCountriesQueryValidator()
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


    public class GetSubModuleHandler : SubModuleBase, IRequestHandler<GetSubModuleQuery, ErrorOr<List<SubModule>>>
    {
        private readonly ISubModuleRepository _repository;

        public GetSubModuleHandler(ISubModuleRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<List<SubModule>>> Handle(GetSubModuleQuery request, CancellationToken cancellationToken)
        {
            List<SubModule>? submodules;

            if (request.PageNumber > 0 && request.PageSize > 0)
            {
                submodules = await _repository.ListPaginatedAsync(request.PageNumber, request.PageSize, cancellationToken);

            }
            else
            {
                submodules = await _repository.ListAsync(cancellationToken);

            }

            if (submodules == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), description:Language.GetMessage("SubModule not found!"));
            }

            return submodules;
        }
    }

}
