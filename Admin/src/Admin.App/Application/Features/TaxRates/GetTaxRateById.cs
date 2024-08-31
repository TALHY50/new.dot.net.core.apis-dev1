using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Constants.Routes;
using SharedKernel.Main.Contracts.Common;

namespace Admin.App.Application.Features.TaxRates
{
    public class GetTaxRateByIdController : ApiControllerBase
    {
        [Tags("TaxRate")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetTaxRateByIdUrl, Name = Routes.GetTaxRateByIdName)]
        public async Task<ActionResult<ErrorOr<TaxRate>>> GetById(uint Id)
        {
            var result = await Mediator.Send(new GetTaxRateByIdQuery(Id)).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }

        public record GetTaxRateByIdQuery(uint Id) : IRequest<ErrorOr<TaxRate>>;

        public class GetTaxRateByIdCommandValidator : AbstractValidator<GetTaxRateByIdQuery>
        {
            public GetTaxRateByIdCommandValidator()
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("TaxRate ID is required");
            }
        }

        public class GetTaxRateByIdQueryHandler : IRequestHandler<GetTaxRateByIdQuery, ErrorOr<TaxRate>>
        {
            private readonly ITaxRateRepository _repository;

            public GetTaxRateByIdQueryHandler(ITaxRateRepository repository)
            {
                _repository = repository;
            }
            public async Task<ErrorOr<TaxRate>> Handle(GetTaxRateByIdQuery request, CancellationToken cancellationToken)
            {
                var entity = _repository.View(request.Id);
                if (entity == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), "Tax Rate not found!");
                }
                return entity;
            }
        }
    }
}
