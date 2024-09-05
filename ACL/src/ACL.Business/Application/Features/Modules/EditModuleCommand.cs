
using ACL.Business.Application.Interfaces.Repositories;
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;
using ACL.Business.Domain.Entities;



namespace ACL.Business.Application.Features.Modules
{

    public record UpdateModuleCommand(uint id, string name, string icon, int sequence, string display_name) : IRequest<ErrorOr<Module>>;

    public class UpdateModuleCommandValidator : AbstractValidator<UpdateModuleCommand>
    {
        public UpdateModuleCommandValidator()
        {
            RuleFor(x => x.id).GreaterThan((uint)0).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.icon).NotEmpty().WithMessage("Icon is required");
            RuleFor(x => x.sequence).GreaterThan(0).NotEmpty().WithMessage("Sequence is required");
            RuleFor(x => x.display_name).NotEmpty().WithMessage("Display Name is required");
        }
    }

    public class UpdateModuleCommandHandler : IRequestHandler<UpdateModuleCommand, ErrorOr<Module>>
    {
        private readonly IModuleRepository _repository;
        private readonly IGuardAgainstNullUpdate _guard;

        public UpdateModuleCommandHandler(IModuleRepository repository, IGuardAgainstNullUpdate guard)
        {
            _repository = repository;
            _guard = guard;
        }


        public async Task<ErrorOr<Module>> Handle(UpdateModuleCommand request, CancellationToken cancellationToken)
        {

            bool ModuleNameExist = _repository.ExistByName(request.id, request.name);

            if (ModuleNameExist)
            {
                return Error.NotFound(description: Language.GetMessage("Name Already Exists."), code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }

            Module? module = await _repository.GetByIdAsync(request.id, cancellationToken);
            if (module == null)
            {
                return Error.NotFound(description: Language.GetMessage("Module not found."),
                    code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }

            module.Name =  request.name;
            module.Sequence = request.sequence;
            module.Icon = request.icon;
            module.DisplayName = request.display_name;
            module.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(module, cancellationToken);

            return module;


        }
    }

}

