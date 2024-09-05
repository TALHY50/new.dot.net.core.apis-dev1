
using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedKernel.Main.Contracts;


namespace ACL.Business.Application.Features.Modules
{
    public record GetModuleQuery(int PageNumber = 0, int PageSize = 0) : IRequest<ErrorOr<List<Module>>>;

    public class GetCountriesQueryValidator : AbstractValidator<GetModuleQuery>
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


    public class GetModuleHandler : ModuleBase, IRequestHandler<GetModuleQuery, ErrorOr<List<Module>>>
    {
        private readonly IModuleRepository _repository;

        public GetModuleHandler(IModuleRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<List<Module>>> Handle(GetModuleQuery request, CancellationToken cancellationToken)
        {
            List<Module>? modules;

            if (request.PageNumber > 0 && request.PageSize > 0)
            {
                modules = await _repository.ListPaginatedAsync(request.PageNumber, request.PageSize, cancellationToken);

            }
            else
            {
                modules = await _repository.ListAsync(cancellationToken);

            }

            if (modules == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), description:Language.GetMessage("Module not found!"));
            }

            return modules;
        }
    }

}
