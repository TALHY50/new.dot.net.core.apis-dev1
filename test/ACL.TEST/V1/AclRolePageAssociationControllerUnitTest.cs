using ACL.Controllers.V1;
using ACL.Database;
using ACL.Database.Models;
using ACL.Interfaces;
using ACL.Requests;
using ACL.Requests.V1;
using ACL.Response.V1;
using ACL.Route;
using ACL.Services;
using ACL.Tests;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACL.Tests.V1
{
    public class AclRolePageAssociationControllerUnitTest
    {
        DatabaseConnector dbConnector;
        UnitOfWork unitOfWork;
        RestClient restClient;
        DbContextOptions<ApplicationDbContext> _inMemoryDbContextOptions;
        ApplicationDbContext _inMemoryDbContext;
        public AclRolePageAssociationControllerUnitTest()
        {
            dbConnector = new DatabaseConnector();
            _inMemoryDbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "acl")
                .Options;
            _inMemoryDbContext = new ApplicationDbContext(_inMemoryDbContextOptions);
            unitOfWork = new UnitOfWork(_inMemoryDbContext);
            restClient = new RestClient(dbConnector.baseUrl);
            unitOfWork = new UnitOfWork(dbConnector.dbContext);
            // unitOfWork.ApplicationDbContext = _inMemoryDbContext;
        }
        [Fact]
        public async Task Get_All_AclRolePageAssociation()
        {
            #region  Arrange
            var id = getRandomID();
            #endregion
            #region Act
            var request = new RestRequest(AclRoutesUrl.AclRolePageRouteUrl.List.Replace("{id}", id.ToString()), Method.Get);

            //request.AddHeader("Authorization", "Bearer YOUR_TOKEN_HERE");

            var response = restClient.Execute(request);
            #endregion
            #region Assert


            //// Convert actual status code to enum
            int actualStatusCode = (int)response.StatusCode;

            //// Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, actualStatusCode);
            #endregion Assert

        }

        [Fact]
        public async Task Put_Edit_Acl_AclRolePageAssociation()
        {
            #region  Arrange
            var id = getRandomID();
            AclRoleAndPageAssocUpdateRequest editReq = GetRoleAndPageAssocUpdateRequest(id);

            #endregion
            #region Act
            //// Create request
            var req = new RestRequest(AclRoutesUrl.AclRolePageRouteUrl.Edit, Method.Put);
            //Add request body
            req.AddBody(editReq);

            //// Add headers
            //request.AddHeader("Authorization", "Bearer YOUR_TOKEN_HERE");

            //// Execute request
            var respons = restClient.Execute(req);

            //// Convert actual status code to enum
            int actualEditStatusCode = (int)respons.StatusCode;
            //// Assert for create

            #endregion
            #region Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, actualEditStatusCode);
            #endregion Assert
        }

        public AclRoleAndPageAssocUpdateRequest GetRoleAndPageAssocUpdateRequest(ulong id)
        {
            var faker = new Faker();

            // Generate a random role ID
            ulong roleId = (ulong)faker.Random.Int(1, int.MaxValue);

            // Generate a random number of page IDs (between 1 and 10)
            int numberOfPages = faker.Random.Int(1, 10);
            int[] pageIds = new int[numberOfPages];
            for (int i = 0; i < numberOfPages; i++)
            {
                pageIds[i] = faker.Random.Int(1, int.MaxValue);
            }

            // Create and return the request object
            return new AclRoleAndPageAssocUpdateRequest
            {
                role_id = roleId,
                PageIds = pageIds
            };
        }



        private ulong getRandomID()
        {
            #region Act
            //    // Act
            try
            {
                return (ulong)(unitOfWork.ApplicationDbContext.AclRolePages.OrderByDescending(rp => rp.Id).LastOrDefault()?.RoleId); 

            }
            catch (Exception ex)
            {
                return (ulong)dbConnector.dbContext.AclRolePages.OrderByDescending(rp => rp.Id).LastOrDefault()?.RoleId;
            }
            #endregion

        }
    }
}

