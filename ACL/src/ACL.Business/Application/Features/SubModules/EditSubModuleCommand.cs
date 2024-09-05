
using ACL.Business.Application.Interfaces.Repositories;
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;
using ACL.Business.Domain.Entities;



namespace ACL.Business.Application.Features.SubModules
{

    public record UpdateSubModuleCommand(uint id, uint module_id, string name, string controller_name, string icon, int sequence, string default_method, string display_name) : IRequest<ErrorOr<SubModule>>;

    public class UpdateSubModuleCommandValidator : AbstractValidator<UpdateSubModuleCommand>
    {
        public UpdateSubModuleCommandValidator()
        {
            RuleFor(x => x.id).GreaterThan((uint)0).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.module_id).GreaterThan((uint)0).NotEmpty().WithMessage("Module Id is required");
            RuleFor(x => x.name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.controller_name).NotEmpty().WithMessage("Controller Name is required");
            RuleFor(x => x.icon).NotEmpty().WithMessage("Icon is required");
            RuleFor(x => x.sequence).GreaterThan(0).NotEmpty().WithMessage("Sequence is required");
            RuleFor(x => x.display_name).NotEmpty().WithMessage("Display Name is required");
            RuleFor(x => x.default_method).NotEmpty().WithMessage("Default method is required");
        }
    }

    public class UpdateSubModuleCommandHandler : SubModuleBase, IRequestHandler<UpdateSubModuleCommand, ErrorOr<SubModule>>
    {
        private readonly ISubModuleRepository _repository;
        private readonly IGuardAgainstNullUpdate _guard;

        public UpdateSubModuleCommandHandler(ISubModuleRepository repository, IGuardAgainstNullUpdate guard)
        {
            _repository = repository;
            _guard = guard;
        }


        public async Task<ErrorOr<SubModule>> Handle(UpdateSubModuleCommand request, CancellationToken cancellationToken)
        {

            bool NameExist = _repository.ExistByName(request.id, request.name);

            if (NameExist)
            {
                return Error.NotFound(description: Language.GetMessage("Name Already Exists."), code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }

            bool ModuleIdExist = _repository.ModuleIdExist(request.module_id);

            if (!ModuleIdExist)
            {
                return Error.NotFound(description: Language.GetMessage("Module Id does not Exists."), code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }

            SubModule? submodule = await _repository.GetByIdAsync(request.id, cancellationToken);
            if (submodule == null)
            {
                return Error.NotFound(description: Language.GetMessage("SubModule not found."),code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }
            
            submodule.ModuleId = request.module_id;
            submodule.ControllerName = request.controller_name;
            submodule.Name =  request.name;
            submodule.Sequence = request.sequence;
            submodule.Icon = request.icon;
            submodule.DisplayName = request.display_name;
            submodule.DefaultMethod = request.default_method;


            submodule.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(submodule, cancellationToken);

            return submodule;


        }
    }

}

