using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SharedLibrary.Interfaces;

namespace SharedLibrary.CustomDataAnotator
{
    public class ExistsInDatabaseAttribute<TDbContext, TUnitOfWork> : ValidationAttribute where TDbContext : DbContext where TUnitOfWork : class
    {
        private readonly string _tableName;
        private readonly string _columnName;

        public ExistsInDatabaseAttribute(string tableName, string columnName)
        {
            _tableName = tableName ?? throw new ArgumentNullException(nameof(tableName));
            _columnName = columnName ?? throw new ArgumentNullException(nameof(columnName));
        }

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
