//using ErrorOr;
//using FluentValidation;
//using MediatR;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using SharedBusiness.Main.Common.Application.Services.Repositories;
//using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
//using SharedKernel.Main.Contracts;
//using SharedKernel.Main.Presentation;
//using SharedKernel.Main.Presentation.Routes;

//namespace Admin.App.Application.Features.Currencies
//{
//    public class DeleteCurrencyController : ApiControllerBase
//    {
//        [Tags("Currency")]
//        // [Authorize]
//        [HttpDelete(Routes.DeleteCurrencyUrl, Name = Routes.DeleteCurrencyName)]
//        public async Task<ActionResult<ErrorOr<bool>>> DeleteCurrency(uint id)
//        {
//            var result = await Mediator.Send(new DeleteCurrencyCommand(id)).ConfigureAwait(false);
//            return result.Match(
//                reminder => Ok(result.Value),
//                Problem);
//        }
//    }

//    public record DeleteCurrencyCommand(uint id) : IRequest<ErrorOr<bool>>;

//    internal sealed class DeleteCurrencyCommandValidator : AbstractValidator<DeleteCurrencyCommand>
//    {
//        public DeleteCurrencyCommandValidator()
//        {
//            RuleFor(r => r.id).NotEmpty();
//        }
//    }
//    internal sealed class DeleteCurrencyCommandHandler : IRequestHandler<DeleteCurrencyCommand, ErrorOr<bool>>
//    {
//        private readonly ICurrencyRepository _repository;
//        public DeleteCurrencyCommandHandler(ICurrencyRepository repository)
//        {
//            _repository = repository;
//        }

//        public async Task<ErrorOr<bool>> Handle(DeleteCurrencyCommand request, CancellationToken cancellationToken)
//        {
//            var message = new MessageResponse("Record not found");
//            if (request.id > 0)
//            {
//                var entity = _repository.FindById(request.id);

//                if (entity == null)
//                {
//                    return Error.NotFound(message.PlainText, ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
//                }

//                return _repository.Delete(entity);
//            }

//            return false;
//        }
//    }
//}
