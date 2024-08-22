namespace SharedKernel.Main.Application.Common.Interfaces.Services
{
    public interface ICacheService
    {
        void Set<T>(string key, T value, TimeSpan? expirationTime = null);
        T? Get<T>(string key);
        void Remove(string key);
        bool Has(string key);
    }
}
