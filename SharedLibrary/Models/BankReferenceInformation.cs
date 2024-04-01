using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using SharedLibrary.Services;
using SharedLibrary.Utilities;

namespace SharedLibrary.Models;

public partial class BankReferenceInformation
{
    public int Id { get; set; }

    public string OrderId { get; set; } = null!;

    public string? Provider { get; set; }

    public string ReferenceInfo { get; set; } = null!;

    public CReferenceInfo? ReferenceInfoObject => Json.Derialize<CReferenceInfo>(ReferenceInfo);

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    
    
    public class CReferenceInfo
    {
        [JsonProperty("client_id")]
        public string? ClientId { get; set; }

        [JsonProperty("username")]
        public string? UserName { get; set; }

        [JsonProperty("password")]
        public string? Password { get; set; }

        [JsonProperty("store_key")]
        public string? StoreKey { get; set; }
    
        [JsonProperty("remote_order_id")]
        public string RemoteOrderId { get; set; }

        [JsonProperty("rrn_reference")]
        public string RRNReference { get; set; }

        [JsonProperty("stan_reference")]
        public string StanReference { get; set; }

        [JsonProperty("provision_number")]
        public string ProvisionNumber { get; set; }
        
        
        [JsonIgnore]
        public string? DecryptedClientId
        {
            get
            {
                // Decrypt the value and return it
                return Cryptographer.AppDecrypt(this.ClientId);
            }
        }
        
        [JsonIgnore]
        public string? DecryptedUserName
        {
            get
            {
                return Cryptographer.AppDecrypt(this.UserName);
            }
        }
        
        [JsonIgnore]
        public string? DecryptedPassword
        {
            get
            {
                return Cryptographer.AppDecrypt(this.Password);
            }
        }
        
        [JsonIgnore]
    
        public string? DecryptedStoreKey
        {
            get
            {
                return Cryptographer.AppDecrypt(this.StoreKey);
            }
        }
        
    }

    
    
}



