using ErrorOr;
using FluentValidation;
using IMT.App.Application.Interfaces.Repositories;
using IMT.App.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;

namespace Admin.App.Application.Features.Currencies
{
    public class GetCurrencyById : ApiControllerBase
    {
        [Tags("Currency")]
        //[Authorize]
        [HttpGet(Routes.GetCurrencyByIdUrl, Name = Routes.GetCurrencyByIdName)]
        public async Task<ActionResult<ErrorOr<Currency>>> GetById(uint id)
        {
            return await Mediator.Send(new GetCurrencyByIdQuery(id)).ConfigureAwait(false);
        }
    }
    public record GetCurrencyByIdQuery(uint id) : IRequest<ErrorOr<Currency>>;

    internal sealed class GetCurrencyByIdValidator : AbstractValidator<GetCurrencyByIdQuery>
    {
        public GetCurrencyByIdValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Currencyts ID is required");
        }
    }
    internal sealed class GetCurrencyByIdQueryHandler :
        IRequestHandler<GetCurrencyByIdQuery, ErrorOr<Currency>>
    {
        private readonly IImtAdminCurrencyRepository _repository;

        public GetCurrencyByIdQueryHandler(IImtAdminCurrencyRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<Currency>> Handle(GetCurrencyByIdQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetByUintId(request.id);
        }
    }
}
