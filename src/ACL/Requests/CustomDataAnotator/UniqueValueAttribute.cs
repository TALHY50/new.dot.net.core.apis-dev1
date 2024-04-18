
using System.ComponentModel.DataAnnotations;
using ACL.Interfaces;
using Microsoft.EntityFrameworkCore;

public class UniqueValueAttribute : ValidationAttribute
{
    private readonly string _tableName;
    private readonly string _columnName;

    public UniqueValueAttribute(string tableName, string columnName)
    {
        _tableName = tableName ?? throw new ArgumentNullException(nameof(tableName));
        _columnName = columnName ?? throw new ArgumentNullException(nameof(columnName));
    }

    //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //{
    //    var serviceProvider = validationContext.GetService(typeof(IServiceProvider)) as IServiceProvider;
    //    var unitOfWork = serviceProvider.GetService(typeof(IUnitOfWork)) as IUnitOfWork;
    //    var dbContext = unitOfWork.ApplicationDbContext;

    //    // Construct the generic type for DbSet
    //    var dbSetType = typeof(Microsoft.EntityFrameworkCore.DbSet<>).MakeGenericType(Type.GetType($"ACL.Database.Models.{_tableName}"));

    //    // Get the DbSet property from the DbContext
    //    var dbSetProperty = dbContext.GetType().GetProperty(_tableName);

    //    // Get the Any method from IQueryable interface
    //    var anyMethod = typeof(Queryable).GetMethods().FirstOrDefault(m =>
    //        m.Name == "Any" &&
    //        m.GetParameters().Length == 2 &&
    //        m.GetParameters()[1].ParameterType.GetGenericArguments().Length == 1
    //    );

    //    // Construct the generic Any method
    //    var anyMethodGeneric = anyMethod.MakeGenericMethod(Type.GetType($"ACL.Database.Models.{_tableName}"));

    //    // Call Any method dynamically
    //    var exists = (bool)anyMethodGeneric.Invoke(null, new[] { dbSetProperty.GetValue(dbContext), value });

    //    if (!exists)
    //    {
    //        return ValidationResult.Success;
    //    }

    //    return new ValidationResult($"The value '{value}' already exists in the '{_columnName}' column of the '{_tableName}' table.");
    //}

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var httpContext = (validationContext.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor)?.HttpContext;
        var idValue = httpContext?.Request.RouteValues["id"]?.ToString();

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

        if (idValue != null)
        {
            ulong Id = 0;
            Id = ulong.Parse(idValue);
            var editquery = dbSet.Where(e => EF.Property<object>(e, _columnName).Equals(value) && !EF.Property<object>(e, "Id").Equals(Id));
            // If there exists any record with the same value in the specified column
            if (editquery.Any())
            {
                return new ValidationResult($"The value '{value}' is not unique in {_tableName}.");
            }
        }
        else
        {
            // Construct the LINQ query dynamically
            var query = dbSet.Where(e => EF.Property<object>(e, _columnName).Equals(value));
            // If there exists any record with the same value in the specified column
            if (query.Any())
            {
                return new ValidationResult($"The value '{value}' is not unique in {_tableName}.");
            }
        }
       

        return ValidationResult.Success;
    }
}
