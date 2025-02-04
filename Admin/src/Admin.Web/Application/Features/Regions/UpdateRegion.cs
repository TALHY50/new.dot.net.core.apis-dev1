﻿//using ErrorOr;
//using FluentValidation;
//using MediatR;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.AspNetCore.Mvc;
//using SharedBusiness.Main.Common.Application.Services.Repositories;
//using SharedBusiness.Main.Common.Domain.Entities;
//using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
//using SharedKernel.Main.Application.Interfaces.Services;
//using SharedKernel.Main.Contracts;
//using SharedKernel.Main.Presentation;
//using SharedKernel.Main.Presentation.Routes;
//using static Admin.Web.Application.Features.Regions.GetRegionByIdController;


//namespace Admin.Web.Application.Features.Regions
//{
//    public class UpdateRegionController : ApiControllerBase
//    {
//        [Tags("Regions")]
//        //[Authorize(Policy = "HasPermission")]
//        [HttpPut(Routes.UpdateRegionUrl, Name = Routes.UpdateRegionName)]
//        public async Task<ActionResult<ErrorOr<Region>>> Update(uint id, UpdateRegionCommand command)
//        {
//            var commandWithId = command with { id = id };
//            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);

//            return result.Match(
//                reminder => Ok(result.Value),
//                Problem);
//        }

//        public record UpdateRegionCommand(
//        uint id,
//        string? Name,
//        uint? CompanyId,
//        byte Status) : IRequest<ErrorOr<Region>>;

//        public class UpdateRegionCommandValidator : AbstractValidator<UpdateRegionCommand>
//        {
//            public UpdateRegionCommandValidator()
//            {
//                RuleFor(v => v.id)
//                    .NotEmpty()
//                    .WithMessage("ID is required.");
//                RuleFor(v => v.Name)
//                    .MaximumLength(50)
//                    .WithMessage("Maximum length can be 50.");
//                RuleFor(v => v.Status)
//                    .NotEmpty()
//                    .WithMessage("Status is required.");
//            }
//        }


//        public class UpdateRegionCommandHandler
//        : IRequestHandler<UpdateRegionCommand, ErrorOr<Region>>
//        {
//            private readonly ICurrentUser _user;
//            private readonly IRegionRepository _repository;

//            public UpdateRegionCommandHandler(ICurrentUser user, IRegionRepository repository)
//            {
//                _user = user;
//                _repository = repository;
//            }

//            public async Task<ErrorOr<Region>> Handle(UpdateRegionCommand request, CancellationToken cancellationToken)
//            {
//                var message = new MessageResponse("Record not found");

//                var now = DateTime.UtcNow;
//                Region? regions = _repository.View(request.id);
//                if (regions == null)
//                {
//                    return Error.NotFound(message.PlainText, ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
//                }
                
//                regions.Name = request.Name;
//                regions.CompanyId = request.CompanyId;
//                regions.Status = request.Status;
//                regions.CreatedById = 1;
//                regions.UpdatedById = 2;
//                regions.CreatedAt = now;
//                regions.UpdatedAt = now;

                

//                return _repository.Update(regions);
//            }
//        }

//    }
//}

