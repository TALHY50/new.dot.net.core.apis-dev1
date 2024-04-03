using System.Net;
using ACL.Database.Models;

namespace ACL.Response.V1
{
    public class MessageResponse
    {
        public string fetchMessage = " fetched succesfully";
        public string editMessage = "  edited succesfully.";
        public string createMessage = " created succesfully.";
        public string deleteMessage = " deleted succesfully.";
        public string noFoundMessage = "No data found.";
        public MessageResponse(string model) {
            fetchMessage = model + fetchMessage;
            editMessage = model+ editMessage;
            createMessage = model+ createMessage;
            deleteMessage = model+ deleteMessage;
         
        }

    }
}
