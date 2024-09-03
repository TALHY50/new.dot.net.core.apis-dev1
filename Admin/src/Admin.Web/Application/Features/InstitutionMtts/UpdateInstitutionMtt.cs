﻿using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedKernel.Main.Contracts;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

namespace Admin.App.Application.Features.InstitutionMtts
{
    public class UpdateInstitutionMttController : ApiControllerBase
    {
        [Tags("InstitutionMtt")]
        //[Authorize]//(Policy = "HasPermission")]
        [HttpPut(Routes.UpdateInstitutionMttUrl, Name = Routes.UpdateInstitutionMttName)]

        public async Task<ActionResult<ErrorOr<InstitutionMtt>>> Update(uint id, UpdateInstitutionMttCommand command)
        {
            var commandWithId = command with { id = id };
            var result = await Mediator.Send(commandWithId).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }
    public record UpdateInstitutionMttCommand(
        uint id,
        uint InstitutionId,
        uint MttId,
        byte CommissionType,
        uint? CommissionCurrencyId,
        decimal CommissionPercentage,
        decimal CommissionFixed,
        uint? CompanyId,
        byte Status = 1) : IRequest<ErrorOr<InstitutionMtt>>;

    public class UpdateInstitutionMttyCommandValidator : AbstractValidator<UpdateInstitutionMttCommand>
    {
        public UpdateInstitutionMttyCommandValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("InstitutionMtt id is required");
            RuleFor(x => x.InstitutionId).NotEmpty().WithMessage("InstitutionId is required");
            RuleFor(x => x.MttId).NotEmpty().WithMessage("MttId is required");
            RuleFor(x => x.CommissionType).NotEmpty().WithMessage("CommissionType is required");
            RuleFor(x => x.CommissionCurrencyId).NotEmpty().WithMessage("CommissionCurrencyId cannot be empty");
            RuleFor(x => x.CommissionPercentage).NotEmpty().WithMessage("CommissionPercentage is required");
            RuleFor(x => x.CommissionFixed).NotEmpty().WithMessage("CommissionFixed is required");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Status is required");
            RuleFor(x => x.CompanyId).NotEmpty().WithMessage("CompanyId cannot be empty");
        }
    }
    public class UpdateInstitutionMttCommandHandler
        : IRequestHandler<UpdateInstitutionMttCommand, ErrorOr<InstitutionMtt>>
    {
        private readonly IInstitutionMttRepository _repository;
        public UpdateInstitutionMttCommandHandler(IInstitutionMttRepository repository)
        {
            _repository = repository;
        }
        public async Task<ErrorOr<InstitutionMtt>> Handle(UpdateInstitutionMttCommand request, CancellationToken cancellationToken)
        {
            var message = new MessageResponse("Record not found");
            InstitutionMtt? entity = await _repository.GetByIdAsync(request.id);
            var now = DateTime.UtcNow;
            if (entity == null)
            {
                return Error.NotFound(message.PlainText, ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
            }
            entity.InstitutionId = request.InstitutionId;
            entity.MttId = request.MttId;
            entity.CommissionType = request.CommissionType;
            entity.CommissionCurrencyId = request.CommissionCurrencyId;
            entity.CommissionPercentage = request.CommissionPercentage;
            entity.CommissionFixed = request.CommissionFixed;
            entity.CompanyId = request.CompanyId;
            entity.Status = request.Status;
            entity.CreatedById = 1;
            entity.UpdatedById = 2;
            entity.Status = 1;
            entity.CreatedAt = now;
            entity.UpdatedAt = now;
             await _repository.UpdateAsync(entity);
            return entity;
        }
    }
}