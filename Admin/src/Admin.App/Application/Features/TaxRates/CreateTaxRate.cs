using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.IMT.Domain.Entities;
using YamlDotNet.Core.Tokens;

namespace Admin.App.Application.Features.TaxRates
{
    public class CreateTaxRateController : ApiControllerBase
    {
        [Tags("TaxRate")]
        // [Authorize(Policy = "HasPermission")]
        [HttpPost(Routes.CreateTaxRateUrl, Name = Routes.CreateTaxRateName)]

        public async Task<ActionResult<ErrorOr<TaxRate>>> Create(CreateTaxRateCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }
    }
    public record CreateTaxRateCommand(
        byte TaxType,
        uint? CorridorId,
        uint? CountryId,
        uint? TaxCurrencyId,
        decimal TaxPercentage,
        decimal TaxFixed,
        uint? CompanyId,
        byte Status
        ) : IRequest<ErrorOr<TaxRate>>;

    internal sealed class CreateTaxRateCommandValidator : AbstractValidator<CreateTaxRateCommand>
    {
        public CreateTaxRateCommandValidator()
        {
            RuleFor(x => x.TaxType).NotEmpty().WithMessage("TaxType  is required");
            RuleFor(x => x.TaxPercentage).NotEmpty().WithMessage("TaxPercentage  is required");
            RuleFor(x => x.TaxFixed).NotEmpty().WithMessage("TaxFixed  is required");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Status  is required");
        }
    }

    internal sealed class CreateTaxRateCommandHandler : IRequestHandler<CreateTaxRateCommand, ErrorOr<TaxRate>>
    {
        private readonly IImtTaxRateRepository _repository;

        public CreateTaxRateCommandHandler(IImtTaxRateRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<TaxRate>> Handle(CreateTaxRateCommand command, CancellationToken cancellationToken)
        {
            var taxRate = new TaxRate
            {
                TaxType = command.TaxType,  //1 = Regular, 2 = Corridor tax, 3 = Country tax
                CorridorId = command.CorridorId,
                CountryId = command.CountryId,
                TaxCurrencyId = command.TaxCurrencyId,
                TaxFixed = command.TaxFixed,
                CompanyId = command.CompanyId,
                Status = 1,  //0=inactive, 1=active, 2=pending, 3=rejected 
                CreatedById = 1,
                UpdatedById = 1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            return await _repository.AddAsync(taxRate);
        }
    }
}
