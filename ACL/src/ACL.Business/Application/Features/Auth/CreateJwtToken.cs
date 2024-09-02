using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ACL.Business.Application.Features.Auth
{
    public abstract record CreateJwtTokenCommand(
        int UserId
    ) : IRequest<ErrorOr<string>>;

    public class CreateJwtTokenCommandValidator : AbstractValidator<CreateJwtTokenCommand>
    {
        public CreateJwtTokenCommandValidator()
        {
        }
    }

    public class CreateJwtTokenCommandHandler(ILogger<CreateJwtTokenCommandHandler> logger) : IRequestHandler<CreateJwtTokenCommand, ErrorOr<string>>
    {
        
        public async Task<ErrorOr<string>> Handle(CreateJwtTokenCommand command, CancellationToken cancellationToken)
        {
            return "GeneratedToken"; // Placeholder for the generated token
        }
    }
}