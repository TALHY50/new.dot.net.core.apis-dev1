

namespace IMT.PayAll.Response.Common
{
    public class IdentityDocumentResponse
    {
        public string Type { get; set; }
        public string TypeVersionNumber { get; set; }
        public string CountryIssuing { get; set; }
        public string Number { get; set; }
        public string NationalIdNumber { get; set; }
        public string NationalIdNumberType { get; set; }
        public string Series { get; set; }
        public DateTime IssueDate { get; set; }
        public string PlaceOfIssue { get; set; }
        public string AuthorityOfIssue { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string DriverLicenseNumber { get; set; }
        public string DriverLicenseSerialNumber { get; set; }
        public string DriverLicenseVersionNumber { get; set; }
    }
}
