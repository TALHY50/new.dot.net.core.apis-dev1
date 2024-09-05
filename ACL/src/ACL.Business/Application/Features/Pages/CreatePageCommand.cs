
using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedKernel.Main.Contracts;



namespace ACL.Business.Application.Features.Pages
{
    public record CreatePageCommand(uint id, uint module_id,uint submodule_id, string name, string method_name, int method_type, sbyte available_to_company) : IRequest<ErrorOr<Page>>;

    public class CreatePageCommandValidator : AbstractValidator<CreatePageCommand>
    {
        public CreatePageCommandValidator()
        {
            RuleFor(x => x.id).GreaterThan((uint)0).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.module_id).GreaterThan((uint)0).NotEmpty().WithMessage("Module Id is required");
            RuleFor(x => x.submodule_id).GreaterThan((uint)0).NotEmpty().WithMessage("SubModule Id is required");
            RuleFor(x => x.name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.method_name).NotEmpty().WithMessage("Controller Name is required");
            RuleFor(x => x.method_type).GreaterThan(0).NotEmpty().WithMessage("Method Type is required");
            RuleFor(x => x.available_to_company);

        }
    }

    public class CreatePageCommandHandler : PageBase, IRequestHandler<CreatePageCommand, ErrorOr<Page>>
    {
        private readonly IPageRepository _repository;
        
        public CreatePageCommandHandler(IPageRepository repository)
        {
            _repository = repository;
        }


        public async Task<ErrorOr<Page>> Handle(CreatePageCommand request, CancellationToken cancellationToken)
        {
            var page = new Page
            {
                Id = request.id,
                ModuleId = request.module_id,
                SubModuleId = request.submodule_id,
                MethodName = request.name,
                MethodType = request.method_type,
                Name = request.name,
                AvailableToCompany = request.available_to_company,



                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            bool IdExist = _repository.IsExist(request.id);

            if (IdExist)
            {
                return Error.NotFound(description: Language.GetMessage("Id Already Exists."), code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }

            bool ModuleIdExist = _repository.IsModuleIdExist(request.module_id);

            if (!ModuleIdExist)
            {
                return Error.NotFound(description: Language.GetMessage("Module Id does not Exists."), code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }

            bool SubModuleIdExist = _repository.IsSubModuleIdExist(request.submodule_id);

            if (!SubModuleIdExist)
            {
                return Error.NotFound(description: Language.GetMessage("SubModule Id does not Exists."), code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }


            var result = await _repository.AddAsync(page, cancellationToken);

            return result;



        }
    }
}
