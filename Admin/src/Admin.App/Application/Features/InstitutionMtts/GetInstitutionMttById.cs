using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Contracts.Common;
using ACL.App.Contracts.Responses;

namespace Admin.App.Application.Features.InstitutionMtts
{
    public class GetInstitutionMttById : ApiControllerBase
    {
        [Tags("InstitutionMtt")]
        //[Authorize]
        [HttpGet(Routes.GetInstitutionMttByIdUrl, Name = Routes.GetInstitutionMttByIdName)]
        public async Task<ActionResult<ErrorOr<InstitutionMtt>>> GetById(uint id)
        {
            var result = await Mediator.Send(new GetInstitutionMttByIdQuery(id)).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }
    public record GetInstitutionMttByIdQuery(uint id) : IRequest<ErrorOr<InstitutionMtt>>;

    public class GetByIdQueryValidator : AbstractValidator<GetInstitutionMttByIdQuery>
    {
        public GetByIdQueryValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("InstitutionMtt Id is required");
        }
    }

    public class GetInstitutionMttByIdQueryHandler :
        IRequestHandler<GetInstitutionMttByIdQuery, ErrorOr<InstitutionMtt>>
    {
        private readonly IImtInstitutionMttRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetInstitutionMttByIdQueryHandler(IHttpContextAccessor httpContextAccessor, IImtInstitutionMttRepository repository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = repository;
        }
        public async Task<ErrorOr<InstitutionMtt>> Handle(GetInstitutionMttByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = _repository.FindById(request.id);
            if (entity == null)
            {
                return Error.NotFound(description: Language.GetMessage("Record not found"), code: AppErrorStatusCode.API_ERROR_RECORD_NOT_FOUND.ToString());
            }
            return entity;
        }
    }
}
