using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Main.Application.Common.Interfaces.Services;

#pragma warning disable CS8765 // Possible null reference argument.
namespace SharedKernel.Main.Infrastructure.Attributes
{
    public class ExistsInDatabaseAttribute<TDbContext, TUnitOfWork>(string tableName, string columnName)
        : ValidationAttribute
        where TDbContext : DbContext
        where TUnitOfWork : class
    {
        private readonly string _tableName = tableName ?? throw new ArgumentNullException(nameof(tableName));
        private readonly string _columnName = columnName ?? throw new ArgumentNullException(nameof(columnName));

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var serviceProvider = validationContext.GetService(typeof(IServiceProvider)) as IServiceProvider;
            if (serviceProvider == null)
            {
                throw new InvalidOperationException("Could not obtain the IServiceProvider.");
            }

            var unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork<TDbContext, TUnitOfWork>>();
            var dbContext = unitOfWork.ApplicationDbContext;

            // Get the DbSet property dynamically based on the table name
            var dbSetProperty = dbContext.GetType().GetProperties()
                .FirstOrDefault(p => p.PropertyType.IsGenericType &&
                                     p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>) &&
                                     p.PropertyType.GetGenericArguments()[0].Name == _tableName);

            if (dbSetProperty == null)
            {
                return new ValidationResult($"Table '{_tableName}' not found in the DbContext.");
            }

#pragma warning disable CS8600 // Dereference of a possibly null reference.
#pragma warning disable CS8603 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Dereference of a possibly null reference.
            // Get the DbSet instance
            var dbSet = (IQueryable<object>)dbSetProperty.GetValue(dbContext);


            // Construct the LINQ query dynamically
            var query = dbSet.Where(e => EF.Property<object>(e, _columnName).Equals(value));
            // If there exists any record with the same value in the specified column
            if (!query.Any())
            {
                return new ValidationResult($"The '{value}' is not exist.");
            }
          

            return ValidationResult.Success;
        }
    }
}
