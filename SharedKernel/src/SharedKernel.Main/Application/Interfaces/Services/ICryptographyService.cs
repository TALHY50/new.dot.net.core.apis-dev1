namespace SharedKernel.Main.Application.Interfaces.Services

{
    public interface ICryptographyService
    {
        string GenerateSalt();

        string HashPassword(string password, string salt);
    }
}
