using ACL.Business.Application.Interfaces;
using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Contracts.Responses;
using ACL.Business.Domain.Entities;
using ACL.Business.Domain.Services;
using ACL.Business.Infrastructure.Auth.Auth;
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
        private readonly IUserRepository _userRepository;

        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<List<User>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            List<User>? entities;

            if (request.PageNumber > 0 && request.PageSize > 0)
            {
                entities = await _userRepository.ListPaginatedAsync(request.PageNumber, request.PageSize, cancellationToken);

            }
            else
            {
                entities = _userRepository.All().Where(u => (uint)AppAuth.GetAuthInfo().UserId == 0 || (u.CompanyId == (uint)AppAuth.GetAuthInfo().UserId && u.CreatedById == (uint)AppAuth.GetAuthInfo().UserId))?.ToList();
            }

            entities?.ForEach(user =>
             {
                 user.Password = "**********";
                 user.Salt = "**********";
                 #pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                 user.Claims = null;
                 user.RefreshToken = null;
             });

            if (entities == null)
            {
                return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), description: "User not found!");
            }

            return entities;
        }
    }
}
