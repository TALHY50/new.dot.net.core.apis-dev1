using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Infrastructure.Persistence.Notification.Context;

namespace ADMIN.App.Application.Features.Countries
{
    public class UpdateCountryController : ApiControllerBase
    {
        [Authorize(Policy = "HasPermission")]
        [HttpPut(Routes.UpdateCountryUrl, Name = Routes.UpdateCountryName)]

        public async Task<ActionResult<ErrorOr<Country>>> Update(UpdateCountryCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }

        public record UpdateCountryCommand(
            int Id,
            string? Code,
            string? IsoCode,
            string? Name) : IRequest<ErrorOr<Country>>;

        internal sealed class UpdateCountryCommandValidator : AbstractValidator<UpdateCountryCommand>
        {
            public UpdateCountryCommandValidator()
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("Country ID is required");
            }
        }

        internal sealed class UpdateCountryCommandHandler(ApplicationDbContext context) : IRequestHandler<UpdateCountryCommand, ErrorOr<Country>>
        {
            private readonly ApplicationDbContext _context = context;

            public async Task<ErrorOr<Country>> Handle(UpdateCountryCommand command, CancellationToken cancellationToken)
            {
                var @country = new Country
                {
                    Code = command.Code,
                    IsoCode = command.IsoCode,
                    Name = command.Name,
                    CreatedById = 1,
                    UpdatedById = 1,
                    Status = 1, //1=active, 0=inactive, 2=soft-deleted
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                };

                //_context.Countries.Add(@country);

                //await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                return @country;
            }
        }
    }
}
