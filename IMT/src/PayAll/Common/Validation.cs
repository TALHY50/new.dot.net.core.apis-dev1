
using System.ComponentModel.DataAnnotations;

using IMT.PayAll.Exception;

namespace IMT.PayAll.Common
{
    public static class Validation
    {
        public static void ValidateModel<T>(T model) where T : class
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);
            bool isValid = Validator.TryValidateObject(model, validationContext, validationResults, true);

            if (!isValid)
            {
                var validationErrors = new Dictionary<string, List<string>>();

                foreach (var validationResult in validationResults)
                {
                    foreach (var memberName in validationResult.MemberNames)
                    {
                        if (!validationErrors.ContainsKey(memberName))
                        {
                            validationErrors[memberName] = new List<string>();
                        }
                        validationErrors[memberName].Add(validationResult.ErrorMessage);
                    }
                }

                throw new ValidationsException(validationErrors);
            }

        }
    }
}
