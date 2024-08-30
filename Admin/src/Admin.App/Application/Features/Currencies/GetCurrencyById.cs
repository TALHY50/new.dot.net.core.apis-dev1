using ACL.App.Contracts.Responses;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Constants.Routes;
using SharedKernel.Main.Contracts.Common;

namespace Admin.App.Application.Features.Currencies
{
    public class GetCurrencyById : ApiControllerBase
    {
        [Tags("Currency")]
        //[Authorize]
        [HttpGet(Routes.GetCurrencyByIdUrl, Name = Routes.GetCurrencyByIdName)]
        public async Task<ActionResult<ErrorOr<Currency>>> GetById(uint id)
        {
            var result = await Mediator.Send(new GetCurrencyByIdQuery(id)).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }
    public record GetCurrencyByIdQuery(uint id) : IRequest<ErrorOr<Currency>>;

    internal sealed class GetCurrencyByIdValidator : AbstractValidator<GetCurrencyByIdQuery>
    {
        public GetCurrencyByIdValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Currency ID is required");
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
            var message = new MessageResponse("Record not found");
            var entity = _repository.FindById(request.id);
            if (entity == null)
            {
                return Error.NotFound(message.PlainText, ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }
            return entity;
        }
    }
}
