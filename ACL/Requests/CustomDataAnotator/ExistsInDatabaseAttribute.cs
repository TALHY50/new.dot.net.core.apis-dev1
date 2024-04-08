namespace ACL.Requests.CustomDataAnotator
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using ACL.Interfaces;
    using ACL.Requests.CustomDataAnotator;

    public class ExistsInDatabaseAttribute : ValidationAttribute
    {
        private readonly Type _tableType;

        public ExistsInDatabaseAttribute(Type tableType)
        {
            _tableType = tableType;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var serviceProvider = validationContext.GetService(typeof(IServiceProvider)) as IServiceProvider;
            var unitOfWork = serviceProvider.GetService(typeof(IUnitOfWork)) as IUnitOfWork;
            var dbContext = unitOfWork.ApplicationDbContext;
            bool exists = dbContext.AclRoles.Any(c=>c.Id==(ulong)value);

            if (!exists)
            {
                return new ValidationResult(ErrorMessage ?? $"The {validationContext.DisplayName} does not exist in the database.");
            }

            return ValidationResult.Success;
        }
    }

}
