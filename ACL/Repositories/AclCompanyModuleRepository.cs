
using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Interfaces.Repositories;
using ACL.Requests.V1;
using Microsoft.EntityFrameworkCore;

namespace ACL.Repositories
{
    public class AclCompanyModuleRepository : GenericRepository<AclCompanyModule>, IAclCompanyModuleRepository
    {
        public AclCompanyModuleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public AclCompanyModule? FindByCompanyId(ulong id)
        {
            return UnitOfWork.ApplicationDbContext.AclCompanyModules.FirstOrDefault(x => x.CompanyId == id);
        }
        public AclCompanyModule FindById(ulong id)
        {
            var aclCompany = UnitOfWork.ApplicationDbContext.AclCompanyModules.FirstOrDefault(x => x.CompanyId == id);

            if (aclCompany == null)
            {
                throw new Exception($"AclCompanyModule with ID {id} not found.");
            }

            return aclCompany;
        }


        public AclCompanyModule? FindByModuleId(ulong id)
        {
            return UnitOfWork.ApplicationDbContext.AclCompanyModules.FirstOrDefault(x => x.ModuleId == id);
        }

        public AclCompanyModule AddAclCompanyModule(AclCompanyModuleRequest request)
        {
            if (!IsValidForCreateOrUpdate(request.CompanyId, request.ModuleId))
            {
                throw new InvalidOperationException("Company ID and Module ID combination is not unique.");
            }

            var aclCompany = new AclCompanyModule
            {
                CompanyId = request.CompanyId,
                ModuleId = request.ModuleId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            try
            {
                UnitOfWork.ApplicationDbContext.Add(aclCompany);
                UnitOfWork.ApplicationDbContext.SaveChanges();
                UnitOfWork.ApplicationDbContext.Entry(aclCompany).Reload();
                return aclCompany;
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        public AclCompanyModule EditAclCompanyModule(ulong Id, AclCompanyModuleRequest request)
        {
            var aclCompany = FindById(Id);
            if (aclCompany == null)
            {
                throw new InvalidOperationException("Not found!");
            }
            else
            {
                if (!IsValidForCreateOrUpdate(request.CompanyId, request.ModuleId,Id))
                {
                    throw new InvalidOperationException("Company ID and Module ID is not unique.");
                }

                // Update the properties of the existing entity
                aclCompany.CompanyId = request.CompanyId;
                aclCompany.ModuleId = request.ModuleId;
                aclCompany.UpdatedAt = DateTime.Now;
            }


            try
            {
                // Update the entity in the database
                UnitOfWork.ApplicationDbContext.Update(aclCompany);
                UnitOfWork.ApplicationDbContext.SaveChanges();
                return aclCompany;
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
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

        public bool IsValidForCreateOrUpdate(ulong companyId, ulong moduleId, ulong id = 0)
        {
            if (id == 0)
            {
                return !UnitOfWork.ApplicationDbContext.AclCompanyModules
                    .Any(x => x.CompanyId == companyId && x.ModuleId == moduleId);
            }
            else
            {
                return !UnitOfWork.ApplicationDbContext.AclCompanyModules
               .Any(x => (x.CompanyId == companyId || x.ModuleId == moduleId) && x.Id != id);
            }
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
