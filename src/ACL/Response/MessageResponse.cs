
using System.Globalization;
using ACL.Database;
using ACL.Interfaces;
using ACL.Services;
using SharedLibrary.Interfaces;
using SharedLibrary.Response;

namespace ACL.Response.V1
{
    public class MessageResponse : BaseMessageResponse
    {
        public string fetchMessage = "fetchMessage";
        public string editMessage = "editMessage";
        public string createMessage = "createMessage";
        public string deleteMessage = "deleteMessage";
        public string notFoundMessage = "notFoundMessage";
        public string existMessage = "existMessage";
        public MessageResponse(string model, ICustomUnitOfWork _unitOfWork, string language = "en-US") :base(model,language)
        {
            try
            {
                fetchMessage = base.GetFetchMessage(model,language);
                editMessage = base.GetEditMessage(model, language);
                createMessage =  base.GetCreateMessage(model, language);
                deleteMessage = base.GetDeleteMessage(model, language);
                existMessage =  base.GetExistMessage(model, language);
                notFoundMessage = base.GetNotFoundMessage(language);
            }
            catch (Exception ex)
            {
                fetchMessage = model + " fetchMessage";
                editMessage = model + " editMessage";
                createMessage = model + " createMessage";
                deleteMessage = model + " deleteMessage";
                existMessage = model + " existMessage";
            }

        }

    }
}
