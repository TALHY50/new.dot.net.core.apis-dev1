namespace SharedKernel.Main.Application.Interfaces.Services

{
    public interface ICryptography
    {
        string GenerateSalt();

        string HashPassword(string password, string salt);
    }
}
