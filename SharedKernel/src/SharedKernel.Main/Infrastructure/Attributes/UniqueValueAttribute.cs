﻿//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using Microsoft.AspNetCore.Http;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using App.Interfaces;

//namespace ACL.Requests.CustomDataAnotator
//{
//    public class UniqueValueAttribute<TDbContext> : ValidationAttribute where TDbContext : DbContext
//    {
//        private readonly string _tableName;
//        private readonly string _columnName;

//        public UniqueValueAttribute(string tableName, string columnName)
//        {
//            _tableName = tableName ?? throw new ArgumentNullException(nameof(tableName));
//            _columnName = columnName ?? throw new ArgumentNullException(nameof(columnName));
//        }

//        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
//        {
//            var serviceProvider = validationContext.GetService(typeof(IServiceProvider)) as IServiceProvider;
//            var httpContext = (serviceProvider.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor)?.HttpContext;
//            var idValue = httpContext?.Request.RouteValues["id"]?.ToString();

//            var unitOfWork = serviceProvider.GetService(typeof(IUnitOfWork<TDbContext>)) as IUnitOfWork<TDbContext>;
//            var dbContext = unitOfWork.ApplicationDbContext;

//            // Get the DbSet property dynamically based on the table name
//            var dbSetProperty = dbContext.GetType().GetProperties()
//                .FirstOrDefault(p => p.PropertyType.IsGenericType &&
//                                     p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>) && p.PropertyType.GetGenericArguments()[0].Name == _tableName);       
//            if (dbSetProperty == null)
//        {
//            return new ValidationResult($"Table '{_tableName}' not found in the DbContext.");
//        }

//        // Get the DbSet instance
//        var dbSet = (IQueryable<object>)dbSetProperty.GetValue(dbContext);

//        if (idValue != null)
//        {
//            ulong Id = 0;
//            Id = ulong.Parse(idValue);

//            // Construct the LINQ query dynamically
//            var query = dbSet.Where(e => EF.Property<object>(e, "Id").Equals(Id));
//            // If there exists any record with the same value in the specified column
//            if (!query.Any())
//            {
//                return new ValidationResult($"The id '{Id}' does not exist.");
//            }

//            var editquery = dbSet.Where(e => EF.Property<object>(e, _columnName).Equals(value) && !EF.Property<object>(e, "Id").Equals(Id));
//            // If there exists any record with the same value in the specified column
//            if (editquery.Any())
//            {
//                return new ValidationResult($"The '{value}' is not unique.");
//            }
//        }
//        else
//        {
//            // Construct the LINQ query dynamically
//            var query = dbSet.Where(e => EF.Property<object>(e, _columnName).Equals(value));
//            // If there exists any record with the same value in the specified column
//            if (query.Any())
//            {
//                return new ValidationResult($"The '{value}' is not unique.");
//            }
//        }

//        return ValidationResult.Success;
//    }
//}
//}

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Main.Application.Interfaces;

#pragma warning disable CS8600 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Possible null reference argument.
#pragma warning disable CS8603 // Possible null reference argument.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8765 // Possible null reference argument.
namespace SharedKernel.Main.Infrastructure.Attributes
{
    public class UniqueValueAttribute<TDbContext, TUnitOfWork>(string tableName, string columnName)
        : ValidationAttribute
        where TDbContext : DbContext
        where TUnitOfWork : class
    {
        private readonly string _tableName = tableName ?? throw new ArgumentNullException(nameof(tableName));
        private readonly string _columnName = columnName ?? throw new ArgumentNullException(nameof(columnName));

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var serviceProvider = validationContext.GetService(typeof(IServiceProvider)) as IServiceProvider;
            var httpContext = (serviceProvider.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor)?.HttpContext;
            var idValue = httpContext?.Request.RouteValues["id"]?.ToString();

            var unitOfWork = serviceProvider.GetService(typeof(IUnitOfWork<TDbContext,TUnitOfWork>)) as IUnitOfWork<TDbContext,TUnitOfWork>;
            var dbContext = unitOfWork.ApplicationDbContext;

            // Get the DbSet property dynamically based on the table name
            var dbSetProperty = dbContext.GetType().GetProperties()
                .FirstOrDefault(p => p.PropertyType.IsGenericType &&
                                     p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>)
                                     && p.PropertyType.GetGenericArguments()[0].Name == _tableName);
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

                // Construct the LINQ query dynamically
                var query = dbSet.Where(e => EF.Property<object>(e, "Id").Equals(Id));
                // If there exists any record with the same value in the specified column
                if (!query.Any())
                {
                    return new ValidationResult($"The id '{Id}' does not exist.");
                }

                var editquery = dbSet.Where(e => EF.Property<object>(e, _columnName).Equals(value) && !EF.Property<object>(e, "Id").Equals(Id));
                // If there exists any record with the same value in the specified column
                if (editquery.Any())
                {
                    return new ValidationResult($"The '{value}' is not unique.");
                }
            }
            else
            {
                // Construct the LINQ query dynamically
                var query = dbSet.Where(e => EF.Property<object>(e, _columnName).Equals(value));
                // If there exists any record with the same value in the specified column
                if (query.Any())
                {
                    return new ValidationResult($"The '{value}' is not unique.");
                }
            }

            return ValidationResult.Success;
        }
    }
}