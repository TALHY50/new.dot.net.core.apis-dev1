﻿using ErrorOr;
using FluentValidation;
using IMT.App.Application.Interfaces.Repositories;
using IMT.App.Infrastructure.Persistence.Context;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants;


namespace Admin.App.Application.Features.BusinessHourAndWeekend;

public class DeleteBusinessHourAndWeekendByIdController : ApiControllerBase
{
    //[Authorize(Policy = "HasPermission")]
    [HttpDelete(Routes.DeleteBusinessHourAndWeekendUrl, Name = Routes.DeleteBusinessHourAndWeekendName)]
    public async Task<ActionResult<ErrorOr<bool>>> Delete(uint id)
    {
        return await Mediator.Send(new DeleteBusinessHourAndWeekendCommand(id)).ConfigureAwait(false);
    }

    public record DeleteBusinessHourAndWeekendCommand(uint Id) : IRequest<ErrorOr<bool>>;

    public class DeleteBusinessHourAndWeekendCommandValidator : AbstractValidator<DeleteBusinessHourAndWeekendCommand>
    {
        public DeleteBusinessHourAndWeekendCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Business hour and weekend ID is required");
        }
    }

    internal sealed class DeleteBusinessHourAndWeekendCommandHandler(ApplicationDbContext _context, IBusinessHourAndWeekendRepository repository) : IRequestHandler<DeleteBusinessHourAndWeekendCommand, ErrorOr<bool>>
    {
        public async Task<ErrorOr<bool>> Handle(DeleteBusinessHourAndWeekendCommand request, CancellationToken cancellationToken)
        {

            // ToDo delete logic
            var businessHourAndWeekend = await _context.ImtBusinessHoursAndWeekends.FirstAsync(e => e.Id == request.Id, cancellationToken: cancellationToken).ConfigureAwait(false);
            if (businessHourAndWeekend == null)
            {
                return Error.NotFound("Business hour and weekend not found!");
            }
            _context.ImtBusinessHoursAndWeekends.Remove(businessHourAndWeekend);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            // need to modify return type
            return true;
        }
    }




}
