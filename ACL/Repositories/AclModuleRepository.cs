
using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Interfaces.Repositories;

namespace ACL.Repositories
{
    public class AclModuleRepository : GenericRepository<AclCompanyModule>, IAclModuleRepository
    {
        public AclModuleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public AclCompanyModule FindByCompanyId(ulong id)
        {
            return UnitOfWork.ApplicationDbContext.AclCompanyModules.FirstOrDefault(x => x.CompanyId == id);
        }
        public AclCompanyModule FindById(ulong id)
        {
            return UnitOfWork.ApplicationDbContext.AclCompanyModules.FirstOrDefault(x => x.CompanyId == id);
        }

        public AclCompanyModule FindByModuleId(ulong id)
        {
            return UnitOfWork.ApplicationDbContext.AclCompanyModules.FirstOrDefault(x => x.ModuleId == id);
        }

        public IList<AclCompanyModule> GetAll()
        {
            return UnitOfWork.ApplicationDbContext.AclCompanyModules.ToList();
        }

        public bool IsExistCompanyId(ulong id)
        {
            return UnitOfWork.ApplicationDbContext.AclCompanyModules.Any(x => x.CompanyId == id);
        }

        public bool IsExistModuleId(ulong id)
        {
            return UnitOfWork.ApplicationDbContext.AclCompanyModules.Any(x => x.ModuleId == id);
        }

        public bool IsValidForCreateOrUpdate(ulong companyId, ulong moduleId)
        {
            return !UnitOfWork.ApplicationDbContext.AclCompanyModules.Any(x => x.CompanyId == companyId || x.ModuleId == moduleId);
        }

        public bool UpdateModule(ulong id, AclCompanyModule module)
        {
            var existingModule = UnitOfWork.ApplicationDbContext.AclCompanyModules.Find(id);

            if (existingModule == null)
            {
                return false; // Entity not found, update failed
            }

            existingModule.CompanyId = module.CompanyId;
            existingModule.ModuleId = module.ModuleId;
            existingModule.UpdatedAt = DateTime.Now;

            UnitOfWork.ApplicationDbContext.SaveChanges();
            return true; // Update successful
        }

        public bool DeleteModule(ulong id)
        {
            var module = UnitOfWork.ApplicationDbContext.AclCompanyModules.Find(id);

            if (module == null)
            {
                return false; // Entity not found, deletion failed
            }

            UnitOfWork.ApplicationDbContext.AclCompanyModules.Remove(module);
            UnitOfWork.ApplicationDbContext.SaveChanges();

            return true; // Deletion successful
        }
    }
}
