namespace SharedKernel.Main.Application.Common.Interfaces.Services

{
    public interface ICryptographyService
    {
        string GenerateSalt();

        string HashPassword(string password, string salt);
    }
}
