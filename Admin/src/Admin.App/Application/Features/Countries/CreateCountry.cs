using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;

namespace Admin.App.Application.Features.Countries
{
    public class CreateCountryController : ApiControllerBase
    {
        [Tags("Country")]
       // [Authorize(Policy = "HasPermission")]
        [HttpPost(Routes.CreateCountryUrl, Name = Routes.CreateCountryName)]

        public async Task<ActionResult<ErrorOr<Country>>> Create(CreateCountryCommand command)
        {
            var result = await Mediator.Send(command).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }

    public record CreateCountryCommand(
        string? Code,
        string? IsoCode,
        string? Name,
        //uint? CreatedById,
        //uint? UpdatedById,
        byte Status
        ) : IRequest<ErrorOr<Country>>;

    public class CreateCountryCommandValidator : AbstractValidator<CreateCountryCommand>
    {
        public CreateCountryCommandValidator()
        {
            RuleFor(v => v.Code).MinimumLength(1).MaximumLength(100).NotEmpty();
            RuleFor(v => v.IsoCode).MinimumLength(1).MaximumLength(100).NotEmpty();
            RuleFor(v => v.Name).MinimumLength(1).MaximumLength(100).NotEmpty();
        }
    }

    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, ErrorOr<Country>>
    {
        //private readonly ApplicationDbContext _context = context;
        private readonly IAdminCountryRepository _repository;

        public CreateCountryCommandHandler(IAdminCountryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<Country>> Handle(CreateCountryCommand command, CancellationToken cancellationToken)
        {
            var country = new Country
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

            if (country == null)
            {
                return Error.NotFound(code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString(), "Country not found!");
            }
            return await _repository.AddAsync(country);
        }
    }
}
