using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ErrorOr;
using FluentValidation;
using MediatR;
using SharedKernel.Main.Contracts;


namespace ACL.Business.Application.Features.Pages
{
    public record GetPageQuery(int PageNumber = 0, int PageSize = 0) : IRequest<ErrorOr<List<Page>>>;

    public class GetPagesQueryValidator : AbstractValidator<GetPageQuery>
    {
        public GetPagesQueryValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1)
                .When(x => x.PageNumber != 0)
                .WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1)
                .When(x => x.PageNumber > 0)
                .When(x => x.PageSize != 0)
                .WithErrorCode(ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString());
        }
    }


    public class GetPageHandler : PageBase, IRequestHandler<GetPageQuery, ErrorOr<List<Page>>>
    {
        private readonly IPageRepository _repository;

        public GetPageHandler(IPageRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<List<Page>>> Handle(GetPageQuery request, CancellationToken cancellationToken)
        {
            List<Page>? pages;

            if (request.PageNumber > 0 && request.PageSize > 0)
            {
                pages = await _repository.ListPaginatedAsync(request.PageNumber, request.PageSize, cancellationToken);

            }
            else
            {
                pages = await _repository.ListAsync(cancellationToken);

            }

            if (pages == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), description:Language.GetMessage("Page not found!"));
            }

            return pages;
        }
    }

}
