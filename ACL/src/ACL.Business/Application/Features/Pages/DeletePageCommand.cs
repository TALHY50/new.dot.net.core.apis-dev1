
using ACL.Business.Application.Interfaces.Repositories;
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedKernel.Main.Contracts;


namespace ACL.Business.Application.Features.Pages
{

    public record DeletePageCommand(uint id) : IRequest<ErrorOr<bool>>;

    public class DeletePageCommandValidator : AbstractValidator<DeletePageCommand>
    {
        public DeletePageCommandValidator()
        {
            RuleFor(r => r.id).NotEmpty().WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }

    public class DeletePageCommandHandler : PageBase, IRequestHandler<DeletePageCommand, ErrorOr<bool>>
    {
        private readonly IPageRepository _repository;

        public DeletePageCommandHandler(IPageRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeletePageCommand command, CancellationToken cancellationToken)
        {
            if (command.id > 0)
            {
                var page = await _repository.GetByIdAsync(command.id);

                if (page == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), Language.GetMessage("Page not found"));
                }

                await _repository.DeleteAsync(page, cancellationToken);
            }
            return true;

        }
    }


}
