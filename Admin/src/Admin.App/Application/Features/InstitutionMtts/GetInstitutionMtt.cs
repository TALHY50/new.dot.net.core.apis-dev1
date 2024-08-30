using Ardalis.SharedKernel;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants.Routes;

namespace Admin.App.Application.Features.InstitutionMtts
{
    public class GetInstitutionMttController : ApiControllerBase
    {
        [Tags("InstitutionMtt")]
        //[Authorize]
        [HttpGet(Routes.GetInstitutionMttUrl, Name = Routes.GetInstitutionMttName)]
        public async Task<ActionResult<ErrorOr<List<InstitutionMtt>>>> Get()
        {
            var result = await Mediator.Send(new GetInstitutionMttQuery()).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }
    public record GetInstitutionMttQuery() : IQuery<ErrorOr<List<InstitutionMtt>>>;

    public class GetInstitutionMttHandler
        : IQueryHandler<GetInstitutionMttQuery, ErrorOr<List<InstitutionMtt>>>
    {
        private readonly IImtInstitutionMttRepository _repository;
        public GetInstitutionMttHandler(IImtInstitutionMttRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<List<InstitutionMtt>>> Handle(GetInstitutionMttQuery request, CancellationToken cancellationToken)
        {
            var InstitutionMtts = _repository.GetAll();
            return InstitutionMtts;

        }
    }
}
