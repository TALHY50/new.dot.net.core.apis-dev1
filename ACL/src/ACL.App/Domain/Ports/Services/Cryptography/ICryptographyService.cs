namespace ACL.App.Domain.Ports.Services.Cryptography

{
    public interface ICryptographyService
    {
        string GenerateSalt();

        string HashPassword(string password, string salt);
    }
}
