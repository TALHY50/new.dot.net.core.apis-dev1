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
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace ACL.Tests.V1
{
    public class AclRolePageAssociationControllerUnitTest
    {
        DatabaseConnector dbConnector;
        CustomUnitOfWork unitOfWork;
        RestClient restClient;
        DbContextOptions<ApplicationDbContext> _inMemoryDbContextOptions;
        ApplicationDbContext _inMemoryDbContext;
        AclRoleAndPageAssocController _controller;
        public AclRolePageAssociationControllerUnitTest()
        {
            dbConnector = new DatabaseConnector();
            _inMemoryDbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "acl")
                .Options;
            _inMemoryDbContext = new ApplicationDbContext(_inMemoryDbContextOptions);
            unitOfWork = new CustomUnitOfWork(_inMemoryDbContext);
            restClient = new RestClient(dbConnector.baseUrl);
            //  unitOfWork = new UnitOfWork(dbConnector.dbContext);
            unitOfWork.ApplicationDbContext = _inMemoryDbContext;
            _controller = new AclRoleAndPageAssocController(unitOfWork);
        }
        [Fact]
        public async Task Get_All_AclRolePageAssociation()
        {
            #region  Arrange
            var testData = GetRoleAndPageAssocUpdateRequest(1).Result;
            var testinput = unitOfWork.AclRolePageRepository.PrepareData(testData);
            await unitOfWork.AclRolePageRepository.AddAll(testinput);
            await unitOfWork.CommitTransactionAsync();
            await unitOfWork.CompleteAsync();
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
            //var testData = GetRoleAndPageAssocUpdateRequest(1).Result;
            //var testinput = unitOfWork.AclRolePageRepository.PrepareData(testData);
            //await unitOfWork.AclRolePageRepository.AddAll(testinput);
            //await unitOfWork.CommitTransactionAsync();
            //await unitOfWork.CompleteAsync();
            //var test = await unitOfWork.AclRolePageRepository.GetAllById(1);
            await Get_All_AclRolePageAssociation();

            var id = getRandomID();
            AclRoleAndPageAssocUpdateRequest editReq = GetRoleAndPageAssocUpdateRequest(id).Result;

            #endregion
            #region Act
            //// Create request
            var req = new RestRequest(AclRoutesUrl.AclRolePageRouteUrl.Edit, Method.Put);
            //Add request body
            req.AddJsonBody(editReq);

            //// Add headers
            //request.AddHeader("Authorization", "Bearer YOUR_TOKEN_HERE");

            //// Execute request
            var respons = restClient.Execute(req);

            //// Convert actual status code to enum
            int actualEditStatusCode = (int)respons.StatusCode;
            //// Assert for create

            #endregion
            #region Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(400, actualEditStatusCode);
            #endregion Assert
        }

        public async Task<AclRoleAndPageAssocUpdateRequest> GetRoleAndPageAssocUpdateRequest(ulong id)
        {
            var faker = new Faker();
            if (unitOfWork.AclCompanyRepository.GetAll().Result.Data == null)
            {
                await unitOfWork.AclCompanyRepository.AddAclCompany(new AclCompanyCreateRequest
                {
                    name = faker.Company.CompanyName(),
                    cname = faker.Company.CompanyName(),
                    cemail = faker.Internet.Email(),
                    address1 = faker.Address.StreetAddress(),
                    address2 = faker.Address.SecondaryAddress(),
                    city = faker.Random.String2(15),
                    state = faker.Address.State(),
                    country = faker.Address.Country(),
                    postcode = faker.Address.ZipCode(),
                    phone = faker.Random.String2(15),
                    timezone = faker.Random.Number(-12, 12), // Convert to string if 'timezone' is a string
                    timezone_value = faker.Random.String2(20),
                    logo = faker.Image.PicsumUrl(),
                    fax = faker.Random.String2(15),
                    registration_no = faker.Random.AlphaNumeric(10),
                    tax_no = faker.Random.AlphaNumeric(10),
                    unique_column_name = (sbyte)faker.Random.Byte(), // Ensure 'unique_column_name' is of correct type
                    email = faker.Internet.Email(),
                    password = faker.Internet.Password()
                });
                unitOfWork.Complete();
            }
            if (unitOfWork.AclRoleRepository.GetAll().Result.Data == null)
            {
                unitOfWork.AclRoleRepository.Add(new AclRole() { CompanyId = id, Status = 1, Name = "Test", Id = id });
                unitOfWork.Complete();
            }

            ulong roleId = unitOfWork.AclRoleRepository.FirstOrDefault().Result.Id;
            List<AclPage> gotfromDb = (List<AclPage>)unitOfWork.AclPageRepository.GetAll().Result.Data;
            if (gotfromDb.Count == 0)
            {
                await unitOfWork.AclPageRepository.AddRange(new AclPage[]
                  {
                    new AclPage { Id = 3001, ModuleId = 1001, SubModuleId = 2001, Name = "Company List", MethodName = "index",      MethodType   = 0,   AvailableToCompany = 0, CreatedAt = DateTime.Parse("2015-12-09 12:10:51"), UpdatedAt =       DateTime.Parse  ("2015-12-09    12:10:51") },
                    new AclPage { Id = 3002, ModuleId = 1001, SubModuleId = 2001, Name = "Add New Company", MethodName = "create",        MethodType   = 0, AvailableToCompany = 0, CreatedAt = DateTime.Parse("2015-12-09 12:10:52"), UpdatedAt   =        DateTime.Parse("2015-12-09    12:10:52") },
                    new AclPage { Id = 3003, ModuleId = 1001, SubModuleId = 2001, Name = "Modify Company", MethodName = "edit",       MethodType   =    2, AvailableToCompany = 0, CreatedAt = DateTime.Parse("2015-12-09 12:10:52"), UpdatedAt   =     DateTime.Parse    ("2019-03-27   15:03:28") },
                    new AclPage { Id = 3084, ModuleId = 1003, SubModuleId = 2055, Name = "View Company Module", MethodName =    "show",          MethodType = 0, AvailableToCompany = 0, CreatedAt = DateTime.Parse("2015-12-09 12:10:52"),    UpdatedAt =      DateTime.Parse  ("2015-12-09 12:10:52") }
                  });
                await unitOfWork.CommitTransactionAsync();
                await unitOfWork.CompleteAsync();

            }
            gotfromDb = (List<AclPage>)unitOfWork.AclPageRepository.GetAll().Result.Data;
            Random random = new Random();

            List<AclPage> shuffledList = gotfromDb.OrderBy(x => random.Next()).ToList();

            // Take 2 or 3 elements from the shuffled list and select their Ids
            int[] randomPageIds = shuffledList.Take(random.Next(1, 2)).Select(page => (int)page.Id).ToArray();
            int[] pageIds = gotfromDb.Select(page => (int)page.Id).ToArray();
            // Create and return the request object

            List<AclRolePage> testCheck = (List<AclRolePage>)unitOfWork.AclRolePageRepository.GetAllById(roleId).Result.Data;
            var toReturn = new AclRoleAndPageAssocUpdateRequest();
            if (testCheck.Count > 0)
            {
                toReturn = new AclRoleAndPageAssocUpdateRequest
                {
                    role_id = roleId,
                    PageIds = randomPageIds
                };
            }
            else
            {
                toReturn = new AclRoleAndPageAssocUpdateRequest
                {
                    role_id = roleId,
                    PageIds = pageIds
                };
                var tosave = unitOfWork.AclRolePageRepository.PrepareData(toReturn);
                await unitOfWork.AclRolePageRepository.AddRange(tosave);
                await unitOfWork.CompleteAsync();
                toReturn = new AclRoleAndPageAssocUpdateRequest
                {
                    role_id = roleId,
                    PageIds = randomPageIds
                };
                testCheck = (List<AclRolePage>)unitOfWork.AclRolePageRepository.GetAllById(roleId).Result.Data;
            }
            return toReturn;


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

