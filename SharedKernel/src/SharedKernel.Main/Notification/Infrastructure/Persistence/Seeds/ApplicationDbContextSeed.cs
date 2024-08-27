using SharedKernel.Main.Notification.Domain.Entities.Todos;
using SharedKernel.Main.Notification.Domain.Entities.ValueObjects;
using SharedKernel.Main.Notification.Infrastructure.Persistence.Context;

namespace SharedKernel.Main.Notification.Infrastructure.Persistence.Seeds;

public static class ApplicationDbContextSeed
{
    public static async Task SeedSampleDataAsync(ApplicationDbContext context)
    {
        // Seeds, if necessary
        if (!Queryable.Any<TodoList>(context.TodoLists))
        {
            context.TodoLists.Add(new TodoList
            {
                Title = "Shopping",
                Colour = Colour.Blue,
                Items =
                    {
                        new TodoItem { Title = "Apples", Done = true },
                        new TodoItem { Title = "Milk", Done = true },
                        new TodoItem { Title = "Bread", Done = true },
                        new TodoItem { Title = "Toilet paper" },
                        new TodoItem { Title = "Pasta" },
                        new TodoItem { Title = "Tissues" },
                        new TodoItem { Title = "Tuna" },
                        new TodoItem { Title = "Water" },
                    },
            });

            await context.SaveChangesAsync();
        }
    }
}