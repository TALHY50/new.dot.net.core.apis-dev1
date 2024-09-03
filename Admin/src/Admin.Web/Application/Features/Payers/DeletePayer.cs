﻿using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Application.Services.Repositories;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts;
using SharedKernel.Main.Presentation;
using SharedKernel.Main.Presentation.Routes;

namespace Admin.App.Application.Features.Payers
{
    public class DeletePayerController : ApiControllerBase
    {
        [Tags("Payer")]
        // [Authorize]
        [HttpDelete(Routes.DeletePayerUrl, Name = Routes.DeletePayerName)]
        public async Task<ActionResult<ErrorOr<bool>>> DeletePayer(uint id)
        {
            var result =  await Mediator.Send(new DeletePayerCommand(id)).ConfigureAwait(false);
            return result.Match(
                reminder => Ok(result.Value),
                Problem);
        }
    }

    public record DeletePayerCommand(uint id) : IRequest<ErrorOr<bool>>;

    public class DeletePayerCommandValidator : AbstractValidator<DeletePayerCommand>
    {
        public DeletePayerCommandValidator()
        {
            RuleFor(r => r.id).NotEmpty();
        }
    }
    public class DeletePayerCommandHandler : IRequestHandler<DeletePayerCommand, ErrorOr<bool>>
    {
        private readonly IPayerRepository _repository;
        public DeletePayerCommandHandler(IPayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeletePayerCommand request, CancellationToken cancellationToken)
        {
            var message = new MessageResponse("Record not found");
            if (request.id > 0)
            {
                var entity = await _repository.GetByIdAsync(request.id);

                if (entity == null)
                {
                    return Error.NotFound(message.PlainText, ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
                }

                 await _repository.DeleteAsync(entity);
                return true;
            }

            return false;
        }
    }
}