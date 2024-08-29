using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;

namespace Admin.App.Application.Features.TaxRates
{
    public class GetTaxRateByIdController : ApiControllerBase
    {
        [Tags("TaxRate")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetTaxRateByIdUrl, Name = Routes.GetTaxRateByIdName)]
        public async Task<ActionResult<ErrorOr<TaxRate>>> GetById(uint Id)
        {
            return await Mediator.Send(new GetTaxRateByIdQuery(Id)).ConfigureAwait(false);
        }

        public record GetTaxRateByIdQuery(uint Id) : IRequest<ErrorOr<TaxRate>>;

        internal sealed class GetTaxRateByIdCommandValidator : AbstractValidator<GetTaxRateByIdQuery>
        {
            public GetTaxRateByIdCommandValidator()
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("TaxRate ID is required");
            }
        }

        internal sealed class GetTaxRateByIdQueryHandler : IRequestHandler<GetTaxRateByIdQuery, ErrorOr<TaxRate>>
        {
            private readonly IImtTaxRateRepository _repository;

            public GetTaxRateByIdQueryHandler(IImtTaxRateRepository repository)
            {
                _repository = repository;
            }
            public async Task<ErrorOr<TaxRate>> Handle(GetTaxRateByIdQuery request, CancellationToken cancellationToken)
            {
                return _repository.GetByUintId(request.Id);
            }
        }
    }
}
