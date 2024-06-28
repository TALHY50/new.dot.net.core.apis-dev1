//using System.ComponentModel.DataAnnotations;
//using ACL.Application.Ports.Repositories;
//using ACL.Application.Ports.Repositories.Company;
//using Microsoft.AspNetCore.Http;

//namespace ACL.Infrastructure.Security.CustomDataAnotator
//{
//    public class StateNameUniqueAttribute : ValidationAttribute
//    {
//        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
//        {
//            ulong id = 0;
//            var serviceProvider = validationContext.GetService(typeof(IServiceProvider)) as IServiceProvider;
          
//            var httpContext = (serviceProvider.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor)?.HttpContext;
//            var idValue = httpContext?.Request.RouteValues["id"]?.ToString();

//            var _state = serviceProvider.GetService(typeof(IAclStateRepository)) as IAclStateRepository;
            

//            if (value == null || _state == null)
//            {
//                return new ValidationResult($"The value is not null.");
//            }
//            if(idValue != null)
//            {
//                id = ulong.Parse(idValue);
//            }
//            bool state = _state.ExistByName(id,(string)value);
//            if (state)
//            {
//                return new ValidationResult($"The '{value}' is not unique.");
//            }

//            return ValidationResult.Success;
//        }
//    }
//}

namespace ACL.Application.Infrastructure.Security.CustomDataAnotator;