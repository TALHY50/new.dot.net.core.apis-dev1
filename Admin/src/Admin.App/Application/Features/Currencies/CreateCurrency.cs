using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;

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
            RuleFor(x => x.Code).MaximumLength(10);
            RuleFor(x => x.IsoCode).MaximumLength(10);
            RuleFor(x => x.Name).MaximumLength(100);
            RuleFor(x => x.Symbol).MaximumLength(50);
        }
    }

    public class CreateCurrencyCommandHandler : IRequestHandler<CreateCurrencyCommand, ErrorOr<Currency>>
    {
        private readonly IImtAdminCurrencyRepository _repository;

        public CreateCurrencyCommandHandler(IImtAdminCurrencyRepository repository)
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

            return await _repository.AddAsync(@currency);
        }
    }
}
