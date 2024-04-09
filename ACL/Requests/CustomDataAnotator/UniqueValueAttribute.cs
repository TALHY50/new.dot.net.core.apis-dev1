using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ACL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

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
        var dbContext = unitOfWork.ApplicationDbContext;

        // Construct the generic type for DbSet
        var dbSetType = typeof(Microsoft.EntityFrameworkCore.DbSet<>).MakeGenericType(Type.GetType($"ACL.Database.Models.{_tableName}"));

        // Get the DbSet property from the DbContext
        var dbSetProperty = dbContext.GetType().GetProperty(_tableName);

        // Get the Any method from IQueryable interface
        var anyMethod = typeof(Queryable).GetMethods().FirstOrDefault(m =>
            m.Name == "Any" &&
            m.GetParameters().Length == 2 &&
            m.GetParameters()[1].ParameterType.GetGenericArguments().Length == 1
        );

        // Construct the generic Any method
        var anyMethodGeneric = anyMethod.MakeGenericMethod(Type.GetType($"ACL.Database.Models.{_tableName}"));

        // Call Any method dynamically
        var exists = (bool)anyMethodGeneric.Invoke(null, new[] { dbSetProperty.GetValue(dbContext), value });

        if (!exists)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult($"The value '{value}' already exists in the '{_columnName}' column of the '{_tableName}' table.");
    }
}
