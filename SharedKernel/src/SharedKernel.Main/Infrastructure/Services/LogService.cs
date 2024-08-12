using System.Reflection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SharedKernel.Main.Application.Interfaces;

namespace SharedKernel.Main.Infrastructure.Services;

public class LogService : ILogService
{
    private string m_exePath = string.Empty;
    private readonly ILogger _logger;
    private readonly ILoggerFactory _loggerFactory;
    public LogService(ILogger logger, ILoggerFactory loggerFactory)
    {
        _logger = logger;
        _loggerFactory = loggerFactory;
    }

    public Dictionary<string, object> NewLog(string? action = "")
    {
        var log = new Dictionary<string, object>() { };
        log["action"] = action??"";
        return log;
    }

    public bool Log(Dictionary<string, object> log)
    {
        _logger.LogInformation("{@log}", JsonConvert.SerializeObject(log));
        return true;

    }


    public void LogSync(Dictionary<string, object> log)
    {
        _logger.LogInformation("{@log}", JsonConvert.SerializeObject(log));

    }

    public bool Log(Exception log)
    {
        _logger.LogError(log.ToString());
        return true;

    }

    public bool Log<T>(T any)
    {
        _logger.LogInformation("{@log}", JsonConvert.SerializeObject((any as Dictionary<string, object>)));
        return true;

    }

    public ILogger Logger(Type? t = null)
    {
        if (t != null)
        {
            return _loggerFactory.CreateLogger(t);
        }
        return _logger;
    }

    public ILoggerFactory LoggerFactory()
    {
        return _loggerFactory;
    }



    public void LogWrite(string fileName, string logMessage, bool shouldDelete = false)
    {
#pragma warning disable CS8601 // Possible null reference assignment.
        m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
#pragma warning restore CS8601 // Possible null reference assignment.
        try
        {
            string path = m_exePath??"";
            string searchString = "bin/";

            int index = path.IndexOf(searchString);

            if (index != -1)
            {
                path = path.Substring(0, index - 1);

            }

            //path = path + "/Logs/" + fileName;

           // path = Paths.logPath() + "/" + fileName;   /// Need To uncomment

            if (shouldDelete && File.Exists(path))
            {
                File.Delete(path);
            }

            using (StreamWriter w = File.AppendText(path))
            {
                Log(logMessage, w);
            }
        }
        catch (Exception)
        {
        }
    }

    public static void Log(string logMessage, TextWriter txtWriter)
    {
        try
        {
            txtWriter.WriteLine("{0:yyyy\'-\'MM\'-\'dd\'T\'HH\':\'mm\':\'ss}", DateTime.Now);
            txtWriter.WriteLine("{0}", logMessage);
            txtWriter.WriteLine();
            txtWriter.WriteLine();
            txtWriter.WriteLine();


        }
        catch (Exception)
        {
        }
    }

}