//using ErrorOr;
//using FluentValidation;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using SharedBusiness.Main.Common.Application.Services.Repositories;
//using SharedBusiness.Main.Common.Domain.Entities;
//using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
//using SharedKernel.Main.Contracts;
//using SharedKernel.Main.Presentation;
//using SharedKernel.Main.Presentation.Routes;

//namespace Admin.App.Application.Features.Corridors
//{
//    public class GetCorridorById : ApiControllerBase
//    {
//        [Tags("Corridor")]
//        //[Authorize]
//        [HttpGet(Routes.GetCorridorByIdUrl, Name = Routes.GetCorridorByIdName)]
//        public async Task<ActionResult<ErrorOr<Corridor>>> GetById(uint id)
//        {
//            var result = await Mediator.Send(new GetCorridorByIdQuery(id)).ConfigureAwait(false);
//            return result.Match(
//                reminder => Ok(result.Value),
//                Problem);
//        }
//    }
//    public record GetCorridorByIdQuery(uint id) : IRequest<ErrorOr<Corridor>>;

//    public class GetByIdQueryValidator : AbstractValidator<GetCorridorByIdQuery>
//    {
//        public GetByIdQueryValidator()
//        {
//            RuleFor(x => x.id).NotEmpty().WithMessage("Corridor id is required");
//        }
//    }

//    public class GetCorridorByIdQueryHandler :
//        IRequestHandler<GetCorridorByIdQuery, ErrorOr<Corridor>>
//    {
//        private readonly ICorridorRepository _repository;
//        public GetCorridorByIdQueryHandler(ICorridorRepository repository)
//        {
//            _repository = repository;
//        }
//        public async Task<ErrorOr<Corridor>> Handle(GetCorridorByIdQuery request, CancellationToken cancellationToken)
//        {
//            var message = new MessageResponse("Record not found");
//            var entity = _repository.FindById(request.id);
//            if (entity == null)
//            {
//                return Error.NotFound(message.PlainText, ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
//            }
//            return entity;
//        }
//    }
//}
