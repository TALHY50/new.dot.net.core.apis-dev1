﻿using ACL.Tests;
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
using ACL.Contracts.Requests.V1;
using ACL.Infrastructure.Route;
using SharedLibrary.Response.CustomStatusCode;

namespace ACL.Tests.V1
{
    public class AclRolePageAssociationControllerUnitTest
    {
        RestClient restClient;
        public AclRolePageAssociationControllerUnitTest()
        {
            DataCollectors.SetDatabase(false);
            restClient = new RestClient(DataCollectors.baseUrl);
        }
        [Fact]
        public async Task Get_All_AclRolePageAssociation()
        {
            #region  Arrange
            var id = GetRandomID();
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
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, actualStatusCode);
            #endregion Assert

        }

        [Fact]
        public async Task Put_Edit_Acl_AclRolePageAssociation()
        {
            #region  Arrange

            var id = GetRandomID();
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
            var response = restClient.Execute(req);

            //// Convert actual status code to enum
            int actualEditStatusCode = (int)response.StatusCode;
            //// Assert for create

            #endregion
            #region Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(AppStatusCode.SUCCESS, actualEditStatusCode);
            #endregion Assert
        }

        public AclRoleAndPageAssocUpdateRequest GetRoleAndPageAssocUpdateRequest(ulong id)
        {
            var faker = new Faker();
            var gotid = DataCollectors.dbContext.AclPages.Max(i=>i.Id);
            var roleId = DataCollectors.dbContext.AclRoles.Max(i=>i.Id);
          
            int[] pageIds = new int[] { (int)gotid };
            
               var toReturn = new AclRoleAndPageAssocUpdateRequest
                {
                    RoleId = roleId,
                    PageIds = pageIds
                };
            return toReturn;


        }





        private ulong GetRandomID()
        {
            #region Act
            //    // Act
            return (ulong)DataCollectors.dbContext.AclRolePages.Max(i=>i.RoleId);
            #endregion

        }
    }
}
