
using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedKernel.Main.Contracts;


namespace ACL.Business.Application.Features.Modules
{
    public record FindModuleByIdQuery(uint id) : IRequest<ErrorOr<Module>>;

    public class FindModuleByIdQueryValidator : AbstractValidator<FindModuleByIdQuery>
    {
        public FindModuleByIdQueryValidator()
        {
            RuleFor(x => x.id).NotEmpty();
        }
    }

    public class FindModuleByIdQueryHandler : ModuleBase,IRequestHandler<FindModuleByIdQuery, ErrorOr<Module>>
    {
        private readonly IModuleRepository _repository;

        public FindModuleByIdQueryHandler(IModuleRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<Module>> Handle(FindModuleByIdQuery request, CancellationToken cancellationToken)
        {
            var module = await _repository.GetByIdAsync(request.id, cancellationToken);

            if (module == null)
            {
                return Error.NotFound(description: Language.GetMessage("Module not found!"), code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }

            return module;
        }
    }
}
