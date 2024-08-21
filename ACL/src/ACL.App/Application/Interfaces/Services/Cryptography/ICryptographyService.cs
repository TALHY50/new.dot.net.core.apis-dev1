namespace ACL.App.Application.Interfaces.Services.Cryptography

{
    public interface ICryptographyService
    {
        string GenerateSalt();

        string HashPassword(string password, string salt);
    }
}
