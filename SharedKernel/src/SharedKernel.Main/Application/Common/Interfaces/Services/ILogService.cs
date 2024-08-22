using Microsoft.Extensions.Logging;

namespace SharedKernel.Main.Application.Common.Interfaces.Services
{
    public interface ILogService
    {

        public Dictionary<string, object> NewLog(string? action = null);

        public void LogSync(Dictionary<string, object> log);
        public bool Log(Dictionary<string, object> log);

        public bool Log(Exception log);

        public bool Log<T>(T any);

        public ILogger Logger(Type? t = null);

        public ILoggerFactory LoggerFactory();

        public void LogWrite(string fileName, string logMessage, bool shouldDelete = false);

    }
}