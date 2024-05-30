
namespace IMT.PayAll.Request
{
    public class CreatePaymentRequest
    {
        public string ClientPaymentId { get; set; }
        public Recipient Recipient { get; set; }
        public PaymentInstrument PaymentInstrument { get; set; }
        public string RecipientId { get; set; }
        public string PaymentInstrumentId { get; set; }
        public string SourceAccountId { get; set; }
        public Amount Amount { get; set; }
        public string ExchangeRateId { get; set; }
        public string CardedRateId { get; set; }
        public KYT KYT { get; set; }
        
    }

    public class RegistrationAddress
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string UnitNumber { get; set; }
        public string BuildingName { get; set; }
        public string StateProvince { get; set; }
        public string BuildingNumber { get; set; }
    }

    public class IdentityDocument
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

    public class Recipient
    {
        public string Type { get; set; } = "Person";
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string MobileNumber { get; set; }
        public DateTime Dob { get; set; }
        public List<RegistrationAddress> RegistrationAddress { get; set; }
        public IdentityDocument IdentityDocument { get; set; }
    }

    public class PaymentInstrument
    {
        public string Category { get; set; }
        public string Currency { get; set; }
        public string MobileNumber { get; set; }
    }

    public class SupportingDocument
    {
        public string DocumentId { get; set; }
    }

    public class KYT
    {
        public string DestinationCountry { get; set; }
        public string PaymentPurpose { get; set; }
        public string CommercialActivity { get; set; }
        public string PaymentDescription { get; set; }
        public List<SupportingDocument> SupportingDocuments { get; set; }
    }

    public class Amount
    {
        public string Currency { get; set; }
        public int Value { get; set; }
    }
}