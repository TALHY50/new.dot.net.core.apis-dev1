﻿//using System.ComponentModel.DataAnnotations;
//using App.Ports.Repositories;
//using App.Ports.Repositories.Company;

//namespace ACL.Infrastructure.Security.CustomDataAnotator
//{
//    public class CountryExistsAttribute : ValidationAttribute
//    {
//        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
//        {
//            var serviceProvider = validationContext.GetService(typeof(IServiceProvider)) as IServiceProvider;
//            var _country = serviceProvider.GetService(typeof(IAclCountryRepository)) as IAclCountryRepository;

//            if (value == null || _country == null)
//            {
//                return new ValidationResult($"The value is not null.");
//            }
//            bool country = _country.ExistById((ulong)value);
//            if (!country)
//            {
//                return new ValidationResult($"The '{value}' is not exist.");
//            }

//            return ValidationResult.Success;
//        }
//    }
//}

namespace App.Infrastructure.Security.CustomDataAnotator;