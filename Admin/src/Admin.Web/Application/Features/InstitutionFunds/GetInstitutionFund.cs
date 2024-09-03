using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

namespace Admin.Web.Application.Features.InstitutionFunds
{
    public class GetInstitutionFundController : ApiControllerBase
    {
        [Tags("InstitutionFund")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetInstitutionFundUrl, Name = Routes.GetInstitutionFundName)]
        public async Task<ActionResult<ErrorOr<List<InstitutionFund>>>> Get(int PageNumber = 0, int PageSize = 0)
        {
            var result = await Mediator.Send(new GetInstitutionFundQuery()).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem); return Ok(result);
        }

        public record GetInstitutionFundQuery(int PageNumber = 0, int PageSize = 0) : IRequest<ErrorOr<List<InstitutionFund>>>;

        public class GetInstitutionFundQueryHandler : IRequestHandler<GetInstitutionFundQuery, ErrorOr<List<InstitutionFund>>>
        {
            private readonly IInstitutionFundRepository _repository;

            public GetInstitutionFundQueryHandler(IInstitutionFundRepository repository)
            {
                _repository = repository;
            }
            public async Task<ErrorOr<List<InstitutionFund>>> Handle(GetInstitutionFundQuery request, CancellationToken cancellationToken)
            {
                List<InstitutionFund>? entities;

                if (request.PageNumber > 0 && request.PageSize > 0)
                {
                    entities = await _repository.ListPaginatedAsync(request.PageNumber, request.PageSize, cancellationToken);

                }
                else
                {
                    entities = await _repository.ListAsync(cancellationToken);

                }

                if (entities == null)
                {
                    return Error.NotFound(code: ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString(), description: "Institution Fund not found!");
                }

                return entities;
            }
        }
    }
}
