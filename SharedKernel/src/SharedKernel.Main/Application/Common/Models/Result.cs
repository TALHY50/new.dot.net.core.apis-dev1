namespace SharedKernel.Main.Application.Common.Models;

public class Result
{
    internal Result(Status succeeded, IEnumerable<string> errors)
    {
        Succeeded = succeeded;
        Errors = errors.ToArray();
    }

    public Status Succeeded { get; set; }

    public string[] Errors { get; set; }

    public static Result Success()
    {
        return new Result(Status.Completed, Array.Empty<string>());
    }

    public static Result Failure(IEnumerable<string> errors)
    {
        return new Result(Status.Failed, errors);
    }

    public static Result Undetermined(IEnumerable<string> errors)
    {
        return new Result(Status.Undetermined, errors);
    }

    public static Result Pending(IEnumerable<string> errors)
    {
        return new Result(Status.Undetermined, errors);
    }
}