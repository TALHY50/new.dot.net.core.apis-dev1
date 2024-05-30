
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using IMT.PayAll.Exception;
using Newtonsoft.Json;
using exception = System.Exception;

namespace IMT.PayAll.Net
{
    public class RestClient : BaseRestClient
    {
      
        public static string Post<T>(string url, string headers, object request)
        {
            return Exchange<T>(url, HttpMethod.Post, headers, request);
        }

        public static T Post<T>(string url, Dictionary<string, string> headers)
        {
            return Exchange<T>(url, HttpMethod.Post, headers, null);
        }

        private static string Exchange<T>(string url, HttpMethod httpMethod, string barier, object requestmodel)
        {
            try
            {
                //var jsonContent = "{\"client_payment_id\":\"string\",\"recipient\":{\"type\":\"Person\",\"email\":\"user@example.com\",\"first_name\":\"string\",\"last_name\":\"string\",\"middle_name\":\"string\",\"mobile_number\":\"string\",\"dob\":\"2024-05-30\",\"registration_address\":[{\"city\":\"string\",\"street\":\"string\",\"country\":\"string\",\"postal_code\":\"string\",\"unit_number\":\"string\",\"building_name\":\"string\",\"state_province\":\"string\",\"building_number\":\"string\"}],\"identity_document\":{\"type\":\"string\",\"type_version_number\":\"string\",\"country_issuing\":\"string\",\"number\":\"string\",\"national_id_number\":\"string\",\"national_id_number_type\":\"string\",\"series\":\"string\",\"issue_date\":\"2024-05-30T10:28:20.751Z\",\"place_of_issue\":\"string\",\"authority_of_issue\":\"string\",\"expiry_date\":\"2024-05-30T10:28:20.751Z\",\"driver_license_number\":\"string\",\"driver_license_serial_number\":\"string\",\"driver_license_version_number\":\"string\"}},\"payment_instrument\":{\"category\":\"MobileWallet\",\"currency\":\"string\",\"mobile_number\":\"string\"},\"recipient_id\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\",\"payment_instrument_id\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\",\"source_account_id\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\",\"amount\":{\"currency\":\"EUR\",\"value\":10023},\"exchange_rate_id\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\",\"carded_rate_id\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\",\"kyt\":{\"destination_country\":\"GB\",\"payment_purpose\":\"family_maintenance\",\"commercial_activity\":\"transportation\",\"payment_description\":\"string\",\"supporting_documents\":[{\"document_id\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\"}]}}";

                var requestContent = new StringContent(requestmodel.ToString(), Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(httpMethod, url)
                {
                    Headers = { {"accept", "application/json" },{"Authorization",barier}},
                    Content = requestContent
                };

                var response = HttpClient.SendAsync(request).Result;

                return response.ToString();
            }
            catch (PayAllException e)
            {
                throw e;
            }
            catch (exception e)
            {
                throw new PayAllException(e);
            }
        }
        private static T Exchange<T>(string url, HttpMethod httpMethod, Dictionary<string, string> headers,
            object request)
        {
            try
            {
              
                var requestMessage = BuildHttpRequestMessage(url, httpMethod, headers, request);
                var httpResponseMessage = HttpClient.SendAsync(requestMessage).Result;
                var content = httpResponseMessage.Content.ReadAsByteArrayAsync().Result;
                return HandleResponse<T>(httpResponseMessage, content);
            }
            catch (PayAllException e)
            {
                throw e;
            }
            catch (exception e)
            {
                throw new PayAllException(e);
            }
        }
    }
}