
using System.Globalization;
using ACL.Database;
using ACL.Interfaces;
using ACL.Services;
using SharedLibrary.Interfaces;

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
        public MessageResponse(string model, ICustomUnitOfWork _unitOfWork, string language = "en-US")
        {
            this.cultureInfo = new CultureInfo(language);
            try
            {
                fetchMessage = _unitOfWork.GetLocalizedStringWithCulture(model, cultureInfo) + " " + _unitOfWork.GetLocalizedStringWithCulture(fetchMessage, cultureInfo);
                editMessage = _unitOfWork.GetLocalizedStringWithCulture(model, cultureInfo) + " " + _unitOfWork.GetLocalizedStringWithCulture(editMessage, cultureInfo);
                createMessage = _unitOfWork.GetLocalizedStringWithCulture(model, cultureInfo) + " " + _unitOfWork.GetLocalizedStringWithCulture(createMessage, cultureInfo);
                deleteMessage = _unitOfWork.GetLocalizedStringWithCulture(model, cultureInfo) + " " + _unitOfWork.GetLocalizedStringWithCulture(deleteMessage, cultureInfo);
                existMessage = _unitOfWork.GetLocalizedStringWithCulture(existMessage, cultureInfo);
            }
            catch (Exception ex)
            {
                fetchMessage = "fetchMessage";
                editMessage = "editMessage";
                createMessage = "createMessage";
                deleteMessage = "deleteMessage";
                existMessage = "existMessage";
            }

        }

    }
}
