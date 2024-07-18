//using System.ComponentModel.DataAnnotations;
//using App.Interfaces;
//using ACL.Contracts.Requests.V1;
//using ACL.Infrastructure.Database;

//namespace ACL.Contracts.Requests.CustomDataAnotator
//{
//    public class UniqueCompanyModuleAttribute : ValidationAttribute
//    {
//        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
//        {
//            var serviceProvider = validationContext.GetService(typeof(IServiceProvider)) as IServiceProvider;
//            ApplicationDbContext dbContext = new ApplicationDbContext();


//            var request = (AclCompanyModuleRequest)validationContext.ObjectInstance;

//            bool isUnique = dbContext.AclCompanyModules
//                                .Any(a => a.CompanyId == request.CompanyId && a.ModuleId == request.ModuleId) && ApplicationDbContext.AclCompanies.Any(x=>x.Id==request.CompanyId) && dbContext.AclModules.Any(x=>x.Id == request.ModuleId);

//            if (!isUnique)
//            {
//                return ValidationResult.Success;
//            }

//            return new ValidationResult("The combination of Company ID and Module ID already exists.");
//        }
//    }
//}

namespace App.Infrastructure.Security.CustomDataAnotator;