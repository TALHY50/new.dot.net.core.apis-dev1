
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common.Constants.Routes;
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
            RuleFor(x => x.id).NotEmpty().WithMessage("Payer id is required");
        }
    }

    public class GetPayerByIdQueryHandler :
        IRequestHandler<GetPayerByIdQuery, ErrorOr<Payer>>
    {
        private readonly IPayerRepository _repository;
        public GetPayerByIdQueryHandler(IPayerRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<Payer>> Handle(GetPayerByIdQuery request, CancellationToken cancellationToken)
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
