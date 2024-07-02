using IMT.Thunes.Exception;
using IMT.Thunes.Response.Common;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IMT.Thunes.Request.Transaction.Transfer.CommonTransaction
{
    public class CreateTransactionRequest
    {
        public string external_id { get; set; }
        public CreditPartyIdentifier? credit_party_identifier { get; set; }
        public Beneficiary? beneficiary { get; set; }
        public SendingBusiness? sending_business { get; set; }
        public Sender? sender { get; set; }
        public ReceivingBusinesss? receiving_business { get; set; }
        public string? document_reference_number { get; set; }
        public string? purpose_of_remittance { get; set; }

        public bool IsValid(string transferType)
        {
            List<ErrorsResponse> errors = new List<ErrorsResponse>();
            switch (transferType)
            {
                case "b2b":
                    if (external_id == null)
                    {
                        errors.Add(new ErrorsResponse { code = "Request invalid", message = "external_id must be valid" });
                    }
                    if (credit_party_identifier == null)
                    {
                        errors.Add(new ErrorsResponse { code = "Request invalid", message = "credit_party_identifier must be present" });
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(credit_party_identifier.iban))
                        {
                            errors.Add(new ErrorsResponse { code = "Request invalid", message = "iban must be valid" });
                        }
                    }

                    if (sending_business == null)
                    {
                        errors.Add(new ErrorsResponse { code = "Request invalid", message = "sending_business must be valid" });
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(sending_business.code))
                        {
                            errors.Add(new ErrorsResponse { code = "Request invalid", message = "code must be valid in sending_bussiness" });
                        }
                        if (string.IsNullOrWhiteSpace(sending_business.country_iso_code))
                        {
                            errors.Add(new ErrorsResponse { code = "Request invalid", message = "country_iso_code must be valid in sending_bussiness" });
                        }
                        if (string.IsNullOrWhiteSpace(sending_business.registered_name))
                        {
                            errors.Add(new ErrorsResponse { code = "Request invalid", message = "registered_name must be valid in sending_bussiness" });
                        }
                        if (string.IsNullOrWhiteSpace(sending_business.registration_number))
                        {
                            errors.Add(new ErrorsResponse { code = "Request invalid", message = "registration_number must be valid in sending_bussiness" });
                        }
                    }
                    if (receiving_business == null)
                    {
                        errors.Add(new ErrorsResponse { code = "Request invalid", message = "sending_business must be valid" });
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(receiving_business.registered_name))
                        {
                            errors.Add(new ErrorsResponse { code = "Request invalid", message = "registered_name must be valid in receiving_business" });
                        }
                        if (string.IsNullOrWhiteSpace(receiving_business.country_iso_code))
                        {
                            errors.Add(new ErrorsResponse { code = "Request invalid", message = "country_iso_code must be valid in receiving_business" });
                        }
                    }
                    if (string.IsNullOrWhiteSpace(document_reference_number))
                    {
                        errors.Add(new ErrorsResponse { code = "Request invalid", message = "document_reference_number must be valid" });
                    }
                    if (string.IsNullOrWhiteSpace(purpose_of_remittance))
                    {
                        errors.Add(new ErrorsResponse { code = "Request invalid", message = "purpose_of_remittance must be valid" });
                    }
                    if (errors.Count > 0)
                    {
                        throw new ThunesException(400, errors);
                    }
                    return external_id != null &&
                           credit_party_identifier != null && !string.IsNullOrEmpty(credit_party_identifier.iban) &&
                           sending_business != null && !string.IsNullOrEmpty(sending_business.code) &&
                           !string.IsNullOrEmpty(sending_business.country_iso_code) &&
                           !string.IsNullOrEmpty(sending_business.registered_name) &&
                           !string.IsNullOrEmpty(sending_business.registration_number) &&
                           receiving_business != null && !string.IsNullOrEmpty(receiving_business.registered_name) &&
                           !string.IsNullOrEmpty(receiving_business.country_iso_code) &&
                           !string.IsNullOrEmpty(document_reference_number) &&
                           !string.IsNullOrEmpty(purpose_of_remittance);

                case "b2c":
                    if (external_id == null)
                    {
                        errors.Add(new ErrorsResponse { code = "Request invalid", message = "external_id must be valid" });
                    }
                    if (credit_party_identifier == null)
                    {
                        errors.Add(new ErrorsResponse { code = "Request invalid", message = "credit_party_identifier must be present" });
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(credit_party_identifier.iban))
                        {
                            errors.Add(new ErrorsResponse { code = "Request invalid", message = "iban must be valid" });
                        }
                    }

                    if (sending_business == null)
                    {
                        errors.Add(new ErrorsResponse { code = "Request invalid", message = "sending_business must be valid" });
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(sending_business.code))
                        {
                            errors.Add(new ErrorsResponse { code = "Request invalid", message = "code must be valid in sending_bussiness" });
                        }
                        if (string.IsNullOrWhiteSpace(sending_business.country_iso_code))
                        {
                            errors.Add(new ErrorsResponse { code = "Request invalid", message = "country_iso_code must be valid in sending_bussiness" });
                        }
                        if (string.IsNullOrWhiteSpace(sending_business.registered_name))
                        {
                            errors.Add(new ErrorsResponse { code = "Request invalid", message = "registered_name must be valid in sending_bussiness" });
                        }
                        if (string.IsNullOrWhiteSpace(sending_business.registration_number))
                        {
                            errors.Add(new ErrorsResponse { code = "Request invalid", message = "registration_number must be valid in sending_bussiness" });
                        }
                    }
                    if (beneficiary == null)
                    {
                        errors.Add(new ErrorsResponse { code = "Request invalid", message = "sending_business must be valid" });
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(beneficiary.lastname))
                        {
                            errors.Add(new ErrorsResponse { code = "Request invalid", message = "lastname must be valid in beneficiary" });
                        }
                        if (string.IsNullOrWhiteSpace(beneficiary.firstname))
                        {
                            errors.Add(new ErrorsResponse { code = "Request invalid", message = "firstname must be valid in beneficiary" });
                        }
                        if (string.IsNullOrWhiteSpace(beneficiary.country_iso_code))
                        {
                            errors.Add(new ErrorsResponse { code = "Request invalid", message = "country_iso_code must be valid in beneficiary" });
                        }
                    }
                    if (string.IsNullOrWhiteSpace(purpose_of_remittance))
                    {
                        errors.Add(new ErrorsResponse { code = "Request invalid", message = "purpose_of_remittance must be valid" });
                    }
                    if (errors.Count > 0)
                    {
                        throw new ThunesException(400, errors);
                    }
                    return external_id != null &&
                           credit_party_identifier != null && !string.IsNullOrEmpty(credit_party_identifier.iban) &&
                           beneficiary != null && !string.IsNullOrEmpty(beneficiary.lastname) &&
                           !string.IsNullOrEmpty(beneficiary.firstname) &&
                           !string.IsNullOrEmpty(beneficiary.country_iso_code) &&
                           sending_business != null && !string.IsNullOrEmpty(sending_business.code) &&
                           !string.IsNullOrEmpty(sending_business.country_iso_code) &&
                           !string.IsNullOrEmpty(sending_business.registered_name) &&
                           !string.IsNullOrEmpty(purpose_of_remittance) &&
                           !string.IsNullOrEmpty(sending_business.registration_number);

                case "c2c":
                    if (external_id == null)
                    {
                        errors.Add(new ErrorsResponse { code = "Request invalid", message = "external_id must be valid" });
                    }
                    if (credit_party_identifier == null)
                    {
                        errors.Add(new ErrorsResponse { code = "Request invalid", message = "credit_party_identifier must be present" });
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(credit_party_identifier.iban))
                        {
                            errors.Add(new ErrorsResponse { code = "Request invalid", message = "iban must be valid" });
                        }
                    }

                    if (sender == null)
                    {
                        errors.Add(new ErrorsResponse { code = "Request invalid", message = "sender must be valid" });
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(sender.address))
                        {
                            errors.Add(new ErrorsResponse { code = "Request invalid", message = "address must be valid in sender" });
                        }
                        if (string.IsNullOrWhiteSpace(sender.country_iso_code))
                        {
                            errors.Add(new ErrorsResponse { code = "Request invalid", message = "country_iso_code must be valid in sender" });
                        }
                        if (string.IsNullOrWhiteSpace(sender.lastname))
                        {
                            errors.Add(new ErrorsResponse { code = "Request invalid", message = "lastname must be valid in sender" });
                        }
                        if (string.IsNullOrWhiteSpace(sender.city))
                        {
                            errors.Add(new ErrorsResponse { code = "Request invalid", message = "city must be valid in sender" });
                        }
                        if (string.IsNullOrWhiteSpace(sender.firstname))
                        {
                            errors.Add(new ErrorsResponse { code = "Request invalid", message = "firstname must be valid in sender" });
                        }
                        if (string.IsNullOrWhiteSpace(sender.country_of_birth_iso_code))
                        {
                            errors.Add(new ErrorsResponse { code = "Request invalid", message = "country_of_birth_iso_code must be valid in sender" });
                        }
                        if (string.IsNullOrWhiteSpace(sender.date_of_birth))
                        {
                            errors.Add(new ErrorsResponse { code = "Request invalid", message = "date_of_birth must be valid in sender" });
                        }
                        if (string.IsNullOrWhiteSpace(sender.code))
                        {
                            errors.Add(new ErrorsResponse { code = "Request invalid", message = "code must be valid in sender" });
                        }
                    }
                    if (beneficiary == null)
                    {
                        errors.Add(new ErrorsResponse { code = "Request invalid", message = "beneficiary must be valid" });
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(beneficiary.lastname))
                        {
                            errors.Add(new ErrorsResponse { code = "Request invalid", message = "lastname must be valid in beneficiary" });
                        }
                        if (string.IsNullOrWhiteSpace(beneficiary.firstname))
                        {
                            errors.Add(new ErrorsResponse { code = "Request invalid", message = "firstname must be valid in beneficiary" });
                        }
                    }
                    if (string.IsNullOrWhiteSpace(purpose_of_remittance))
                    {
                        errors.Add(new ErrorsResponse { code = "Request invalid", message = "purpose_of_remittance must be valid" });
                    }
                    if (errors.Count > 0)
                    {
                        throw new ThunesException(400, errors);
                    }
                    return external_id != null &&
                           credit_party_identifier != null && !string.IsNullOrEmpty(credit_party_identifier.iban) &&
                           beneficiary != null && !string.IsNullOrEmpty(beneficiary.lastname) &&
                           !string.IsNullOrEmpty(beneficiary.firstname) &&
                           sender != null && !string.IsNullOrEmpty(sender.address) &&
                           !string.IsNullOrEmpty(sender.country_iso_code) &&
                           !string.IsNullOrEmpty(sender.lastname) &&
                           !string.IsNullOrEmpty(sender.city) &&
                           !string.IsNullOrEmpty(sender.firstname) &&
                           !string.IsNullOrEmpty(sender.country_of_birth_iso_code) &&
                           !string.IsNullOrEmpty(purpose_of_remittance) &&
                           !string.IsNullOrEmpty(sender.date_of_birth);

                default:
                    return false;
            }
        }
    }

    public class CreditPartyIdentifier
    {
        public string iban { get; set; }
    }

    public class Beneficiary
    {
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string? country_iso_code { get; set; }
    }

    public class SendingBusiness
    {
        public string code { get; set; }
        public string country_iso_code { get; set; }
        public string registered_name { get; set; }
        public string registration_number { get; set; }
    }

    public class Sender
    {
        public string address { get; set; }
        public string country_iso_code { get; set; }
        public string lastname { get; set; }
        public string city { get; set; }
        public string firstname { get; set; }
        public string country_of_birth_iso_code { get; set; }
        public string date_of_birth { get; set; }
        public string code { get; set; }
    }

    public class ReceivingBusinesss
    {
        public string registered_name { get; set; }
        public string country_iso_code { get; set; }
    }
}
