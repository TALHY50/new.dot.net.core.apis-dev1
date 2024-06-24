using ADMIN.Application.Ports.Services.Interfaces.Provider;
using ADMIN.Infrastructure.Persistence.Configurations;
using ADMIN.Infrastructure.Persistence.Services.Provider;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Interfaces;
using SharedLibrary.Services;

namespace ADMIN
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            Env.NoClobber().TraversePath().Load();

            var server = Env.GetString("DB_HOST");
            var database = Env.GetString("DB_DATABASE");
            var userName = Env.GetString("DB_USERNAME");
            var password = Env.GetString("DB_PASSWORD");
            var port = Env.GetString("DB_PORT");

            var connectionString = $"server={server};database={database};User ID={userName};Password={password};CharSet=utf8mb4;" ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySQL(connectionString, options =>
                {
                    options.EnableRetryOnFailure();
                }), ServiceLifetime.Transient);


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // dependency start
            builder.Services.AddScoped<IProviderService, ProviderService>();
            // dependency end

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
            app.Run();
        }
    }
}
