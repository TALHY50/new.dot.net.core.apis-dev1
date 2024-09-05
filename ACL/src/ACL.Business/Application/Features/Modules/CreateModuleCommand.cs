
using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedKernel.Main.Contracts;



namespace ACL.Business.Application.Features.Modules
{
    public record CreateModuleCommand(uint id, string name, string icon, int sequence, string display_name) : IRequest<ErrorOr<Module>>;

    public class CreateCreateModuleCommandValidator : AbstractValidator<CreateModuleCommand>
    {
        public CreateCreateModuleCommandValidator()
        {
            RuleFor(x => x.id).GreaterThan((uint)0).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.icon).NotEmpty().WithMessage("Icon is required");
            RuleFor(x => x.sequence).GreaterThan(0).NotEmpty().WithMessage("Sequence is required");
            RuleFor(x => x.display_name).NotEmpty().WithMessage("Display Name is required");
        }
    }

    public class CreateModuleCommandHandler : IRequestHandler<CreateModuleCommand, ErrorOr<Module>>
    {
        private readonly IModuleRepository _repository;

        public CreateModuleCommandHandler(IModuleRepository repository)
        {
            _repository = repository;
        }


        public async Task<ErrorOr<Module>> Handle(CreateModuleCommand request, CancellationToken cancellationToken)
        {
            var Module = new Module
            {
                Id = request.id,
                DisplayName = request.display_name,
                Icon = request.icon,
                Name = request.name,
                Sequence = request.sequence,

                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            bool IdExist = _repository.ExistById(null,request.id);

            if (IdExist)
            {
                return Error.NotFound(description: Language.GetMessage("Id Already Exists."), code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }


            bool NameExist = _repository.ExistByName(null, request.name);

            if (NameExist)
            {
                return Error.NotFound(description: Language.GetMessage("Name Already Exists."), code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }


            var result = await _repository.AddAsync(Module, cancellationToken);

            return result;



        }
    }
}
