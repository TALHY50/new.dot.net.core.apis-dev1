
using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedKernel.Main.Contracts;


namespace ACL.Business.Application.Features.SubModules
{
    public record FindSubModuleByIdQuery(uint id) : IRequest<ErrorOr<SubModule>>;

    public class FindSubModuleByIdQueryValidator : AbstractValidator<FindSubModuleByIdQuery>
    {
        public FindSubModuleByIdQueryValidator()
        {
            RuleFor(x => x.id).NotEmpty();
        }
    }

    public class FindSubModuleByIdQueryHandler : SubModuleBase, IRequestHandler<FindSubModuleByIdQuery, ErrorOr<SubModule>>
    {
        private readonly ISubModuleRepository _repository;

        public FindSubModuleByIdQueryHandler(ISubModuleRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<SubModule>> Handle(FindSubModuleByIdQuery request, CancellationToken cancellationToken)
        {
            var submodule = await _repository.GetByIdAsync(request.id, cancellationToken);

            if (submodule == null)
            {
                return Error.NotFound(description: Language.GetMessage("SubModule not found!"), code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }

            return submodule;
        }
    }
}
