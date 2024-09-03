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
    public record GetUserByIdQuery(ulong id) : IRequest<ErrorOr<User>>;

    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("User ID is required");
        }
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public class GetUserByIdQueryHandler : UserBase, IRequestHandler<GetUserByIdQuery, ErrorOr<User>>
    {
        private readonly IUserService _repository;

        public GetUserByIdQueryHandler(IUserService repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<User>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.id, cancellationToken);

            if (entity == null)
            {
                return Error.NotFound(description: "User not found!", code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }

            return entity;
        }
    }
}
