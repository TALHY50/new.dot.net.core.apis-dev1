using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts.Common;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

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
            RuleFor(x => x.id).NotEmpty().WithMessage("InstitutionMtt id is required");
        }
    }

    public class GetInstitutionMttByIdQueryHandler :
        IRequestHandler<GetInstitutionMttByIdQuery, ErrorOr<InstitutionMtt>>
    {
        private readonly IInstitutionMttRepository _repository;
        public GetInstitutionMttByIdQueryHandler(IInstitutionMttRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<InstitutionMtt>> Handle(GetInstitutionMttByIdQuery request, CancellationToken cancellationToken)
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
