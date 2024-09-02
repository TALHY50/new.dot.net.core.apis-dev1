using DotNetEnv;
using SharedKernel.Main.Application.Interfaces.Services;

namespace SharedKernel.Main.Infrastructure.Utilities;

public class ConnectionManager : IConnectionManager
{
    public static string GetDbConnectionString()
    {
        Env.NoClobber().TraversePath().Load();
        var server = Env.GetString("DB_HOST");
        var database = Env.GetString("DB_DATABASE");
        var userName = Env.GetString("DB_USERNAME");
        var password = Env.GetString("DB_PASSWORD");
        var port = Env.GetString("DB_PORT");
        var connectionString = $"server={server};database={database};port={port};User ID={userName};Password={password};CharSet=utf8mb4;" ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        return connectionString;
    }

    public static string GetRedisConnectionString()
    {
        Env.NoClobber().TraversePath().Load();
        var redisHost = Env.GetString("REDIS_HOST");
        var redistPort = Env.GetString("REDIS_PORT");
        var redisPassword = Env.GetString("REDIS_PASSWORD");
        var redistConnectionString = $"{redisHost}:{redistPort},password={redisPassword}";
        return redistConnectionString;
    }
}