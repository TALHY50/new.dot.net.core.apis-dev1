using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

namespace Admin.Web.Presentation.Endpoints.Institutions
{
    public class InstitutionView : ApiControllerBase
    {
        [Tags("Institution")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetInstitutionByIdUrl, Name = Routes.GetInstitutionByIdName)]
        public async Task<ActionResult<ErrorOr<Institution>>> GetById(uint id)
        {
            return await Mediator.Send(new GetInstitutionByIdQuery(id)).ConfigureAwait(false);
        }

        public record GetInstitutionByIdQuery(uint id) : IRequest<ErrorOr<Institution>>;

        public class GetInstitutionByIdQueryValidator : AbstractValidator<GetInstitutionByIdQuery>
        {
            public GetInstitutionByIdQueryValidator()
            {
                RuleFor(x => x.id).NotEmpty().WithMessage("Institution ID is required");
            }
        }

        public class Handler : IRequestHandler<GetInstitutionByIdQuery, ErrorOr<Institution>>
        {
            private readonly IInstitutionRepository _repository;

            public Handler(IInstitutionRepository repository)
            {
                _repository = repository;
            }

            public async Task<ErrorOr<Institution>> Handle(GetInstitutionByIdQuery request, CancellationToken cancellationToken)
            {
                return await _repository.GetByIdAsync(request.id);
            }
        }
    }
}
