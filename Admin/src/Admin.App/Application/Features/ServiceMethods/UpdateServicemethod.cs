using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.IMT.Context;
using static Admin.App.Application.Features.Countries.UpdateCountryController;

namespace ADMIN.App.Application.Features.ServiceMethods
{
    public class UpdateServiceMethodContorller : ApiControllerBase
    {
        [Authorize(Policy = "HasPermission")]
        [HttpPut(Routes.UpdateServiceMethodUrl, Name = Routes.UpdateServiceMethodName)]

        public async Task<ActionResult<ErrorOr<ServiceMethod>>> Update(UpdateServiceMethodCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }

        public record UpdateServiceMethodCommand(
            int Id,
            byte Method,
            uint? CompanyId
            ) : IRequest<ErrorOr<ServiceMethod>>;
        internal sealed class UpdateServiceMethodCommandValidator : AbstractValidator<UpdateServiceMethodCommand>
        {
            public UpdateServiceMethodCommandValidator()
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("ID is required");
                RuleFor(x => x.Method).NotEmpty().WithMessage("Method is required");
            }
        }

        internal sealed class UpdateServiceMethodCommandHandler(ImtApplicationDbContext context) : IRequestHandler<UpdateServiceMethodCommand, ErrorOr<ServiceMethod>>
        {
            private readonly ImtApplicationDbContext _context = context;

            public async Task<ErrorOr<ServiceMethod>> Handle(UpdateServiceMethodCommand command, CancellationToken cancellationToken)
            {
                var serviceMethod = new ServiceMethod
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

                //await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                return @serviceMethod;
            }
        }

    }
}
