using System.Net;
using System.Text.Json;
using ACL.Response.V1;
using MySql.Data.MySqlClient;


namespace ACL.Exceptions
{
    public class GlobalExceptionHandling
    {
        private readonly RequestDelegate _next;
        AclResponse aclResponse = new AclResponse();

        public GlobalExceptionHandling(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            string message = string.Empty;
            switch (exception)
            {
                case MySqlException ex:
                    AclErrorResponse(HttpStatusCode.NotFound, ex.Message);
                    break;
                case ApplicationException ex:
                    message = "Application Exception Occured, please retry after sometime.";
                    AclErrorResponse(HttpStatusCode.BadRequest, message);
                    break;
                case FileNotFoundException ex:
                    message = "The requested resource is not found.";
                    AclErrorResponse(HttpStatusCode.NotFound, message);
                    break;
                default:
                    message = "Internal Server Error, Please retry after sometime";
                    AclErrorResponse(HttpStatusCode.InternalServerError, message);
                    break;

            }
            var exResult = JsonSerializer.Serialize(aclResponse);
            await context.Response.WriteAsync(exResult);
        }

        private AclResponse AclErrorResponse(HttpStatusCode statusCode, string message)
        {
            aclResponse.StatusCode = statusCode;
            aclResponse.Message = message;
            return aclResponse;
        }
    }

}

