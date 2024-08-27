using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Interfaces.Repositories.Admin;
using SharedKernel.Main.Domain.IMT.Entities;

namespace Admin.App.Application.Features.InstitutionFunds
{
    public class GetInstitutionFundController : ApiControllerBase
    {
        [Tags("InstitutionFund")]
        //[Authorize(Policy = "HasPermission")]
        [HttpGet(Routes.GetInstitutionFundUrl, Name = Routes.GetInstitutionFundName)]
        public async Task<ActionResult<ErrorOr<List<InstitutionFund>>>> Get()
        {
            return await Mediator.Send(new GetInstitutionFundQuery()).ConfigureAwait(false);
        }

        public record GetInstitutionFundQuery() : IRequest<ErrorOr<List<InstitutionFund>>>;

        internal sealed class GetInstitutionFundQueryHandler : IRequestHandler<GetInstitutionFundQuery, ErrorOr<List<InstitutionFund>>>
        {
            private readonly IImtInstitutionFundRepository _repository;

            public GetInstitutionFundQueryHandler(IImtInstitutionFundRepository repository)
            {
                _repository = repository;
            }
            public async Task<ErrorOr<List<InstitutionFund>>> Handle(GetInstitutionFundQuery request, CancellationToken cancellationToken)
            {
                return _repository.All().ToList();
            }
        }
    }
}
