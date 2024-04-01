
using System.Text;

namespace SharedLibrary.Utilities;

public class Http : HttpClient
{
    public HttpResponseMessage Post(string endpoint, HttpContent? content)
    {
        var http = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
        if (content != null)
        {
            request.Content = content;
            foreach (var header in content.Headers)
            {
                request.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }
  
        var response = http.Send(request);

        return response;
    }
    
    public HttpResponseMessage Get(string endpoint)
    {
        var http = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
        var response = http.Send(request);

        return response;
    }

    public HttpResponseMessage Get(string endpoint, Dictionary<string, string> headers)
    {
        var http = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
        
        if (headers != null)
        {   
            
            
            foreach (var header in headers)
            {
                request.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }

        var response = http.Send(request);

        return response;
    }
    
    public StringBuilder BuildForm<T>(string postBackUrl, T response)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<html>");
        sb.AppendFormat(@"<body onload='document.forms[""form""].submit()'>");
        sb.AppendFormat("<form name='form' action='{0}' method='post'>",postBackUrl);
        //sb.AppendFormat("<input type='hidden' name='id' value='{0}'>", "rifat");
        
        
        foreach (var kvp in response as Dictionary<string, object>)
        {
            if (kvp.Value != null)
            {
                sb.AppendFormat("<input type='hidden' name='{0}' value='{1}'>", kvp.Key, kvp.Value.ToString());
            }

        }

        sb.Append("</form>");
        sb.Append("</body>");
        sb.Append("</html>");

        return sb;
        
    }
    
    public string BuildRedirectUrl<T>(string getbackUrl, T parameters)
    {
        var uriBuilder = new UriBuilder(getbackUrl);
        var query = new List<string>();
        
        // Check if the URL already has query parameters
        if (!string.IsNullOrWhiteSpace(uriBuilder.Query))
        {
            // Remove the leading "?" character and split the existing query parameters
            var existingQueryParameters = uriBuilder.Query.TrimStart('?').Split('&');

            // Add the existing query parameters to the list
            query.AddRange(existingQueryParameters);
        }

        
    
        foreach (var parameter in parameters as Dictionary<string, object>)
        {
            query.Add($"{Uri.EscapeDataString(parameter.Key.ToString())}={Uri.EscapeDataString(parameter.Value.ToString())}");
        }
    
        uriBuilder.Query = string.Join("&", query);
        

        return uriBuilder.Uri.ToString();
        // return getbackUrl + uriBuilder.Uri.Query;
    }

    public object Post(string getUrl, string convertheader)
    {
        throw new NotImplementedException();
    }
}