namespace SharedKernel.Main.Application.Models;

public class Status
{
    static Status()
    {
    }

    private Status()
    {
    }

    private Status(int type)
    {
        Type = type;
    }

    public static Status From(int type)
    {
        var status = new Status { Type = type };

        return status;
    }

    public static Status Undetermined => new(0);

    public static Status Completed => new(1);

    public static Status Pending => new(3);

    public static Status Failed => new(2);

    public int Type { get; private set; } = 0;

    public static implicit operator int(Status type)
    {
        return (int)type;
    }

    public static explicit operator Status(int type)
    {
        return From(type);
    }
}