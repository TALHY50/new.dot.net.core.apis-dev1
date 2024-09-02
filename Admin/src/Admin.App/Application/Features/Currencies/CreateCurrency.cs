using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

namespace Admin.App.Application.Features.Currencies
{
    public class CreateCurrencyController : ApiControllerBase
    {
        [Tags("Currency")]
        //[Authorize]
        [HttpPost(Routes.CreateCurrencyUrl, Name = Routes.CreateCurrencyName)]
        public async Task<ActionResult<ErrorOr<Currency>>> Create(CreateCurrencyCommand command)
        {
            var result = await Mediator.Send(command).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }

    public record CreateCurrencyCommand(
        string? Code,
        string? IsoCode,
        string? Name,
        string? Symbol) : IRequest<ErrorOr<Currency>>;

    public class CreateCurrencyCommandValidator : AbstractValidator<CreateCurrencyCommand> 
    {
        public CreateCurrencyCommandValidator()
        {
            RuleFor(x => x.Code).NotEmpty().MinimumLength(1).MaximumLength(10).WithMessage("IsoCodeShort cannot be empty");
            RuleFor(x => x.IsoCode).NotEmpty().MinimumLength(1).MaximumLength(10).WithMessage("iso_code cannot be empty");
            RuleFor(x => x.Name).NotEmpty().MinimumLength(1).MaximumLength(100).WithMessage("name cannot be empty");
            RuleFor(x => x.Symbol).NotEmpty().MinimumLength(1).MaximumLength(50).WithMessage("Symbol cannot be empty");
        }
    }

    public class CreateCurrencyCommandHandler : IRequestHandler<CreateCurrencyCommand, ErrorOr<Currency>>
    {
        private readonly ICurrencyRepository _repository;

        public CreateCurrencyCommandHandler(ICurrencyRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<Currency>> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow;
            var @currency = new Currency
            {
                Code = request.Code,
                IsoCode = request.IsoCode,
                Name = request.Name,
                Symbol = request.Symbol,
                CreatedById = 1,
                UpdatedById = 2,
                Status = 1,
                CreatedAt = now,
                UpdatedAt = now,
            };

            return _repository.Add(@currency);
        }
    }
}
