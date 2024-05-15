
using System.Globalization;
using ACL.Application.Interfaces;
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
        public string createFail = "createFail";
        public string deleteFail = "deleteFail";
        public string editFail = "editFail";
        public string somethingIsWrong = "somethingIsWrong";
        public MessageResponse(string model, ICustomUnitOfWork _unitOfWork, string language = "en-US") : base(model, language)
        {
            fetchMessage = base.FetchMessage;
            editMessage = base.EditMessage;
            createMessage = base.CreateMessage;
            deleteMessage = base.DeleteMessage;
            existMessage = base.ExistMessage;
            notFoundMessage = base.NotFoundMessage;
            createFail = base.CreateFail;
            editFail = base.EditFail;
            deleteFail = base.DeleteFail;
            somethingIsWrong = base.SomethingIsWrong;

        }

    }
}
