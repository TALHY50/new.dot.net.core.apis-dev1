//using System.Reflection;
//using Microsoft.AspNetCore.Mvc.ModelBinding;
//using SharedLibrary.Attributes;
//using SharedLibrary.Utilities;

//namespace SharedLibrary.Services;

//public class ContextBinder : IModelBinder
//{
//    public Task BindModelAsync(ModelBindingContext bindingContext)
//    {
//        if (bindingContext == null)
//        {
//            throw new ArgumentNullException(nameof(bindingContext));
//        }
        
//        var modelName = bindingContext.BinderModelName;

//        // Create an instance of the model type
//        var model = Activator.CreateInstance(bindingContext.ModelType);

//        // Get the properties that are marked with the FormFieldNameAttribute
//        var properties = bindingContext.ModelType
//            .GetProperties();

        
//        foreach (var property in properties)
//        {
//            string  fieldName;
//            var fieldNameAttribute = property.GetCustomAttribute<FormFieldNameAttribute>();

//            if (fieldNameAttribute != null)
//            {
//                fieldName = fieldNameAttribute.FieldName;
//            }
//            else
//            {
//                fieldName = property.Name;
//            }
//            var valueProviderResult = bindingContext.ValueProvider.GetValue(fieldName);
//            if (valueProviderResult != ValueProviderResult.None)
//            {
//                var value = valueProviderResult.FirstValue;
//                object safeValue = Converter.ConvertType(value, property);
//                property.SetValue(model, safeValue, null);
//            }
//        }
        
//        //bindingContext.Result = ModelBindingResult.Failed();
        
//        bindingContext.Result = ModelBindingResult.Success(model);
        

//        return Task.CompletedTask;
//    }
//}