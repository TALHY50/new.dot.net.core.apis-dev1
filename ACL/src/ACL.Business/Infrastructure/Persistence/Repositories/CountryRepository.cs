﻿using ACL.Business.Application.Interfaces.Repositories;
using ACL.Business.Domain.Entities;
using ACL.Business.Infrastructure.Auth.Auth;
using ACL.Business.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Http;

namespace ACL.Business.Infrastructure.Persistence.Repositories
{
    /// <inheritdoc/>
    public class CountryRepository :EfRepository<Country>, ICountryRepository
    {
        readonly ApplicationDbContext _dbContext;
        public static IHttpContextAccessor ContextAccessor { get; private set; }

        /// <inheritdoc/>
        public CountryRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor):base(dbContext)
        {
            this._dbContext = dbContext;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
            ContextAccessor = httpContextAccessor;
            AppAuth.Initialize(ContextAccessor, dbContext);
            AppAuth.SetAuthInfo(ContextAccessor);
        }
        /// <inheritdoc/>
        public bool ExistById(uint id)
        {
            bool exist = false;
            var aclCountry = this._dbContext.AclCountries.Find(id);
            if (aclCountry != null)
            {
                exist = true;
            }
            return exist;
        }

        /// <inheritdoc/>
        public List<Country>? All()
        {
            try
            {
                return this._dbContext.AclCountries.ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public Country? Find(uint id)
        {
            try
            {
                return this._dbContext.AclCountries.Find(id);
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public Country? Add(Country country)
        {
            try
            {
                this._dbContext.AclCountries.Add(country);
                this._dbContext.SaveChanges();
                this._dbContext.Entry(country).ReloadAsync();
                return country;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public Country? Update(Country country)
        {
            try
            {
                this._dbContext.AclCountries.Update(country);
                this._dbContext.SaveChanges();
                this._dbContext.Entry(country).ReloadAsync();
                return country;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <inheritdoc/>
        public Country? Delete(Country country)
        {
            try
            {
                this._dbContext.AclCountries.Remove(country);
                this._dbContext.SaveChangesAsync();
                return country;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }
        /// <inheritdoc/>
        public Country? Delete(uint id)
        {
            try
            {
                var delete = Find(id);
#pragma warning disable CS8604 // Possible null reference argument.
                this._dbContext.AclCountries.Remove(delete);
#pragma warning restore CS8604 // Possible null reference argument.
                this._dbContext.SaveChanges();
                return delete;
            }
            catch (Exception)
            {
                throw new Exception("Country not exist");
            }

        }
    }
}
