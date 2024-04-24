
using System.Globalization;
using ACL.Interfaces;

namespace ACL.Response.V1
{
    public class MessageResponse
    {
        public string fetchMessage = "fetchMessage";
        public string editMessage = "editMessage";
        public string createMessage = "createMessage";
        public string deleteMessage = "deleteMessage";
        public string notFoundMessage = "notFoundMessage";
        public string existMessage = "existMessage";
        CultureInfo cultureInfo;
        public MessageResponse(string model,IUnitOfWork _unitOfWork,string language = "en-US"){
            this.cultureInfo = new CultureInfo(language);
            fetchMessage = _unitOfWork.GetLocalizedStringWithCulture(model, cultureInfo) + " " + _unitOfWork.GetLocalizedStringWithCulture(fetchMessage, cultureInfo);
            editMessage = _unitOfWork.GetLocalizedStringWithCulture(model, cultureInfo) + " " + _unitOfWork.GetLocalizedStringWithCulture(editMessage, cultureInfo); 
            createMessage = _unitOfWork.GetLocalizedStringWithCulture(model, cultureInfo) + " " + _unitOfWork.GetLocalizedStringWithCulture(createMessage, cultureInfo); 
            deleteMessage = _unitOfWork.GetLocalizedStringWithCulture(model, cultureInfo) + " " + _unitOfWork.GetLocalizedStringWithCulture(deleteMessage, cultureInfo);
            existMessage =  _unitOfWork.GetLocalizedStringWithCulture(existMessage, cultureInfo);

        }

    }
}
