using ACL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace ACL.Requests.CustomDataAnotator
{
    public class UniqueValueAttribute : ValidationAttribute
    {
        private readonly string _tableName;
        private readonly string _columnName;

        public UniqueValueAttribute(string tableName, string columnName)
        {
            _tableName = tableName ?? throw new ArgumentNullException(nameof(tableName));
            _columnName = columnName ?? throw new ArgumentNullException(nameof(columnName));
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var serviceProvider = validationContext.GetService(typeof(IServiceProvider)) as IServiceProvider;
            var unitOfWork = serviceProvider.GetService(typeof(IUnitOfWork)) as IUnitOfWork;

            if (unitOfWork == null)
            {
                throw new InvalidOperationException("IUnitOfWork service is not registered.");
            }

            var dbContext = unitOfWork.ApplicationDbContext;

            var dbSetProperty = dbContext.GetType().GetProperties()
    .FirstOrDefault(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));

            if (dbSetProperty != null)
            {
                var dbSetMethodInfo = dbSetProperty.GetGetMethod();
                // Continue with the rest of the code
                if (dbSetMethodInfo == null)
                {
                    throw new InvalidOperationException("DbContext.Set<T>() method not found.");
                }

                var typeName = $"ACL.Database.Models.{_tableName}";
                var tableType = Type.GetType(typeName);

                if (tableType == null)
                {
                    throw new InvalidOperationException($"Type '{_tableName}' not found.");
                }

                var genericSetMethodInfo = dbSetMethodInfo.MakeGenericMethod(tableType);
                var dbSet = genericSetMethodInfo.Invoke(dbContext, null);

                var anyMethod = typeof(Queryable).GetMethods().First(m => m.Name == "Any" && m.GetParameters().Length == 2);
                var propertyParam = Expression.Parameter(tableType, "e");
                var lambda = Expression.Lambda(Expression.Equal(Expression.Property(propertyParam, _columnName), Expression.Constant(value)), propertyParam);
                var anyMethodGeneric = anyMethod.MakeGenericMethod(tableType);
                var exists = (bool)anyMethodGeneric.Invoke(null, new[] { dbSet, lambda });

                if (!exists)
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult($"The value '{value}' already exists in the '{_columnName}' column of the '{_tableName}' table.");
            }
            else
            {
                // Handle the case where DbSet property is not found
                return new ValidationResult($"The value '{value}' already exists in the '{_columnName}' column of the '{_tableName}' table.");
            }



        }
    }


}
