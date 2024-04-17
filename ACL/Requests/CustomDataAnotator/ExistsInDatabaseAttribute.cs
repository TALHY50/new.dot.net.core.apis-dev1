
using System.ComponentModel.DataAnnotations;
using ACL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ACL.Requests.CustomDataAnotator
{
    public class ExistsInDatabaseAttribute : ValidationAttribute
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
            var unitOfWork = serviceProvider.GetService(typeof(IUnitOfWork)) as IUnitOfWork;
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
                    return new ValidationResult($"The value '{value}' is not exist in {_tableName}.");
                }
          

            return ValidationResult.Success;

        }
    }

}
