using SharedKernel.Main.Domain.Notification.Todos;
using SharedKernel.Main.Domain.Notification.ValueObjects;
using SharedKernel.Main.Infrastructure.Persistence.Notification.Context;

namespace SharedKernel.Main.Infrastructure.Persistence.Notification.Seeds;

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