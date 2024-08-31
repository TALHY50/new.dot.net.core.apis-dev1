using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Constants.Routes;
using SharedKernel.Main.Application.Common.Interfaces.Services;

namespace Admin.App.Application.Features.Institutions
{
    public class InstitutionAll : ApiControllerBase
    {
        [Tags("Institution")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetInstitutionUrl, Name = Routes.GetInstitutionName)]
        public async Task<ActionResult<ErrorOr<List<Institution>>>> GetAll()
        {
            return await Mediator.Send(new GetAllInstitutionQuery()).ConfigureAwait(false);
        }

        public record GetAllInstitutionQuery() : IRequest<ErrorOr<List<Institution>>>;

        public class Handler(ApplicationDbContext context, IInstitutionRepository repository, IInstitutionSettingRepository institutionSettingRepository, ICurrentUserService user) : IRequestHandler<GetAllInstitutionQuery, ErrorOr<List<Institution>>>
        {
            public async Task<ErrorOr<List<Institution>>> Handle(GetAllInstitutionQuery request, CancellationToken cancellationToken)
            {
                return repository.GetAll().ToList();
            }
        }
    }
}
