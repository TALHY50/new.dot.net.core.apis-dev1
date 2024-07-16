using System.Globalization;

using CsvHelper.Configuration;

using Notification.Main.Domain.Todos;

namespace Notification.Main.Infrastructure.Files;

public class TodoItemRecordMap : ClassMap<TodoItemRecord>
{
    public TodoItemRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
    }
}