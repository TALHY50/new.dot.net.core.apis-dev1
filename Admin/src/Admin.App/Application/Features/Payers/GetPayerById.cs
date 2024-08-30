using ACL.App.Contracts.Responses;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.IMT.Domain.Entities;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;

namespace Admin.App.Application.Features.Payers
{
    public class GetPayerById : ApiControllerBase
    {
        [Tags("Payer")]
        //[Authorize]
        [HttpGet(Routes.GetPayerByIdUrl, Name = Routes.GetPayerByIdName)]
        public async Task<ActionResult<ErrorOr<Payer>>> GetById(uint id)
        {
            var result = await Mediator.Send(new GetPayerByIdQuery(id)).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }
    public record GetPayerByIdQuery(uint id) : IRequest<ErrorOr<Payer>>;

    public class GetByIdQueryValidator : AbstractValidator<GetPayerByIdQuery>
    {
        public GetByIdQueryValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Payer Id is required");
        }
    }

    public class GetPayerByIdQueryHandler :
        IRequestHandler<GetPayerByIdQuery, ErrorOr<Payer>>
    {
        private readonly IImtPayerRepository _repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GetPayerByIdQueryHandler(IHttpContextAccessor httpContextAccessor, IImtPayerRepository repository)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = repository;
        }
        public async Task<ErrorOr<Payer>> Handle(GetPayerByIdQuery request, CancellationToken cancellationToken)
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
