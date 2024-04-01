using Microsoft.EntityFrameworkCore;
using SharedLibrary.Interfaces;
using SharedLibrary.Interfaces.Repositories;
using SharedLibrary.Models;
using SharedLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Repositories
{
    public class CurrencyConversionRateRepository : GenericRepository<Models.CurrencyConversionRate>, ICurrencyConversionRateRepository
    {
        public CurrencyConversionRateRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public CurrencyConversionRate? FindById(string? id)
        {
            return UnitOfWork.ApplicationDbContext.CurrencyConversionRates.FirstOrDefault(x => x.Id == id);
        }

       

        public void InsertOrUpdateAsync(CurrencyConversionRate entity)
        {
            var existingEntity =  UnitOfWork.ApplicationDbContext.CurrencyConversionRates.FirstOrDefault(e => e.Id == entity.FromCurrencyCode + entity.ToCurrencyCode); 

            if (existingEntity != null)
            {
                // Update the existing entity
                existingEntity.Rate = entity.Rate;
                existingEntity.UpdatedAt = DateTime.UtcNow;
               
                UnitOfWork.CurrencyConversionRateRepository.Update(existingEntity);
            }
            else
            {
                // Insert the new entity
                UnitOfWork.CurrencyConversionRateRepository.Add(entity);
            }

             UnitOfWork.ApplicationDbContext.SaveChanges();
        }
    }
}
