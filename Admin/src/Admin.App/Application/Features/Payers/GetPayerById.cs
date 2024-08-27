using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Main.Admin.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.IMT.Domain.Entities;

namespace Admin.App.Application.Features.Payers
{
    public class GetPayerById : ApiControllerBase
    {
        [Tags("Payer")]
        //[Authorize]
        [HttpGet(Routes.GetPayerByIdUrl, Name = Routes.GetPayerByIdName)]
        public async Task<ActionResult<ErrorOr<Payer>>> GetById(uint id)
        {
            return await Mediator.Send(new GetPayerByIdQuery(id)).ConfigureAwait(false);
        }
    }
    public record GetPayerByIdQuery(uint id) : IRequest<ErrorOr<Payer>>;

    internal sealed class GetByIdQueryValidator : AbstractValidator<GetPayerByIdQuery>
    {
        public GetByIdQueryValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Payer Id is required");
        }
    }

    internal sealed class GetPayerByIdQueryHandler :
        IRequestHandler<GetPayerByIdQuery, ErrorOr<Payer>>
    {
        private readonly IImtPayerRepository _repository;
        public GetPayerByIdQueryHandler(IImtPayerRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<Payer>> Handle(GetPayerByIdQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetByUintId(request.id);
        }
    }
}
