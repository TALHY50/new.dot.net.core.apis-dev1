using exception = System.Exception;

namespace IMT.PayAll.Exception
{
    public class ValidationsException : exception
    {
        public Dictionary<string, List<string>> ValidationErrors { get; }

        public ValidationsException(Dictionary<string, List<string>> validationErrors)
        {
            ValidationErrors = validationErrors;
        }
    }
}
