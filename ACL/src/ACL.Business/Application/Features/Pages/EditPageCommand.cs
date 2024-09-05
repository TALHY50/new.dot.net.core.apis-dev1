
using ACL.Business.Application.Interfaces.Repositories;
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;
using ACL.Business.Domain.Entities;



namespace ACL.Business.Application.Features.Pages
{

    public record UpdatePageCommand(uint id, uint module_id, uint submodule_id, string name, string method_name, int method_type, sbyte available_to_company) : IRequest<ErrorOr<Page>>;

    public class UpdatePageCommandValidator : AbstractValidator<UpdatePageCommand>
    {
        public UpdatePageCommandValidator()
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

    public class UpdatePageCommandHandler : PageBase, IRequestHandler<UpdatePageCommand, ErrorOr<Page>>
    {
        private readonly IPageRepository _repository;
        private readonly IGuardAgainstNullUpdate _guard;

        public UpdatePageCommandHandler(IPageRepository repository, IGuardAgainstNullUpdate guard)
        {
            _repository = repository;
            _guard = guard;
        }


        public async Task<ErrorOr<Page>> Handle(UpdatePageCommand request, CancellationToken cancellationToken)
        {
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

            Page? page = await _repository.GetByIdAsync(request.id, cancellationToken);
            if (page == null)
            {
                return Error.NotFound(description: Language.GetMessage("Page not found."),code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }

            page.ModuleId = request.module_id;
            page.SubModuleId = request.submodule_id;
            page.Name =  request.name;
            page.MethodName = request.method_name;
            page.AvailableToCompany = request.available_to_company;
            page.MethodType = request.method_type;
            
            page.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(page, cancellationToken);

            return page;


        }
    }

}

