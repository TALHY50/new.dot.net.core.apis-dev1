using ACL.Business.Contracts.Responses;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;

namespace Admin.App.Application.Features.Currencies
{
    public class DeleteCurrencyController : ApiControllerBase
    {
        [Tags("Currency")]
        // [Authorize]
        [HttpDelete(Routes.DeleteCurrencyUrl, Name = Routes.DeleteCurrencyName)]
        public async Task<ActionResult<ErrorOr<bool>>> DeleteCurrency(uint id)
        {
            var result = await Mediator.Send(new DeleteCurrencyCommand(id)).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }

    public record DeleteCurrencyCommand(uint id) : IRequest<ErrorOr<bool>>;

    public class DeleteCurrencyCommandValidator : AbstractValidator<DeleteCurrencyCommand>
    {
        public DeleteCurrencyCommandValidator()
        {
            RuleFor(r => r.id).NotEmpty();
        }
    }
    public class DeleteCurrencyCommandHandler : IRequestHandler<DeleteCurrencyCommand, ErrorOr<bool>>
    {
        private readonly IImtAdminCurrencyRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DeleteCurrencyCommandHandler(IHttpContextAccessor httpContextAccessor, IImtAdminCurrencyRepository repository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteCurrencyCommand request, CancellationToken cancellationToken)
        {
            if (request.id > 0)
            {
                var entity = _repository.FindById(request.id);

                if (entity == null)
                {
                    return Error.NotFound(description: Language.GetMessage("Record not found"), code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
                }

                return _repository.Delete(entity);
            }

            return false;
        }
    }
}
