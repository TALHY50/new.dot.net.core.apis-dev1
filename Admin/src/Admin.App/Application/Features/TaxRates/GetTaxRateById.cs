using ACL.App.Contracts.Responses;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
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
            private readonly IImtTaxRateRepository _repository;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public GetTaxRateByIdQueryHandler(IHttpContextAccessor httpContextAccessor, IImtTaxRateRepository repository)
            {
                _httpContextAccessor = httpContextAccessor;
                _repository = repository;
            }
            public async Task<ErrorOr<TaxRate>> Handle(GetTaxRateByIdQuery request, CancellationToken cancellationToken)
            {
                var taxRate = _repository.View(request.Id);

                var message = new MessageResponse("Record not found");

                if (taxRate == null)
                {
                    return Error.NotFound(description: Language.GetMessage(_httpContextAccessor, "Record not found"), code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
                }
                return taxRate!;
            }
        }
    }
}
