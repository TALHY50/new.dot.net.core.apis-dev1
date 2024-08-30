using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;
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
            var result = await Mediator.Send(command).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
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

    public class CreateTaxRateCommandValidator : AbstractValidator<CreateTaxRateCommand>
    {
        public CreateTaxRateCommandValidator()
        {
            RuleFor(x => x.TaxType).NotEmpty().WithMessage("TaxType  is required");
            RuleFor(x => x.TaxPercentage).NotEmpty().WithMessage("TaxPercentage  is required");
            RuleFor(x => x.TaxFixed).NotEmpty().WithMessage("TaxFixed  is required");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Status  is required");
        }
    }

    public class CreateTaxRateCommandHandler : IRequestHandler<CreateTaxRateCommand, ErrorOr<TaxRate>>
    {
        private readonly IImtTaxRateRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateTaxRateCommandHandler(IHttpContextAccessor httpContextAccessor, IImtTaxRateRepository repository)
        {
            _httpContextAccessor = httpContextAccessor;
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

            if(taxRate == null)
            {
                return ErrorOr.Error.NotFound(description: Language.GetMessage(_httpContextAccessor, "Record not found"), code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
            }
            return _repository.Add(taxRate)!;
        }
    }
}
