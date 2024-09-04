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
    public record GetUserByIdQuery(uint id) : IRequest<ErrorOr<User>>;

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
        private readonly IUserRepository _repository;

        public GetUserByIdQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<User>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
             try
            {
                User? aclUser = _repository.Find(request.id);
                if (aclUser == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), description: "User not found!");
                }
                else
                {
                    aclUser.Password = "***********";
                    aclUser.Salt = "***********";
                    aclUser.Claims = null;
                }
                return aclUser;
            }
            catch (Exception ex)
            {
               return Error.NotFound(code: ApplicationStatusCodes.GENERAL_FAILURE.ToString(), description: "User not found!");
            }

            //var entity = await _repository.GetByIdAsync(request.id, cancellationToken);

            //if (entity == null)
            //{
            //    return Error.NotFound(description: "User not found!", code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            //}

            //return entity;
        }
    }
}
