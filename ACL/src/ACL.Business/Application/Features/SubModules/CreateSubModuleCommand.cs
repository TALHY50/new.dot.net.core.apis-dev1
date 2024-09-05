
using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedKernel.Main.Contracts;



namespace ACL.Business.Application.Features.SubModules
{
    public record CreateSubModuleCommand(uint id, uint module_id, string name, string controller_name, string icon, int sequence, string default_method, string display_name) : IRequest<ErrorOr<SubModule>>;

    public class CreateSubModuleCommandValidator : AbstractValidator<CreateSubModuleCommand>
    {
        public CreateSubModuleCommandValidator()
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

    public class CreateSubModuleCommandHandler : SubModuleBase, IRequestHandler<CreateSubModuleCommand, ErrorOr<SubModule>>
    {
        private readonly ISubModuleRepository _repository;
        
        public CreateSubModuleCommandHandler(ISubModuleRepository repository)
        {
            _repository = repository;
        }


        public async Task<ErrorOr<SubModule>> Handle(CreateSubModuleCommand request, CancellationToken cancellationToken)
        {
            var subModule = new SubModule
            {
                Id = request.id,
                ModuleId = request.module_id,
                Name = request.name,
                ControllerName = request.controller_name,
                DisplayName = request.display_name,
                Icon = request.icon,
                Sequence = request.sequence,
                DefaultMethod = request.default_method,

                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            bool IdExist = _repository.ExistById(null,request.id);

            if (IdExist)
            {
                return Error.NotFound(description: Language.GetMessage("Id Already Exists."), code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }

            bool ModuleIdExist = _repository.ModuleIdExist(request.module_id);

            if (!ModuleIdExist)
            {
                return Error.NotFound(description: Language.GetMessage("Module Id does not Exists."), code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }


            bool NameExist = _repository.ExistByName(null, request.name);

            if (NameExist)
            {
                return Error.NotFound(description: Language.GetMessage("Name Already Exists."), code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }


            var result = await _repository.AddAsync(subModule, cancellationToken);

            return result;



        }
    }
}
