//using Microsoft.EntityFrameworkCore;
//using SharedLibrary.Interfaces;
//using System.ComponentModel.DataAnnotations; // Import the namespace

//using SharedLibrary.Interfaces;
//using Microsoft.Extensions.DependencyInjection; // Import the namespace containing IUnitOfWork

//namespace SharedLibrary.CustomDataAnotator
//{
//    public static class ValidatorHelper
//    {
//        public static bool AclRoleExists<TDbContext>(ulong[] roleIds) where TDbContext : DbContext
//        {
//            var serviceProvider = new ServiceCollection().BuildServiceProvider();
//            var unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork<TDbContext>>();
//            var dbContext = unitOfWork.ApplicationDbContext;

//            foreach (var roleId in roleIds)
//            {
//                if (!dbContext.AclRoles.Any(r => r.Id == roleId))
//                {
//                    return false;
//                }
//            }

//            return true;
//        }
//    }
//}