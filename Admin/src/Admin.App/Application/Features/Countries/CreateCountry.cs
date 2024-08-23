using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Domain.IMT.Entities;
using SharedKernel.Main.Application.Interfaces.Repositories.IMT.Repositories;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;

namespace Admin.App.Application.Features.Countries
{
    public class CreateCountryController : ApiControllerBase
    {
       // [Authorize(Policy = "HasPermission")]
        [HttpPost(Routes.CreateCountryUrl, Name = Routes.CreateCountryName)]

        public async Task<ActionResult<ErrorOr<Country>>> Create(CreateCountryCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }
    }

    public record CreateCountryCommand(Country Country) : IRequest<ErrorOr<Country>>;

    internal sealed class CreateCountryCommandValidator : AbstractValidator<CreateCountryCommand>
    {
        public CreateCountryCommandValidator()
        {

        }
    }

    internal sealed class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, ErrorOr<Country>>
    {
        //private readonly ImtApplicationDbContext _context = context;
        private readonly IAdminCountryRepository _repository;

        public CreateCountryCommandHandler(IAdminCountryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<Country>> Handle(CreateCountryCommand command, CancellationToken cancellationToken)
        {
            var country = new Country
            {
                Code = command.Country.Code,
                IsoCode = command.Country.IsoCode,
                Name = command.Country.Name,
                CreatedById = 1,
                UpdatedById = 1,
                Status = 1, //1=active, 0=inactive, 2=soft-deleted
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            return  _repository.AddAsync(country).Result;
        }
    }
}
