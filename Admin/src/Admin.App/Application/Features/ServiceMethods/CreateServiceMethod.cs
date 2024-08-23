using ADMIN.App.Application.Features.Countries;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;

namespace ADMIN.App.Application.Features.ServiceMethods
{
    public class CreateServiceMethodController : ApiControllerBase
    {
        [Authorize(Policy = "HasPermission")]
        [HttpPost(Routes.CreateServiceMethodUrl, Name = Routes.CreateServiceMethodName)]

        public async Task<ActionResult<ErrorOr<ServiceMethod>>> Create(CreateServiceMethodCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }
    }
    public record CreateServiceMethodCommand(
        byte Method,
        uint? CompanyId
        ) : IRequest<ErrorOr<ServiceMethod>>;

    internal sealed class CreateServiceMethodCommandValidator : AbstractValidator<CreateServiceMethodCommand>
    {
        public CreateServiceMethodCommandValidator()
        {
            RuleFor(x => x.Method).NotEmpty().WithMessage("Method  is required");
        }
    }

    internal sealed class CreateServiceMethodCommandHandler(ImtApplicationDbContext context) : IRequestHandler<CreateServiceMethodCommand, ErrorOr<ServiceMethod>>
    {
        private readonly ImtApplicationDbContext _context = context;

        public async Task<ErrorOr<ServiceMethod>> Handle(CreateServiceMethodCommand command, CancellationToken cancellationToken)
        {
            var @serviceMethod = new ServiceMethod
            {
                Method = command.Method, //1 = Bank Account, 2 = Wallet, 3 = Cash Pickup, 4 = Card
                CompanyId = command.CompanyId,
                Status = 1, //0=inactive, 1=active, 2=pending, 3=rejected 
                CreatedById = 1,
                UpdatedById = 1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            //_context.ServiceMethods.Add(@serviceMethod);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return serviceMethod;
        }
    }
}
