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

namespace Admin.App.Application.Features.CurrencyConversionRates
{
    public class GetCurrencyConversionRateByIdController : ApiControllerBase
    {
        [Tags("CurrencyConversionRate")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetCurrencyConversionRateByIdUrl, Name = Routes.GetCurrencyConversionRateByIdName)]
        public async Task<ActionResult<ErrorOr<CurrencyConversionRate>>> GetById(uint Id)
        {
            var result = await Mediator.Send(new GetCurrencyConversionRateByIdQuery(Id)).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }

        public record GetCurrencyConversionRateByIdQuery(uint Id) : IRequest<ErrorOr<CurrencyConversionRate>>;

        public class GetCurrencyConversionRateByIdCommandValidator : AbstractValidator<GetCurrencyConversionRateByIdQuery>
        {
            public GetCurrencyConversionRateByIdCommandValidator()
            {
                RuleFor(x => x.Id).NotEmpty().WithMessage("CurrencyConversionRate ID is required");
            }
        }

        public class GetCurrencyConversionRateByIdQueryHandler : IRequestHandler<GetCurrencyConversionRateByIdQuery, ErrorOr<CurrencyConversionRate>>
        {
            private readonly IImtCurrencyConversionRateRepository _repository;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public GetCurrencyConversionRateByIdQueryHandler(IHttpContextAccessor httpContextAccessor, IImtCurrencyConversionRateRepository repository)
            {
                _httpContextAccessor = httpContextAccessor;
                _repository = repository;
            }
            public async Task<ErrorOr<CurrencyConversionRate>> Handle(GetCurrencyConversionRateByIdQuery request, CancellationToken cancellationToken)
            {
                var currencyConversionRate = _repository.View(request.Id);
                if (currencyConversionRate == null)
                {
                    return Error.NotFound(description: Language.GetMessage(_httpContextAccessor, "Record not found"), code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
                }

                return currencyConversionRate;
            }
        }
    }
}
