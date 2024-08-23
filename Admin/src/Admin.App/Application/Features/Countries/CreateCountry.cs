namespace Admin.App.Application.Features.Countries
{
    using ErrorOr;
    using FluentValidation;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SharedKernel.Main.Application.Common;
    using SharedKernel.Main.Application.Common.Constants;
    using SharedKernel.Main.Domain.IMT.Entities;
    using SharedKernel.Main.Infrastructure.Persistence.Notification.Context;

    public class CreateCountryController : ApiControllerBase
    {
        [Authorize(Policy = "HasPermission")]
        [HttpPost(Routes.CreateCountryUrl, Name = Routes.CreateCountryName)]

        public async Task<ActionResult<ErrorOr<Country>>> Create(CreateCountryCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }
    }

    public record CreateCountryCommand(
        string? Code,
        string? IsoCode,
        string? Name) : IRequest<ErrorOr<Country>>;
    internal sealed class CreateCountryCommandValidator : AbstractValidator<CreateCountryCommand>
    {
        public CreateCountryCommandValidator()
        {
            //RuleFor(v => v.CategoricalData.Category)
            //    .MaximumLength(200)
            //    .NotEmpty();
        }
    }

    internal sealed class CreateCountryCommandHandler(ApplicationDbContext context) : IRequestHandler<CreateCountryCommand, ErrorOr<Country>>
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<ErrorOr<Country>> Handle(CreateCountryCommand command, CancellationToken cancellationToken)
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

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return @country;
        }
    }

}
