using ACL.App.Contracts.Responses;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;

namespace ADMIN.App.Application.Features.ServiceMethods
{
    public class DeleteServiceMethodController : ApiControllerBase
    {
        [Tags("ServiceMethod")]
        //[Authorize(Policy = "HasPermission")]
        [HttpDelete(Routes.DeleteServiceMethodUrl, Name = Routes.DeleteServiceMethodName)]

        public async Task<ActionResult<ErrorOr<bool>>> Delete(uint Id)
        {
            var result = await Mediator.Send(new DeleteServiceMethodCommand(Id)).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }

    public record DeleteServiceMethodCommand(uint Id) : IRequest<ErrorOr<bool>>;

    public class DeleteServiceMethodCommandValidator : AbstractValidator<DeleteServiceMethodCommand>
    {
        public DeleteServiceMethodCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ID is required");
        }
    }

    public class DeleteServiceMethodCommandHandler: IRequestHandler<DeleteServiceMethodCommand, ErrorOr<bool>>
    {
        private readonly IImtServiceMethodRepository _repository;

        public DeleteServiceMethodCommandHandler(IImtServiceMethodRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<bool>> Handle(DeleteServiceMethodCommand command, CancellationToken cancellationToken)
        {
            if (command.Id > 0)
            {
                var serviceMethod = _repository.View(command.Id);

                var message = new MessageResponse("Record not found");

                if (serviceMethod == null)
                {
                    return Error.NotFound(description: Language.GetMessage("Record not found"), code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
                }

                return _repository.Delete(serviceMethod);
            }

            return false;
        }
    }
}