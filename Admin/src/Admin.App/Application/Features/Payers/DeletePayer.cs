using ACL.Bussiness.Contracts.Responses;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;

namespace Admin.App.Application.Features.Payers
{
    public class DeletePayerController : ApiControllerBase
    {
        [Tags("Payer")]
        // [Authorize]
        [HttpDelete(Routes.DeletePayerUrl, Name = Routes.DeletePayerName)]
        public async Task<ActionResult<ErrorOr<bool>>> DeletePayer(uint id)
        {
            var result =  await Mediator.Send(new DeletePayerCommand(id)).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }

    public record DeletePayerCommand(uint id) : IRequest<ErrorOr<bool>>;

    public class DeletePayerCommandValidator : AbstractValidator<DeletePayerCommand>
    {
        public DeletePayerCommandValidator()
        {
            RuleFor(r => r.id).NotEmpty();
        }
    }
    public class DeletePayerCommandHandler : IRequestHandler<DeletePayerCommand, ErrorOr<bool>>
    {
        private readonly IImtPayerRepository _repository;
        public DeletePayerCommandHandler(IImtPayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeletePayerCommand request, CancellationToken cancellationToken)
        {
            var message = new MessageResponse("Record not found");
            if (request.id > 0)
            {
                var entity = _repository.FindById(request.id);

                if (entity == null)
                {
                    return Error.NotFound(message.PlainText, AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
                }

                return _repository.Delete(entity);
            }

            return false;
        }
    }
}
