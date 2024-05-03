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
using Google.Protobuf.WellKnownTypes;
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
        public AclRolePageAssociationControllerUnitTest()
        {
            dbConnector = new DatabaseConnector();
            unitOfWork = new CustomUnitOfWork(dbConnector.dbContext);
            unitOfWork.ApplicationDbContext = dbConnector.dbContext;
            restClient = new RestClient(dbConnector.baseUrl);
        }
        [Fact]
        public async Task Get_All_AclRolePageAssociation()
        {
            #region  Arrange
            var id = getRandomID();
            #endregion
            #region Act
            var request = new RestRequest(AclRoutesUrl.AclRolePageRouteUrl.List.Replace("{id}", id.ToString()), RestSharp.Method.Get);

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
            var req = new RestRequest(AclRoutesUrl.AclRolePageRouteUrl.Edit, RestSharp.Method.Put);
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
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(200, actualEditStatusCode);
            #endregion Assert
        }

        public AclRoleAndPageAssocUpdateRequest GetRoleAndPageAssocUpdateRequest(ulong id)
        {
            var faker = new Faker();
            var gotid = unitOfWork.ApplicationDbContext.AclPages.Max(i=>i.Id);
            var roleId = unitOfWork.ApplicationDbContext.AclRoles.Max(i=>i.Id);
          
            int[] pageIds = new int[] { (int)gotid };
            
               var toReturn = new AclRoleAndPageAssocUpdateRequest
                {
                    RoleId = roleId,
                    PageIds = pageIds
                };
            return toReturn;


        }





        private ulong getRandomID()
        {
            #region Act
            //    // Act
            return (ulong)unitOfWork.ApplicationDbContext.AclRolePages.Max(i=>i.RoleId);
            #endregion

        }
    }
}

