using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

namespace Admin.App.Application.Features.InstitutionMtts
{
    public class DeleteInstitutionMttController : ApiControllerBase
    {
        [Tags("InstitutionMtt")]
        // [Authorize]
        [HttpDelete(Routes.DeleteInstitutionMttUrl, Name = Routes.DeleteInstitutionMttName)]
        public async Task<ActionResult<ErrorOr<bool>>> DeleteInstitutionMtt(uint id)
        {
            var result = await Mediator.Send(new DeleteInstitutionMttCommand(id)).ConfigureAwait(false);

            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }

    public record DeleteInstitutionMttCommand(uint id) : IRequest<ErrorOr<bool>>;

    public class DeleteInstitutionMttCommandValidator : AbstractValidator<DeleteInstitutionMttCommand>
    {
        public DeleteInstitutionMttCommandValidator()
        {
            RuleFor(r => r.id).NotEmpty();
        }
    }
    public class DeleteInstitutionMttCommandHandler : IRequestHandler<DeleteInstitutionMttCommand, ErrorOr<bool>>
    {
        private readonly IInstitutionMttRepository _repository;
        public DeleteInstitutionMttCommandHandler(IInstitutionMttRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteInstitutionMttCommand request, CancellationToken cancellationToken)
        {
            var message = new MessageResponse("Record not found");
            if (request.id > 0)
            {
                var entity = await _repository.GetByIdAsync(request.id);

                if (entity == null)
                {
                    return Error.NotFound(message.PlainText, ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
                }

                 await _repository.DeleteAsync(entity);
                return true;
            }

            return Error.NotFound(message.PlainText, ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
        }
    }
}
