using Microsoft.Extensions.Logging;

namespace SharedLibrary.Interfaces;

public interface ILogService
{

    public Dictionary<string, object> NewLog(string action = null);

    public void LogSync(Dictionary<string, object> log);
    public Task<bool> LogAsync(Dictionary<string, object> log);
    
    public Task<bool> LogAsync(Exception log);

    public Task<bool> LogAsync<T>(T any);

    public ILogger Logger(Type t = null);

    public ILoggerFactory LoggerFactory();

    public void LogWrite(string fileName, string logMessage, bool shouldDelete = false);

}