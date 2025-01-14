﻿
//using ErrorOr;
//using FluentValidation;
//using MediatR;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using SharedBusiness.Main.Common.Application.Services.Repositories;
//using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
//using SharedKernel.Main.Application.Interfaces.Services;
//using SharedKernel.Main.Contracts;
//using SharedKernel.Main.Presentation;
//using SharedKernel.Main.Presentation.Routes;
//using static Admin.Web.Application.Features.Mtts.InstitutionDelete;
//using static Admin.Web.Application.Features.Providers.DeleteProviderController;

//namespace Admin.Web.Application.Features.Regions
//{
//    public class DeleteRegionController : ApiControllerBase
//    {
//        [Tags("Regions")]
//        //[Authorize(Policy = "HasPermission")]
//        [HttpDelete(Routes.DeleteRegionUrl, Name = Routes.DeleteRegionName)]
//        public async Task<ActionResult<ErrorOr<bool>>> Delete(uint id)
//        {

//            var result = await Mediator.Send(new DeleteRegionCommand(id)).ConfigureAwait(false);

//            return result.Match(
//                reminder => Ok(result.Value),
//                Problem);
//        }

//        public record DeleteRegionCommand(uint id) 
//            : IRequest<ErrorOr<bool>>;

//        public class DeleteRegionCommandValidator : AbstractValidator<DeleteRegionCommand>
//        {
//            public DeleteRegionCommandValidator()
//            {
//                RuleFor(r => r.id)
//                    .NotEmpty()
//                    .WithMessage("ID is required");
//            }
//        }

//        public class DeleteRegionCommandHandler
//        : IRequestHandler<DeleteRegionCommand, ErrorOr<bool>>
//        {
//            private readonly ICurrentUser _user;
//            private readonly IRegionRepository _repository;
//            public DeleteRegionCommandHandler(ICurrentUser user, IRegionRepository repository)
//            {
//                _user = user;
//                _repository = repository;
//            }

//            public async Task<ErrorOr<bool>> Handle(DeleteRegionCommand request, CancellationToken cancellationToken)
//            {
//                var message = new MessageResponse("Record not found");

//                var regions = _repository.View(request.id);

//                if (regions == null)
//                {
//                    return Error.NotFound(message.PlainText, ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
//                }

//                return _repository.Delete(regions);
//            }
//        }
//    }
//}
