using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Contracts.Common;
using ACL.Business.Contracts.Responses;

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
        private readonly IImtInstitutionMttRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DeleteInstitutionMttCommandHandler(IHttpContextAccessor httpContextAccessor, IImtInstitutionMttRepository repository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteInstitutionMttCommand request, CancellationToken cancellationToken)
        {
            if (request.id > 0)
            {
                var entity = _repository.FindById(request.id);

                if (entity == null)
                {
                    return Error.NotFound(description: Language.GetMessage( "Record not found"), code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
                }

                return _repository.Delete(entity);
            }

            return Error.NotFound(description: Language.GetMessage("Record not found"), code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
        }
    }
}
