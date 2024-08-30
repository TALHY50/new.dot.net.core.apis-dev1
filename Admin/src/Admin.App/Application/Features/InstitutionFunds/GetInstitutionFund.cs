using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;

namespace Admin.App.Application.Features.InstitutionFunds
{
    public class GetInstitutionFundController : ApiControllerBase
    {
        [Tags("InstitutionFund")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetInstitutionFundUrl, Name = Routes.GetInstitutionFundName)]
        public async Task<ActionResult<ErrorOr<List<InstitutionFund>>>> Get()
        {
            var result = await Mediator.Send(new GetInstitutionFundQuery()).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);return Ok(result);
        }

        public record GetInstitutionFundQuery() : IRequest<ErrorOr<List<InstitutionFund>>>;

        public class GetInstitutionFundQueryHandler : IRequestHandler<GetInstitutionFundQuery, ErrorOr<List<InstitutionFund>>>
        {
            private readonly IImtInstitutionFundRepository _repository;

            public GetInstitutionFundQueryHandler(IImtInstitutionFundRepository repository)
            {
                _repository = repository;
            }
            public async Task<ErrorOr<List<InstitutionFund>>> Handle(GetInstitutionFundQuery request, CancellationToken cancellationToken)
            {
                var institutionFunds = _repository.ViewAll();
 
                return institutionFunds;
            }
        }
    }
}
