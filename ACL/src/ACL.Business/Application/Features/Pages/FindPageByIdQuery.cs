
using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedKernel.Main.Contracts;


namespace ACL.Business.Application.Features.Pages
{
    public record FindPageByIdQuery(uint id) : IRequest<ErrorOr<Page>>;

    public class FindPageByIdQueryValidator : AbstractValidator<FindPageByIdQuery>
    {
        public FindPageByIdQueryValidator()
        {
            RuleFor(x => x.id).NotEmpty();
        }
    }

    public class FindPageByIdQueryHandler : PageBase, IRequestHandler<FindPageByIdQuery, ErrorOr<Page>>
    {
        private readonly IPageRepository _repository;

        public FindPageByIdQueryHandler(IPageRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<Page>> Handle(FindPageByIdQuery request, CancellationToken cancellationToken)
        {
            var submodule = await _repository.GetByIdAsync(request.id, cancellationToken);

            if (submodule == null)
            {
                return Error.NotFound(description: Language.GetMessage("Page not found!"), code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }

            return submodule;
        }
    }
}
