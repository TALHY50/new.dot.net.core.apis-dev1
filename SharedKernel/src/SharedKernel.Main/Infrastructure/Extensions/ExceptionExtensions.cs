namespace SharedKernel.Main.Infrastructure.Extensions;

public static class ExceptionExtensions
{
  
        public static IEnumerable<Exception> InnerExceptions(this Exception ex)
        {
            if (ex == null)
            {
                throw new ArgumentNullException("ex");
            }

            var innerException = ex;
            do
            {
                yield return innerException;
                innerException = innerException.InnerException;
            }
            while (innerException != null);
        }
    
}