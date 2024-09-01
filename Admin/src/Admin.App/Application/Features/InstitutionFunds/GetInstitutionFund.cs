using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts.Common;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

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
            private readonly IInstitutionFundRepository _repository;

            public GetInstitutionFundQueryHandler(IInstitutionFundRepository repository)
            {
                _repository = repository;
            }
            public async Task<ErrorOr<List<InstitutionFund>>> Handle(GetInstitutionFundQuery request, CancellationToken cancellationToken)
            {
                var institutionFunds = _repository.ViewAll();
                if (institutionFunds == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), "Institution Funds not found!");
                }

                return institutionFunds;
            }
        }
    }
}
