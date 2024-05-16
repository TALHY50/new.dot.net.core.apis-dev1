using ACL.Application.Interfaces;
using SharedLibrary.Response;

namespace ACL.Contracts.Response
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
        public MessageResponse(string model, string language = "en-US") : base(model, language)
        {
            this.fetchMessage = base.FetchMessage;
            this.editMessage = base.EditMessage;
            this.createMessage = base.CreateMessage;
            this.deleteMessage = base.DeleteMessage;
            this.existMessage = base.ExistMessage;
            this.notFoundMessage = base.NotFoundMessage;
            this.createFail = base.CreateFail;
            this.editFail = base.EditFail;
            this.deleteFail = base.DeleteFail;
            this.somethingIsWrong = base.SomethingIsWrong;

        }

    }
}
