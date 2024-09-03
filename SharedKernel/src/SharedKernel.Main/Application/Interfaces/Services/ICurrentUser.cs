namespace SharedKernel.Main.Application.Interfaces.Services;

public interface ICurrentUser
{
    string? UserId { get; set; }
}