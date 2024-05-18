using System.ComponentModel.DataAnnotations;
using ACL.UseCases.Interfaces.Repositories.V1;

namespace ACL.Infrastructure.Security.CustomDataAnotator
{
    public class CountryExistsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var serviceProvider = validationContext.GetService(typeof(IServiceProvider)) as IServiceProvider;
            var _country = serviceProvider.GetService(typeof(IAclCountryRepository)) as IAclCountryRepository;

            if (value == null || _country == null)
            {
                return new ValidationResult($"The value is not null.");
            }
            bool country = _country.ExistById((ulong)value);
            if (!country)
            {
                return new ValidationResult($"The '{value}' is not exist.");
            }

            return ValidationResult.Success;
        }
    }
}
