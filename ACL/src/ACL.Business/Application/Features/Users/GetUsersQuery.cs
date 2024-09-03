using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ACL.Business.Domain.Services;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Contracts;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

namespace ACL.Business.Application.Features.Users
{
    [Authorize]
    public record GetUsersQuery(int PageNumber = 0, int PageSize = 0) : IRequest<ErrorOr<List<User>>>;

    public class GetUsersQueryValidator : AbstractValidator<GetUsersQuery>
    {
        public GetUsersQueryValidator()
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

    [ApiExplorerSettings(IgnoreApi = true)]
    public class GetUsersQueryHandler
      : UserBase, IRequestHandler<GetUsersQuery, ErrorOr<List<User>>>
    {
        private readonly IUserService _repository;

        public GetUsersQueryHandler(IUserService repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<List<User>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            List<User>? entities;

            if (request.PageNumber > 0 && request.PageSize > 0)
            {
                entities = await _repository.ListPaginatedAsync(request.PageNumber, request.PageSize, cancellationToken);

            }
            else
            {
                entities = await _repository.ListAsync(cancellationToken);

            }

            if (entities == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), description: "Mtts not found!");
            }

            return entities;
        }
    }
}
