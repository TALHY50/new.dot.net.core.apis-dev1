using System.Globalization;

using CsvHelper.Configuration;

using SharedKernel.Main.Domain.Notification.Todos;

namespace Notification.App.Infrastructure.Files;

public class TodoItemRecordMap : ClassMap<TodoItemRecord>
{
    public TodoItemRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
    }
}