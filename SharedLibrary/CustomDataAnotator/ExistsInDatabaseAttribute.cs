using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SharedLibrary.Interfaces;

namespace ACL.Requests.CustomDataAnotator
{
    public class ExistsInDatabaseAttribute<TDbContext> : ValidationAttribute where TDbContext : DbContext
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

            var unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork<TDbContext>>();
            var dbContext = unitOfWork.ApplicationDbContext;

            var dbSet = dbContext.Set<object>().AsQueryable();

            var entityType = dbContext.Model.FindEntityType(typeof(TDbContext).AssemblyQualifiedName);
            var tableName = entityType.GetTableName();

            var propertyName = _columnName; // You may need to adjust this based on your entity property name

            var query = dbSet.Where(e => EF.Property<object>(e, propertyName).Equals(value));

            if (!query.Any())
            {
                return new ValidationResult($"The value '{value}' does not exist in the database.");
            }

            return ValidationResult.Success;
        }
    }
}
