//namespace SharedLibrary.Services;
//using System.Reflection;
//using Microsoft.AspNetCore.Mvc.ModelBinding;
//using SharedLibrary.Utilities;


//public class ContextBinderProvider : IModelBinderProvider
//{
//    public IModelBinder? GetBinder(ModelBinderProviderContext context)
//    {
//        if (context == null)
//        {
//            throw new ArgumentNullException(nameof(context));
//        }

//        //var modelName = context.Metadata.ModelName;
//        var modelType = context.Metadata.ModelType;

//        // Check if the model type is your PaymentRequest class
//        if (modelType is IModelBinderProvider)
//        {
            
//                // Create a custom model binder for PaymentRequest
//                return new ContextBinder();
            
//        }

//        return null;
//    }
//}