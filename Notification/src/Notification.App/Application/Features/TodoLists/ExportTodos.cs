using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Notification.App.Application.Interfaces.Services;
using Notification.App.Domain.Entities.Todos;
using Notification.App.Infrastructure.Persistence.Context;

using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Interfaces;
using SharedKernel.Main.Application.Common.Interfaces.Services;

namespace Notification.App.Application.Features.TodoLists;

public class ExportTodosController : ApiControllerBase
{
    [HttpGet("/api/todo-lists/{id}")]
    public async Task<FileResult> Get(int id)
    {
        var vm = await Mediator.Send(new ExportTodosQuery(id));

        return File(vm.Content, vm.ContentType, vm.FileName);
    }
}

public record ExportTodosQuery(int ListId) : IRequest<ExportTodosVm>;

public record ExportTodosVm(string FileName, string ContentType, byte[] Content);

public class ExportTodosQueryHandler(ApplicationDbContext context, ICsvFileBuilder fileBuilder) : IRequestHandler<ExportTodosQuery, ExportTodosVm>
{
    private readonly ApplicationDbContext _context = context;
    private readonly ICsvFileBuilder _fileBuilder = fileBuilder;

    public async Task<ExportTodosVm> Handle(ExportTodosQuery request, CancellationToken cancellationToken)
    {
        var records = await _context.TodoItems
                .Where(t => t.ListId == request.ListId)
                .Select(item => new TodoItemRecord(item.Title, item.Done))
                .ToListAsync(cancellationToken);

        var vm = new ExportTodosVm(
            "TodoItems.csv",
            "text/csv",
            _fileBuilder.BuildTodoItemsFile(records));

        return vm;
    }
}